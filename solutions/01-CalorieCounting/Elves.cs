using System.Collections;

namespace AdventOfCode2022.CalorieCounting;

public class Elves : IEnumerable<Elf>
{
  private readonly List<Elf> _elves;

  public Elf this[int index] { get => _elves[index]; }

  private Elves(List<Elf> elves)
  {
    _elves = elves;
  }
  public static Elves From(IEnumerable<string> inputLines)
  {
    List<Elf> elves = new();
    Elf elf = new();
    foreach (string line in inputLines)
    {
      if (string.IsNullOrEmpty(line))
      {
        elves.Add(elf);
        elf = new();
      }
      else
      {
        elf.Calories.Add(int.Parse(line));
      }
    }
    elves.Add(elf);

    return new Elves(elves);
  }

  public IEnumerator<Elf> GetEnumerator()
  {
    return _elves.GetEnumerator();
  }

  IEnumerator IEnumerable.GetEnumerator()
  {
    return GetEnumerator();
  }
}

public class Elf
{
  public List<int> Calories { get; } = new();
  public void AddCalories(int calories)
  {
    Calories.Add(calories);
  }

  public int TotalCalories()
  {
    return Calories.Sum();
  }
}