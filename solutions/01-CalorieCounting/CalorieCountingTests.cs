namespace AdventOfCode2022.CalorieCounting;

public class CalorieCountingTests : IClassFixture<InputFilesFixture>
{
  private readonly InputFilesFixture _fixture;

  public CalorieCountingTests(InputFilesFixture fixture)
  {
    _fixture = fixture;
  }

  [Fact]
  public void ShouldCreateElfCollection()
  {
    IEnumerable<string> inputLines = _fixture.TestInput;
    
    Elves elves = Elves.From(inputLines);

    elves[0].Calories.Should().Equal(new int[] { 1000, 2000, 3000 });
    elves[1].Calories.Should().Equal(new int[] { 4000 });
    elves[2].Calories.Should().Equal(new int[] { 5000, 6000 });
    elves[3].Calories.Should().Equal(new int[] { 7000, 8000, 9000 });
    elves[4].Calories.Should().Equal(new int[] { 10000 });
  }

  [Fact]
  public void ShouldFindCaloriesCarriedByElfCarryingTheMostCaloriesInTestInput()
  {
    IEnumerable<string> inputLines = _fixture.TestInput;
    int expectedCalories = 24000;
    var elves = Elves.From(inputLines);

    int actualCalories = elves.Select(elf => elf.TotalCalories()).Max();

    actualCalories.Should().Be(expectedCalories);
  }

  [Fact]
  public void ShouldFindCaloriesCarriedByElfCarryingTheMostCaloriesInSolutionInput()
  {
    IEnumerable<string> inputLines = _fixture.SolutionInput;
    int expectedCalories = 70698;
    var elves = Elves.From(inputLines);

    int actualCalories = elves.Select(elf => elf.TotalCalories()).Max();

    actualCalories.Should().Be(expectedCalories);
  }

  [Fact]
  public void ShouldFindTheTopThreeElvesCarryingTheMostCaloriesInTestIntput()
  {
    IEnumerable<string> inputLines = _fixture.TestInput;
    int expectedCalories = 45000;
    var elves = Elves.From(inputLines);

     int actualCalories = elves
      .Select(elf => elf.TotalCalories())
      .OrderDescending()
      .Take(3)
      .Sum();
     

    actualCalories.Should().Be(expectedCalories);
  }

  [Fact]
  public void ShouldFindTheTopThreeElvesCarryingTheMostCaloriesInSolutionIntput()
  {
    IEnumerable<string> inputLines = _fixture.SolutionInput;
    int expectedCalories = 206643;
    var elves = Elves.From(inputLines);

     int actualCalories = elves
      .Select(elf => elf.TotalCalories())
      .OrderDescending()
      .Take(3)
      .Sum();
     

    actualCalories.Should().Be(expectedCalories);
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