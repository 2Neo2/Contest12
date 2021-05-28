using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        int[] inputTShort = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int[] inputPants = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        int colorTtrue = 0;
        int colorPtrue = 0;
        var ptr2 = 0;
        var ptr1 = 0;
        var min = Int32.MaxValue;

        while (inputTShort[ptr1] < inputPants[ptr2] && ptr1 < inputTShort.Length - 1)
            ptr1++;


        if (min > Math.Abs(inputTShort[ptr1] - inputPants[ptr2]))
        {
            min = Math.Abs(inputTShort[ptr1] - inputPants[ptr2]);
            colorPtrue = inputPants[ptr2];
            colorTtrue = inputTShort[ptr1];
        }

        while (ptr1 != inputTShort.Length)
        {
            while (ptr2 + 1 < inputPants.Length && inputPants[ptr2 + 1] <= inputTShort[ptr1])
            {
                ptr2++;
                if (min > Math.Abs(inputTShort[ptr1] - inputPants[ptr2]))
                {
                    min = Math.Abs(inputTShort[ptr1] - inputPants[ptr2]);
                    colorPtrue = inputPants[ptr2];
                    colorTtrue = inputTShort[ptr1];
                }
            }

            ptr1++;
        }

        ptr2 = 0;
        ptr1 = 0;

        while (inputTShort[ptr1] > inputPants[ptr2] && ptr2 < inputPants.Length - 1)
            ptr2++;
        if (min > Math.Abs(inputTShort[ptr1] - inputPants[ptr2]))
        {
            min = Math.Abs(inputTShort[ptr1] - inputPants[ptr2]);
            colorPtrue = inputPants[ptr2];
            colorTtrue = inputTShort[ptr1];
        }

        while (ptr2 != inputPants.Length)
        {
            while (ptr1 + 1 < inputTShort.Length && inputTShort[ptr1 + 1] <= inputPants[ptr2])
            {
                ptr1++;
                if (min > Math.Abs(inputTShort[ptr1] - inputPants[ptr2]))
                {
                    min = Math.Abs(inputTShort[ptr1] - inputPants[ptr2]);
                    colorPtrue = inputPants[ptr2];
                    colorTtrue = inputTShort[ptr1];
                }
            }

            ptr2++;
        }

        Console.WriteLine(colorTtrue + " " + colorPtrue);
    }
}