using System;
using System.Collections.Generic;
using System.Linq;

public partial class Program
{
    private static List<Cat> ChooseCats(int minTailLength, int maxTailLength, int maxAge, List<Cat> cats)
    {
        var maxTail = cats.Select(x => x.TailLength).Max();
        return cats.Where(x =>
                (x.IsBlack && x.Age <= maxAge && x.TailLength >= minTailLength && x.TailLength <= maxTailLength) 
            || x.TailLength == maxTail)
            .Select(x => x).ToList();
    }
}