using Ardalis.Extensions.StringChecks;

namespace AdventOfCode2022.SupplyStacks;

public class SupplyStacksTests : IClassFixture<InputFilesFixture>
{
  private readonly InputFilesFixture _fixture;

  public SupplyStacksTests(InputFilesFixture fixture)
  {
    _fixture = fixture;
  }

  [Fact]
  public void ShouldFindTheCratesEndingUpOnTopOfEachStackForTestInput()
  {
    Dictionary<int, Queue<char>> queues = new();
    List<string> stackInputLines = _fixture.TestInput.TakeWhile(line => !line.IsNullOrEmpty()).ToList();
    List<string> crateInputLines = _fixture.TestInput.Skip(stackInputLines.Count + 1).ToList();
    foreach (var line in stackInputLines)
    {
      for (int i = 1; i < line.Length; i += 4)
      {
        char crate = line[i];
        if (char.IsLetter(crate))
        {
          int stackId = (int)((0.25 * i) + 0.75);
          if (!queues.ContainsKey(stackId)) queues[stackId] = new Queue<char>();
          queues[stackId].Enqueue(crate);
        }
      }
    }

    Dictionary<int, Stack<char>> stacks = queues.ToDictionary(kvp => kvp.Key, kvp => new Stack<char>(kvp.Value.Reverse()));

    foreach (var line in crateInputLines)
    {
      string[] parts = line.Split(' ');
      int numberOfCratesToMove = int.Parse(parts[1]);
      int fromStackId = int.Parse(parts[3]);
      int toStackId = int.Parse(parts[5]);
      for (int i = 0; i < numberOfCratesToMove; i++)
      {
        stacks[toStackId].Push(stacks[fromStackId].Pop());
      }
    }

    string actual = string.Join("", stacks
      .GroupBy((kvp) => kvp.Key)
      .OrderBy(group => group.Key)
      .Select(group => group.First().Value.Peek())
    );
    actual.Should().Be("CMZ");
  }

  [Fact]
  public void ShouldFindTheCratesEndingUpOnTopOfEachStackForSolutionInput()
  {
    Dictionary<int, Queue<char>> queues = new();
    List<string> stackInputLines = _fixture.SolutionInput.TakeWhile(line => !line.IsNullOrEmpty()).ToList();
    List<string> crateInputLines = _fixture.SolutionInput.Skip(stackInputLines.Count + 1).ToList();
    foreach (var line in stackInputLines)
    {
      for (int i = 1; i < line.Length; i += 4)
      {
        char crate = line[i];
        if (char.IsLetter(crate))
        {
          int stackId = (int)((0.25 * i) + 0.75);
          if (!queues.ContainsKey(stackId)) queues[stackId] = new Queue<char>();
          queues[stackId].Enqueue(crate);
        }
      }
    }

    Dictionary<int, Stack<char>> stacks = queues.ToDictionary(kvp => kvp.Key, kvp => new Stack<char>(kvp.Value.Reverse()));

    foreach (var line in crateInputLines)
    {
      string[] parts = line.Split(' ');
      int numberOfCratesToMove = int.Parse(parts[1]);
      int fromStackId = int.Parse(parts[3]);
      int toStackId = int.Parse(parts[5]);
      for (int i = 0; i < numberOfCratesToMove; i++)
      {
        stacks[toStackId].Push(stacks[fromStackId].Pop());
      }
    }

    string actual = string.Join("", stacks
      .GroupBy((kvp) => kvp.Key)
      .OrderBy(group => group.Key)
      .Select(group => group.First().Value.Peek())
    );
    actual.Should().Be("CVCWCRTVQ");
  }

  [Fact]
  public void ShouldFindTheCratesEndingUpOnTopOfEachStackWithNewCraneForTestInput()
  {
    Dictionary<int, Queue<char>> queues = new();
    List<string> stackInputLines = _fixture.TestInput.TakeWhile(line => !line.IsNullOrEmpty()).ToList();
    List<string> crateInputLines = _fixture.TestInput.Skip(stackInputLines.Count + 1).ToList();
    foreach (var line in stackInputLines)
    {
      for (int i = 1; i < line.Length; i += 4)
      {
        char crate = line[i];
        if (char.IsLetter(crate))
        {
          int stackId = (int)((0.25 * i) + 0.75);
          if (!queues.ContainsKey(stackId)) queues[stackId] = new Queue<char>();
          queues[stackId].Enqueue(crate);
        }
      }
    }

    Dictionary<int, Stack<char>> stacks = queues.ToDictionary(kvp => kvp.Key, kvp => new Stack<char>(kvp.Value.Reverse()));

    foreach (var line in crateInputLines)
    {
      string[] parts = line.Split(' ');
      int numberOfCratesToMove = int.Parse(parts[1]);
      int fromStackId = int.Parse(parts[3]);
      int toStackId = int.Parse(parts[5]);

      Stack<char> cratesToMove = new();
      for (int i = 0; i < numberOfCratesToMove; i++)
      {
        cratesToMove.Push(stacks[fromStackId].Pop());
      }
      for (int i = 0; i < numberOfCratesToMove; i++)
      {
        stacks[toStackId].Push(cratesToMove.Pop());
      }
    }

    string actual = string.Join("", stacks
      .GroupBy((kvp) => kvp.Key)
      .OrderBy(group => group.Key)
      .Select(group => group.First().Value.Peek())
    );
    actual.Should().Be("MCD");
  }

  [Fact]
  public void ShouldFindTheCratesEndingUpOnTopOfEachStackWithNewCraneForSolutionInput()
  {
    Dictionary<int, Queue<char>> queues = new();
    List<string> stackInputLines = _fixture.SolutionInput.TakeWhile(line => !line.IsNullOrEmpty()).ToList();
    List<string> crateInputLines = _fixture.SolutionInput.Skip(stackInputLines.Count + 1).ToList();
    foreach (var line in stackInputLines)
    {
      for (int i = 1; i < line.Length; i += 4)
      {
        char crate = line[i];
        if (char.IsLetter(crate))
        {
          int stackId = (int)((0.25 * i) + 0.75);
          if (!queues.ContainsKey(stackId)) queues[stackId] = new Queue<char>();
          queues[stackId].Enqueue(crate);
        }
      }
    }

    Dictionary<int, Stack<char>> stacks = queues.ToDictionary(kvp => kvp.Key, kvp => new Stack<char>(kvp.Value.Reverse()));

    foreach (var line in crateInputLines)
    {
      string[] parts = line.Split(' ');
      int numberOfCratesToMove = int.Parse(parts[1]);
      int fromStackId = int.Parse(parts[3]);
      int toStackId = int.Parse(parts[5]);

      Stack<char> cratesToMove = new();
      for (int i = 0; i < numberOfCratesToMove; i++)
      {
        cratesToMove.Push(stacks[fromStackId].Pop());
      }
      for (int i = 0; i < numberOfCratesToMove; i++)
      {
        stacks[toStackId].Push(cratesToMove.Pop());
      }
    }

    string actual = string.Join("", stacks
      .GroupBy((kvp) => kvp.Key)
      .OrderBy(group => group.Key)
      .Select(group => group.First().Value.Peek())
    );
    actual.Should().Be("CNSCZWLVT");
  }
}

public class InputFilesFixture : IAsyncLifetime
{
  public IEnumerable<string> TestInput { get; private set; }
  public IEnumerable<string> SolutionInput { get; private set; }

  public async Task InitializeAsync()
  {
    TestInput = await InputFileConverter.GetLinesAsync("05-test-input.txt");
    SolutionInput = await InputFileConverter.GetLinesAsync("05-input.txt");
  }

  public Task DisposeAsync() => Task.CompletedTask;
}