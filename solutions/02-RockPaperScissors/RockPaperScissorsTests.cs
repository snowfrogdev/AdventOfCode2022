namespace AdventOfCode2022.RockPaperScissors;

public class RockPaperScissorsTests : IClassFixture<InputFilesFixture>
{
  private readonly InputFilesFixture _fixture;

  public RockPaperScissorsTests(InputFilesFixture fixture)
  {
    _fixture = fixture;
  }

  [Theory]
  [InlineData("A Y", 8)]
  [InlineData("B X", 1)]
  [InlineData("C Z", 6)]
  public void ShouldScoreARound(string round, int expectedScore)
  {
    int roundScore = RockPaperScissors.ScoreRound(round);

    roundScore.Should().Be(expectedScore);
  }

  [Fact]
  public void ShouldScoreATournamentWithTestInput()
  {
    IEnumerable<string> inputLines = _fixture.TestInput;
    int expectedScore = 15;

    int actualScore = RockPaperScissors.ScoreTournament(inputLines);

    actualScore.Should().Be(expectedScore);
  }

  [Fact]
  public void ShouldScoreATournamentWithSolutionInput()
  {
    IEnumerable<string> inputLines = _fixture.SolutionInput;
    int expectedScore = 9651;

    int actualScore = RockPaperScissors.ScoreTournament(inputLines);

    actualScore.Should().Be(expectedScore);
  }
}

public class InputFilesFixture : IAsyncLifetime
{
  public IEnumerable<string> TestInput { get; private set; }
  public IEnumerable<string> SolutionInput { get; private set; }

  public async Task InitializeAsync()
  {
    TestInput = await InputFileConverter.GetLinesAsync("02-test-input.txt");
    SolutionInput = await InputFileConverter.GetLinesAsync("02-input.txt");
  }

  public Task DisposeAsync() => Task.CompletedTask;
}