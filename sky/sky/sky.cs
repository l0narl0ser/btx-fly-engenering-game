using System;
using System.Linq;

public static class Search
{
    public static bool find<T>(this T[] motor, T detail)
    {
        return motor.Contains(detail);
    }
}

public class Ex
{
    public static void Main()
    {
        int[] motor = { 1, 2, 3, 4, 5 };
        int detail = 6;

        bool isThere = motor.find(detail);
        if (isThere)
        {
            Console.WriteLine("Элемент найден ");
        }
        else
        {
            Console.WriteLine("Элемент не найден в массиве");
        }
    }
}