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
