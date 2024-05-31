using System;
using System.Runtime.CompilerServices;

abstract class Algorithm
{
    public static void Algo()
    {
        List<int> test = new List<int>();
        List<int> exempleList = new List<int>{8, 5, 6, 7, 1, 2, 0};
        List<int> orderedList = new List<int>{0, 1, 2, 5, 6, 7, 8};
        Algorithms algo = new Algorithms();
        
        // Linear Sort
        if(algo.LinearSort(exempleList, 7) == 3) Console.WriteLine("1 : True");
        else Console.WriteLine("1 : False");

        // Bubble Sort
        if(algo.BubbleSort(exempleList).SequenceEqual(orderedList)) Console.WriteLine("1 : True");
        else Console.WriteLine("1 : False");

        // Binary Search
        if(algo.BinarySearch(orderedList, 7) == 5) Console.WriteLine("1 : True");
        else Console.WriteLine("1 : False");

        // Insertion Sort
        if(algo.InsertionSort(exempleList).SequenceEqual(orderedList)) Console.WriteLine("1 : True");
        else Console.WriteLine("1 : False");

    }
}

class Algorithms
{
    public int LinearSort(List<int> list, int value)
    {
        int i = 0;
        while(i < list.Count)
        {
            if(list[i] == value) return i;
            i++;
        }
        return -1;
    }

    public List<int> BubbleSort(List<int> list)
    {
        for(int i = 0; i < list.Count - 1; i++)
        {
            for(int j = 0; j < list.Count - i - 1; j++)
            {
                if(list[j] > list[j + 1])
                {
                    (list[j], list[j + 1]) = (list[j + 1], list[j]);
                }
            }
        }
        return list;
    }

    public int BinarySearch(List<int> list, int value)
    {
        int i = 0;
        int left = 0;
        int right = list.Count - 1;
        int medium;

        while(i < list.Count)
        {
            medium = left + (right - left) / 2;

            if(list[medium] == value)
            {
                return medium;
            }
            else if(list[medium] > value)
            {
                right =  medium - 1;
            }
            else
            {
                left =  medium + 1;
            }
        }
        return -1;
    }

    public List<int> InsertionSort(List<int> list)
    {
        // List<int> list2 = new List<int>();
        // list2.Add(list[0]);
        for(int i = 0; i < list.Count; i++)
        {
            int key = list[i];
            int j = i - 1;

            while(j >= 0 && list[j] > key)
            {
                list[j + 1] = list[j];
                j = j - 1;
            }
            list[j + 1] = key;
        }
        return list;
    }
}