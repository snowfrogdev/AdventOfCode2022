namespace AdventOfCode2022.NoSpaceLeftOnDevice;

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
      switch(line)
      {
        case "$ cd /":
          _current = _root;
          break;
        case "$ ls":
          break;
        case "$ cd ..":
          HandleChangeDirectoryToParent();
          break;
        case string s when s.StartsWith("$ cd "):
          HandleChangeDirectory(line);
          break;
        default:
          HandleFileSystemItem(line);
          break;
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