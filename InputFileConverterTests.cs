namespace AdventOfCode2022;

public class CalorieCountingTests
{

  [Fact]
  public async void ShouldConvertInputFileLinesToIEnumerableOfString()
  {
    List<string> expectedLines = new()
    {
      "1000",
      "2000",
      "3000",
      "",
      "4000",
      "",
      "5000",
      "6000",
      "",
      "7000",
      "8000",
      "9000",
      "",
      "10000"
    };

    IEnumerable<string> actualLines = await InputFileConverter.GetLinesAsync("01-test-input.txt");
    actualLines.Should().Equal(expectedLines);
  }
}