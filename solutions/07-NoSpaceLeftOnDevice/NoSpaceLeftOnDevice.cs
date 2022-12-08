namespace AdventOfCode2022.NoSpaceLeftOnDevice;

public class FileSystemItem
{
  public string Name { get; }
  public int Size { get; private set; }
  public FileSystemItem? Parent { get; }

  public bool IsDirectory { get => _children.Count > 0; }

  private readonly List<FileSystemItem> _children = new();

  public FileSystemItem(string name, int size, FileSystemItem? parent = null)
  {
    Name = name;
    Size = size;
    Parent = parent;
    _children = new List<FileSystemItem>();
  }

  public void AddChild(FileSystemItem child)
  {
    _children.Add(child);
    UpdateParentSizes(child.Size);
  }

  private void UpdateParentSizes(int sizeDelta)
  {
    var p = this;
    while (p != null)
    {
      p.Size += sizeDelta;
      p = p.Parent;
    }
  }

  public IEnumerable<FileSystemItem> Directories()
  {
    if (IsDirectory)
    {
      yield return this;
    }

    foreach (FileSystemItem child in _children)
    {
      foreach(FileSystemItem grandChild in child.Directories())
      {
        yield return grandChild;
      }
    }
  }

  public FileSystemItem? FindChild(string name)
  {
    return _children.Find(x => x.Name == name);
  }
}

public class Parser
{
  readonly private FileSystemItem _root;
  private FileSystemItem _current;

  public Parser()
  {
    _root = new FileSystemItem("/", 0);
    _current = _root;
  }

  public FileSystemItem Parse(IEnumerable<string> input)
  {
    foreach (string line in input)
    {
      if (line.StartsWith("$ cd /"))
      {
        _current = _root;
      }
      else if (line.StartsWith("$ ls"))
      {
        // (no action required)
      }
      else if (line.StartsWith("$ cd .."))
      {
        HandleChangeDirectoryToParent();
      }
      else if (line.StartsWith("$ cd "))
      {
        HandleChangeDirectory(line);
      }
      else
      {
        HandleFileSystemItem(line);
      }
    }

    return _root;
  }

  private void HandleChangeDirectory(string line)
  {
    string name = line.Substring(5);
    FileSystemItem? child = _current.FindChild(name);
    if (child != null)
    {
      _current = child;
    }
    else
    {
      throw new InvalidOperationException($"Directory {name} does not exist");
    }
  }

  private void HandleChangeDirectoryToParent()
  {
    if (_current.Parent != null)
    {
      _current = _current.Parent;
    }
  }

  private void HandleFileSystemItem(string line)
  {
    if (line.StartsWith("dir"))
    {
      HandleDirectory(line);
    }
    else
    {
      HandleFile(line);
    }
  }

  private void HandleFile(string line)
  {
    string[] parts = line.Split(' ');
    string name = parts[1];
    int size = int.Parse(parts[0]);
    if (_current.FindChild(name) == null)
    {
      FileSystemItem file = new(name, size, _current);
      _current.AddChild(file);
    }
  }

  private void HandleDirectory(string line)
  {
    string[] parts = line.Split(' ');
    string name = parts[1];
    if (_current.FindChild(name) == null)
    {
      FileSystemItem dir = new(name, 0, _current);
      _current.AddChild(dir);
    }    
  }
}