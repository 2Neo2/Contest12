using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml;

public class Game : IEnumerable
{
    private LinkedList<int> first;
    private LinkedList<int> second;
    private bool flag;
    
    public IEnumerator GetEnumerator()
    {
        while (true)
        {
            if (first.Count == 0)
            {
                yield return $"First win!";
                yield break;
            } 
            if (second.Count == 0)
            {
                yield return $"Second win!";
                yield break;
            } 
            
            if (!flag)
            {
                var generalParam = first.Count;
                for (int i = 0; i < first.Count; i++)
                {
                    if (first.First.Value >= second.First.Value)
                    {
                        yield return $"First: {first.First.Value}";
                        flag = true;
                        first.RemoveFirst();
                        break;
                    }
                    
                    var element = first.First;
                    first.RemoveFirst();
                    first.AddLast(element);
                }

                if (first.Count != generalParam)
                    continue;
                yield return "Second win!";
                yield break;
            }
            else
            {
                var generalParam = second.Count;
                for (int i = 0; i < second.Count; i++)
                {
                    if (first.First.Value <= second.First.Value)
                    {
                        yield return $"Second: {second.First.Value}";
                        flag = false;
                        second.RemoveFirst();
                        break;
                    }
                    
                    var element = second.First;
                    second.RemoveFirst();
                    second.AddLast(element);
                }
                if (second.Count != generalParam)
                    continue;
                yield return "First win!";
                yield break;
            }
        }
    }
    
    public Game(LinkedList<int> first, LinkedList<int> second)
    {
        this.first = first;
        this.second = second;
    }
}