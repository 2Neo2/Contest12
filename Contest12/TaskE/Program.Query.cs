using System;
using System.Collections.Generic;
using System.Linq;

public partial class Program
{
    private static List<Cat> ChooseCats(int minTailLength, int maxTailLength, int maxAge, List<Cat> cats)
    {
        return cats.Where(x =>
                x.IsBlack == true && x.Age <= maxAge && x.TailLength >= minTailLength && x.TailLength <= maxTailLength)
            .Select(x => x).ToList();
    }
}