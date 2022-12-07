namespace AdventOfCode2022.TuningTrouble;

public static class TuningTroubleExtensions
{
  public static IEnumerable<(T[] window, int index)> Windows<T>(this IEnumerable<T> source, int windowSize)
  {
    var enumerator = source.GetEnumerator();
    var index = 0;
    Queue<T> window = new(windowSize + 1);
    while(enumerator.MoveNext())
    {
      window.Enqueue(enumerator.Current);
      if (window.Count > windowSize) window.Dequeue();
      if (window.Count == windowSize) yield return (window.ToArray(), index);
      index++;      
    }
  }

  public static bool HasDuplicateCharacters(this char[] input)
  {
    return input.ToHashSet().Count != input.Length;
  }
}

public static class TuningTrouble 
{
  public static int FindStartOfPacket(string input)
  {
    return input
      .Windows(4)
      .First(x => !x.window.HasDuplicateCharacters())
      .index + 1;
  }
}