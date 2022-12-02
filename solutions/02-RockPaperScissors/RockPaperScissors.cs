namespace AdventOfCode2022.RockPaperScissors;

public static class RockPaperScissors
{
  public static int ScoreTournament(IEnumerable<string> inputLines)
  {
    return inputLines
      .Select(ScoreRound)
      .Sum();
  }

  public static int ScoreTournamentWithNewStrategy(IEnumerable<string> inputLines)
  {
    return inputLines
      .Select(ScoreRoundWithNewStrategy)
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

  public static int ScoreRoundWithNewStrategy(string round)
  {
    var opponentsShape = round.First();
    var myShape = round.Last();

    return GetScoreForNewStrategy(opponentsShape, myShape);
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

  private static int GetScoreForNewStrategy(char opponentsShape, char myShape)
  {
    return (opponentsShape, myShape) switch
    {
      ('A', 'X') => 0 + 3,
      ('A', 'Y') => 3 + 1,
      ('A', 'Z') => 6 + 2,
      ('B', 'X') => 0 + 1,
      ('B', 'Y') => 3 + 2,
      ('B', 'Z') => 6 + 3,
      ('C', 'X') => 0 + 2,
      ('C', 'Y') => 3 + 3,
      ('C', 'Z') => 6 + 1,      
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