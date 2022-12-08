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
      .FindDirectoriesSmallerOrEqualTo(100000)
      .Select(dir => dir.Size)
      .Sum()
      .Should().Be(95437);
  }

  [Fact]
  public void ShouldFindSumOfSizeOfSmallDirectoriesInSolutionInput()
  {
    new Parser()
      .Parse(_fixture.SolutionInput)
      .FindDirectoriesSmallerOrEqualTo(100000)
      .Select(dir => dir.Size)
      .Sum()
      .Should().Be(1648397);
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