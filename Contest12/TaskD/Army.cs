using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Xml;

public class Army : IEnumerable<int>
{
    private int N;
    private int[] solders;
    private List<int> newSolders;
    public Army(int[] soldiers, int n)
    {
        if (n < 1 || n > soldiers.Length)
            throw new  ArgumentException("N is not valid");
        else
        {
            N = n ;
            this.solders = soldiers;
        }
    }

    public IEnumerator<int> GetEnumerator()
    {
        newSolders = new List<int>();
        int k = 0;
        int index = 1;
        while (newSolders.Count != solders.Length)
        {
            if (N * ++k > solders.Length && !newSolders.Contains(solders[(index-- * N -1 + k++) % solders.Length]))
            {
                ++index;
                --k;
                newSolders.Add(solders[(index * N -1 + k) % solders.Length]);
            }
        }

        foreach (var number in solders)
        {
            yield return number;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}