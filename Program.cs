using System;
using WatchLibrary;
class Program
{
    /// <summary>
    /// Бренд самых новых часов
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    static string GetNewestBrand(Watch[] arr)
    {
        string newestBrand = "";
        int maxYear = 0;

        foreach (var item in arr)
        {
            if (item is Watch watch && watch.YearOfManufacture > maxYear)
            {
                maxYear = watch.YearOfManufacture;
                newestBrand = watch.Brand;
            }
        }
        return newestBrand;
    }
    /// <summary>
    /// Счётчик умных часов с датчиком сердцебиения
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    static int CountSmartWatchesWithHeartRateSensor(object[] arr)
    {
        int count = 0;

        foreach (var item in arr)
        {
            if (item is SmartWatch watch && watch.HeartRateSensor)
            {
                count++;
            }
        }
        return count;
    }
    static List<string> GetUniqueAnalogStyles(object[] arr)
    {
        var uniqueStyles = new HashSet<string>();

        foreach (var item in arr)
        {
            if (item is AnalogWatch watch)
            {
                uniqueStyles.Add(watch.WatchStyle);
            }
        }

        return new List<string>(uniqueStyles);
    }
    static void Main(string[] args)
    {
        // Создание массива объектов
        Watch[] arr = new Watch[]
        {
            new Watch("Rolex", 2020),
            new ElectronicWatch("Casio", 2019, "LCD"),
            new AnalogWatch("Seiko", 2018, "Классический"),
            new SmartWatch("Apple", 2021, "OLED", "WatchOS", true),
            new SmartWatch("Samsung", 2022, "AMOLED", "Tizen", false),
            new AnalogWatch("Omega", 2020, "Спортивный")
        };

        // Выполнение запросов
        Console.WriteLine($"Самый новый бренд часов: {GetNewestBrand(arr)}");
        Console.WriteLine($"Количество умных часов с датчиком пульса: {CountSmartWatchesWithHeartRateSensor(arr)}");
        Console.WriteLine("Уникальные стили аналоговых часов: " + string.Join(", ", GetUniqueAnalogStyles(arr)));
        Console.WriteLine();

        // Сортировка по году выпуска (используя IComparable)
        Array.Sort(arr);

        Console.WriteLine("Отсортированный массив по году выпуска:");
        foreach (var item in arr)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();

        // Бинарный поиск
        var searchItem = new Watch("Rolex", 2020);
        int index = Array.BinarySearch(arr, searchItem);
        Console.WriteLine($"\nИндекс найденного объекта: {index}");

        // Сортировка по бренду (используя IComparer)
        Array.Sort(arr, new WatchBrandComparer());

        Console.WriteLine("Отсортированный массив по бренду:");
        foreach (var item in arr)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();

    }
}