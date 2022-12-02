namespace AdventOfCode2022.RockPaperScissors;

public static class RockPaperScissors
{
  public static int ScoreTournament(IEnumerable<string> inputLines)
  {
    return inputLines
      .Select(ScoreRound)
      .Sum();
  }
  
  public static int ScoreRound(string round)
  {
    var opponentsShape = round.First();
    var myShape = round.Last();

    var shapeScore = GetValue(myShape);
    var resultScore = GetResultScore(opponentsShape, myShape);

    return shapeScore + resultScore;
  }

  private static int GetValue(char shape)
  {
    return shape switch
    {
      'A' or 'X' => 1,
      'B' or 'Y' => 2,
      'C' or 'Z' => 3,
      _ => throw new ArgumentException("Invalid shape")
    };
  }

  private static bool IsEqual(char opponentsShape, char myShape)
  {
    return opponentsShape == 'A' & myShape == 'X' ||
           opponentsShape == 'B' & myShape == 'Y' ||
           opponentsShape == 'C' & myShape == 'Z';
  }

  private static int GetResultScore(char opponentsShape, char myShape)
  {
    if (IsEqual(opponentsShape, myShape)) return 3;
    if (IsWinningRound(opponentsShape, myShape)) return 6;
    return 0;
  }

  private static bool IsWinningRound(char opponentsShape, char myShape) =>
    opponentsShape == 'A' && myShape == 'Y' ||
    opponentsShape == 'B' && myShape == 'Z' ||
    opponentsShape == 'C' && myShape == 'X';
}