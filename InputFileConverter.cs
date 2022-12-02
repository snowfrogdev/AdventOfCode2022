namespace AdventOfCode2022;

public static class InputFileConverter
{
  public static async Task<IEnumerable<string>> GetLinesAsync(string fileName)
  {
    var directory = Path.Combine(Directory.GetCurrentDirectory(), "inputs");
    var path = Path.Combine(directory, fileName);
    return await File.ReadAllLinesAsync(path);
  }
}
