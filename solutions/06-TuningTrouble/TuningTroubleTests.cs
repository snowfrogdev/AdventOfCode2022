using Ardalis.Extensions.Enumerable;

namespace AdventOfCode2022.TuningTrouble;

public class TuningTroubleTests : IClassFixture<InputFilesFixture>
{
  private readonly InputFilesFixture _fixture;

  public TuningTroubleTests(InputFilesFixture fixture)
  {
    _fixture = fixture;
  }

  [Fact]
  public void ShouldIterateThroughWindowsWithIndex()
  {
    var input = "mjqjpqmgbljsphdz";

    var expected = new [] {
      (new [] { 'm', 'j', 'q', 'j' }, 3),
      (new [] { 'j', 'q', 'j', 'p' }, 4),
      (new [] { 'q', 'j', 'p', 'q' }, 5),
      (new [] { 'j', 'p', 'q', 'm' }, 6),
      (new [] { 'p', 'q', 'm', 'g' }, 7),
      (new [] { 'q', 'm', 'g', 'b' }, 8),
      (new [] { 'm', 'g', 'b', 'l' }, 9),
      (new [] { 'g', 'b', 'l', 'j' }, 10),
      (new [] { 'b', 'l', 'j', 's' }, 11),
      (new [] { 'l', 'j', 's', 'p' }, 12),
      (new [] { 'j', 's', 'p', 'h' }, 13),
      (new [] { 's', 'p', 'h', 'd' }, 14),
      (new [] { 'p', 'h', 'd', 'z' }, 15),
    };

    input.Windows(4).Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
  }

  [Theory]
  [InlineData("mjqj", true)]
  [InlineData("jqjp", true)]
  [InlineData("qjpq", true)]
  [InlineData("jpqm", false)]
  [InlineData("abcd", false)]
  [InlineData("a", false)]
  [InlineData("aa", true)]
  [InlineData("abcdefghijklmnopqrstuvwxyz", false)]
  public void ShouldDetectIfStringContainsDuplicateCharacters(string input, bool expected)
  {
    var result = input.ToCharArray().HasDuplicateCharacters();
    result.Should().Be(expected);
  }


  [Theory]
  [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
  [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
  [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 6)]
  [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
  [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
  public void ShouldReturnIndexOfStartOfPacket(string input, int expected)
  {
    var result = TuningTrouble.FindStartOfPacket(input);

    result.Should().Be(expected);
  }

  [Fact]
  public void ShouldFindStartOfPacketForSolutionInput()
  {
    var result = TuningTrouble.FindStartOfPacket(_fixture.SolutionInput.First());

    result.Should().Be(1275);
  }
}




public class InputFilesFixture : IAsyncLifetime
{
  public IEnumerable<string> TestInput { get; private set; }
  public IEnumerable<string> SolutionInput { get; private set; }

  public async Task InitializeAsync()
  {
    TestInput = await InputFileConverter.GetLinesAsync("06-test-input.txt");
    SolutionInput = await InputFileConverter.GetLinesAsync("06-input.txt");
  }

  public Task DisposeAsync() => Task.CompletedTask;
}