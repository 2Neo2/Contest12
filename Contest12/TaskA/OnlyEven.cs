using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class OnlyEven : IEnumerable<int>
{
    private List<int> numbers;
    
    public OnlyEven(List<int> numbers)
    {
        this.numbers = numbers;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<int> GetEnumerator()
    { 
        return numbers.Where(x => x % 2 == 0).Select(x => x ).ToList().GetEnumerator();
    }
}