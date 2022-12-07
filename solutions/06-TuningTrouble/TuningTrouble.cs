namespace AdventOfCode2022.TuningTrouble;

public static class TuningTroubleExtensions
{
  public static int FindStartOfPacket(this string input)
  {
    return IndexOfLastElementOfFirstWindowWithNoDuplicateCharacters(input, 4);
  }

  public static int FindStartOfMessage(this string input)
  {
    return input.IndexOfLastElementOfFirstWindowWithNoDuplicateCharacters(14);
  }

  private static int IndexOfLastElementOfFirstWindowWithNoDuplicateCharacters(this string input, int windowSize)
  {
    return input
          .Windows(windowSize)
          .First(x => !x.window.HasDuplicateCharacters())
          .index + 1;
  }

  public static IEnumerable<(T[] window, int index)> Windows<T>(this IEnumerable<T> source, int windowSize)
  {
    var enumerator = source.GetEnumerator();
    var index = 0;
    Queue<T> window = new(windowSize + 1);
    while (enumerator.MoveNext())
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
