namespace AdventOfCode2022.CalorieCounting;

public class CalorieCountingTests : IClassFixture<InputFilesFixture>
{
  private readonly InputFilesFixture _fixture;

  public CalorieCountingTests(InputFilesFixture fixture)
  {
    _fixture = fixture;
  }

  [Fact]
  public async void ShouldConvertInputFileLinesToIEnumerableOfString()
  {

    IEnumerable<string> actualLines = await InputFileConverter.GetLinesAsync("01-test-input.txt");
    actualLines.Should().Equal(expectedLines);
  }
}

public class InputFilesFixture : IAsyncLifetime
{
  public IEnumerable<string> TestInput { get; private set; }
  public IEnumerable<string> SolutionInput { get; private set; }

  public async Task InitializeAsync()
  {
    TestInput = await InputFileConverter.GetLinesAsync("01-test-input.txt");
    SolutionInput = await InputFileConverter.GetLinesAsync("01-input.txt");
  }

  public Task DisposeAsync() => Task.CompletedTask;
}