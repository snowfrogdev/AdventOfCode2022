namespace AdventOfCode2022.CampCleanup;

public class CampCleanupTests : IClassFixture<InputFilesFixture>
{
  private readonly InputFilesFixture _fixture;

  public CampCleanupTests(InputFilesFixture fixture)
  {
    _fixture = fixture;
  }

  [Fact]
  public void ShouldFind2PairsWhereOneRangeFullyContainsTheOtherInTestInput()
  {
    int actual = _fixture.TestInput
      .Select(line => line.Split(','))
      .Select(pairs => new[] { pairs[0].Split('-'), pairs[1].Split('-') })
      .Select(pairs => new[] { (int.Parse(pairs[0][0]), int.Parse(pairs[0][1])), (int.Parse(pairs[1][0]), int.Parse(pairs[1][1])) })
      .Select(pairs =>
      {
        Array.Sort(pairs, (a, b) => a.Item1 - b.Item1);
        for (int i = 1; i < pairs.Length; i++)
        {
          if (pairs[i].Item2 <= pairs[i - 1].Item2) return 1;
        }
        return 0;
      })
      .Sum();

    actual.Should().Be(2);
  }

  [Fact]
  public void ShouldFind2PairsWhereOneRangeFullyContainsTheOtherInSolutionInput()
  {
    int actual = _fixture.SolutionInput
      .Select(line => line.Split(','))
      .Select(pairs => new[] { pairs[0].Split('-'), pairs[1].Split('-') })
      .Select(pairs => new[] { (int.Parse(pairs[0][0]), int.Parse(pairs[0][1])), (int.Parse(pairs[1][0]), int.Parse(pairs[1][1])) })
      .Select(FoundOverlap)
      .Sum();

    static int FoundOverlap((int, int)[] pairs)
    {
      Array.Sort(pairs, Compare);
      for (int i = 1; i < pairs.Length; i++)
      {
        if (pairs[i].Item2 <= pairs[i - 1].Item2) return 1;
      }
      return 0;
    }

    static int Compare((int, int) a, (int, int) b) {
      return a.Item1 == b.Item1 ? b.Item2 - a.Item2 : a.Item1 - b.Item1;
    };

    actual.Should().Be(471);
  }

  [Fact]
  public void ShouldFind2PairsWhereOneRangeOverlapsTheOtherInTestInput()
  {
    int actual = _fixture.TestInput
      .Select(line => line.Split(','))
      .Select(pairs => new[] { pairs[0].Split('-'), pairs[1].Split('-') })
      .Select(pairs => new[] { (int.Parse(pairs[0][0]), int.Parse(pairs[0][1])), (int.Parse(pairs[1][0]), int.Parse(pairs[1][1])) })
      .Select(FoundOverlap)
      .Sum();

    static int FoundOverlap((int, int)[] pairs)
    {
      Array.Sort(pairs, Compare);
      for (int i = 1; i < pairs.Length; i++)
      {
        if (pairs[i - 1].Item2 >= pairs[i].Item1) return 1;
      }
      return 0;
    }

    static int Compare((int, int) a, (int, int) b) {
      return a.Item1 == b.Item1 ? b.Item2 - a.Item2 : a.Item1 - b.Item1;
    };

    actual.Should().Be(4);
  }

  [Fact]
  public void ShouldFind2PairsWhereOneRangeOverlapsTheOtherInSolutionInput()
  {
    int actual = _fixture.SolutionInput
      .Select(line => line.Split(','))
      .Select(pairs => new[] { pairs[0].Split('-'), pairs[1].Split('-') })
      .Select(pairs => new[] { (int.Parse(pairs[0][0]), int.Parse(pairs[0][1])), (int.Parse(pairs[1][0]), int.Parse(pairs[1][1])) })
      .Select(FoundOverlap)
      .Sum();

    static int FoundOverlap((int, int)[] pairs)
    {
      Array.Sort(pairs, Compare);
      for (int i = 1; i < pairs.Length; i++)
      {
        if (pairs[i - 1].Item2 >= pairs[i].Item1) return 1;
      }
      return 0;
    }

    static int Compare((int, int) a, (int, int) b) {
      return a.Item1 == b.Item1 ? b.Item2 - a.Item2 : a.Item1 - b.Item1;
    };

    actual.Should().Be(888);
  }
}

public class InputFilesFixture : IAsyncLifetime
{
  public IEnumerable<string> TestInput { get; private set; }
  public IEnumerable<string> SolutionInput { get; private set; }

  public async Task InitializeAsync()
  {
    TestInput = await InputFileConverter.GetLinesAsync("04-test-input.txt");
    SolutionInput = await InputFileConverter.GetLinesAsync("04-input.txt");
  }

  public Task DisposeAsync() => Task.CompletedTask;
}