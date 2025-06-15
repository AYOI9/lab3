using System;
using System.Linq;

// Интерфейс для операций с массивами
public interface IArrayOperations
{
    int[] Add(int[] otherArray);
    void ForEach();
}

// Базовый класс Array
public abstract class Array : IArrayOperations
{
    protected int[] data;

    public Array(int[] values)
    {
        data = values;
    }

    // Реализация методов интерфейса
    public abstract int[] Add(int[] otherArray);
    public abstract void ForEach();

    // Вспомогательный метод для вывода массива
    public void Print()
    {
        Console.WriteLine(string.Join(", ", data));
    }
}

// Класс для сортировки
public class SortArray : Array
{
    public SortArray(int[] values) : base(values) { }

    public override int[] Add(int[] otherArray)
    {
        // Объединение множеств (без дубликатов)
        return data.Union(otherArray).ToArray();
    }

    public override void ForEach()
    {
        // Сортировка массива
        System.Array.Sort(data);
    }
}

// Класс для XOR операций
public class XorArray : Array
{
    public XorArray(int[] values) : base(values) { }

    public override int[] Add(int[] otherArray)
    {
        // Исключающее ИЛИ для массивов
        int maxLength = Math.Max(data.Length, otherArray.Length);
        int[] result = new int[maxLength];

        for (int i = 0; i < maxLength; i++)
        {
            int a = i < data.Length ? data[i] : 0;
            int b = i < otherArray.Length ? otherArray[i] : 0;
            result[i] = a ^ b;
        }

        return result;
    }

    public override void ForEach()
    {
        // Вычисление квадратного корня
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = (int)Math.Sqrt(data[i]);
        }
    }
}

// Пример использования
class Program
{
    static void Main()
    {
        Console.WriteLine("SortArray:");
        var sortArr = new SortArray(new[] { 3, 1, 2 });
        sortArr.ForEach();
        sortArr.Print();

        var addedSort = sortArr.Add(new[] { 2, 4 });
        Console.WriteLine("После Add: " + string.Join(", ", addedSort));

        Console.WriteLine("\nXorArray:");
        var xorArr = new XorArray(new[] { 16, 9, 4 });
        xorArr.ForEach();
        xorArr.Print();

        var addedXor = xorArr.Add(new[] { 5, 3 });
        Console.WriteLine("После Add: " + string.Join(", ", addedXor));
    }
}