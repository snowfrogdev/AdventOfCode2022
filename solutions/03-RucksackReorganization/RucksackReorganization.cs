namespace AdventOfCode2022.RucksackReorganization;

public static class RucksackReorganization
{
  public static char FindCommonLetterInCompartments(string rucksack)
  {
    int mid = (rucksack.Length + 1) / 2;
    var compartments = (rucksack[..mid], rucksack[mid..]);	
    return compartments.Item1.Intersect(compartments.Item2).Single();	
  }

  public static int ConvertLetterToPriority(char letter)
  {
    return letter switch
    {
      >= 'a' and <= 'z' => letter - 'a' + 1,
      >= 'A' and <= 'Z' => letter - 'A' + 27,
      _ => throw new ArgumentException("Invalid letter", nameof(letter))
    };
  }

  public static int FindSumOfPriorities(IEnumerable<string> rucksacks)
  {
    return rucksacks
      .Select(FindCommonLetterInCompartments)
      .Select(ConvertLetterToPriority)
      .Sum();
  }
}