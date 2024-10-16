using System;
using System.Collections.Generic;

public class Box<T>
{
    private T value;

    public Box(T value)
    {
        this.value = value;
    }

    public override string ToString()
    {
        return $"{typeof(T).FullName}: {value}";
    }
}

public class CustomList<T> where T : IComparable<T>
{
    private List<T> items;

    public CustomList()
    {
        items = new List<T>();
    }

    public void Add(T element)
    {
        items.Add(element);
    }

    public T Remove(int index)
    {
        if (index < 0 || index >= items.Count)
            throw new ArgumentOutOfRangeException();
        T item = items[index];
        items.RemoveAt(index);
        return item;
    }

    public bool Contains(T element)
    {
        return items.Contains(element);
    }

    public void Swap(int index1, int index2)
    {
        if (index1 < 0 || index1 >= items.Count || index2 < 0 || index2 >= items.Count)
            throw new ArgumentOutOfRangeException();
        T temp = items[index1];
        items[index1] = items[index2];
        items[index2] = temp;
    }

    public int CountGreaterThan(T element)
    {
        int count = 0;
        foreach (var item in items)
        {
            if (item.CompareTo(element) > 0)
                count++;
        }
        return count;
    }

    public T Max()
    {
        if (items.Count == 0) throw new InvalidOperationException();
        T max = items[0];
        foreach (var item in items)
        {
            if (item.CompareTo(max) > 0)
                max = item;
        }
        return max;
    }

    public T Min()
    {
        if (items.Count == 0) throw new InvalidOperationException();
        T min = items[0];
        foreach (var item in items)
        {
            if (item.CompareTo(min) < 0)
                min = item;
        }
        return min;
    }

    public void Print()
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
}

public static class Sorter
{
    public static void Sort<T>(CustomList<T> list) where T : IComparable<T>
    {
        // Simple bubble sort
        for (int i = 0; i < list.Count; i++)
        {
            for (int j = 0; j < list.Count - 1; j++)
            {
                if (list[j].CompareTo(list[j + 1]) > 0)
                {
                    T temp = list[j];
                    list[j] = list[j + 1];
                    list[j + 1] = temp;
                }
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Завдання 1-7: Створення Box
        // Завдання 8-10: Створення CustomList та його обробка
        CustomList<string> customList = new CustomList<string>();
        string command;

        while ((command = Console.ReadLine()) != "END")
        {
            string[] tokens = command.Split();
            switch (tokens[0])
            {
                case "Add":
                    customList.Add(tokens[1]);
                    break;
                case "Remove":
                    customList.Remove(int.Parse(tokens[1]));
                    break;
                case "Contains":
                    Console.WriteLine(customList.Contains(tokens[1]) ? "True" : "False");
                    break;
                case "Swap":
                    customList.Swap(int.Parse(tokens[1]), int.Parse(tokens[2]));
                    break;
                case "Greater":
                    Console.WriteLine(customList.CountGreaterThan(tokens[1]));
                    break;
                case "Max":
                    Console.WriteLine(customList.Max());
                    break;
                case "Min":
                    Console.WriteLine(customList.Min());
                    break;
                case "Print":
                    customList.Print();
                    break;
                case "Sort":
                    Sorter.Sort(customList);
                    break;
            }
        }
    }
}
