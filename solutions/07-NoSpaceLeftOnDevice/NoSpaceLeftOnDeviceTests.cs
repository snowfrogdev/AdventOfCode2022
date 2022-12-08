using System.Text.RegularExpressions;

namespace AdventOfCode2022.NoSpaceLeftOnDevice;

public class NoSpaceLeftOnDeviceTests : IClassFixture<InputFilesFixture>
{
  private readonly InputFilesFixture _fixture;

  public NoSpaceLeftOnDeviceTests(InputFilesFixture fixture)
  {
    _fixture = fixture;
  }

  [Fact]
  public void ShouldFindSumOfSizeOfSmallDirectoriesInTestInput()
  {
    new Parser()
      .Parse(_fixture.TestInput)
      .Directories()
      .Select(dir => dir.Size)
      .Where(size => size <= 100000)
      .Sum()
      .Should().Be(95437);
  }

  [Fact]
  public void ShouldFindSumOfSizeOfSmallDirectoriesInSolutionInput()
  {
    new Parser()
      .Parse(_fixture.SolutionInput)
      .Directories()
      .Select(dir => dir.Size)
      .Where(size => size <= 100000)
      .Sum()
      .Should().Be(1648397);
  }

  [Fact]
  public void ShouldFindSizeOfDirectoryToDeleteInTestInput()
  {
    var fileSystem = new Parser().Parse(_fixture.TestInput);
    var freeSpace = 70000000 - fileSystem.Size;
    var spaceToFreeUp = 30000000 - freeSpace;
    var directoryToDelete = fileSystem.Directories()
      .Where(dir => dir.Size >= spaceToFreeUp)
      .OrderBy(dir => dir.Size)
      .First();

    directoryToDelete.Size.Should().Be(24933642);
  }

  [Fact]
  public void ShouldFindSizeOfDirectoryToDeleteInSolutionInput()
  {
    var fileSystem = new Parser().Parse(_fixture.SolutionInput);
    var freeSpace = 70000000 - fileSystem.Size;
    var spaceToFreeUp = 30000000 - freeSpace;
    var directoryToDelete = fileSystem.Directories()
      .Where(dir => dir.Size >= spaceToFreeUp)
      .OrderBy(dir => dir.Size)
      .First();

    directoryToDelete.Size.Should().Be(24933642);
  }
}




public class InputFilesFixture : IAsyncLifetime
{
  public IEnumerable<string> TestInput { get; private set; }
  public IEnumerable<string> SolutionInput { get; private set; }

  public async Task InitializeAsync()
  {
    TestInput = await InputFileConverter.GetLinesAsync("07-test-input.txt");
    SolutionInput = await InputFileConverter.GetLinesAsync("07-input.txt");
  }

  public Task DisposeAsync() => Task.CompletedTask;
}