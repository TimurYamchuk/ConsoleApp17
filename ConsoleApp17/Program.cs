using System;
using System.Collections.Generic;
using System.Linq;

public class Good
{
    public int Id { get; set; }
    public string Title { get; set; }
    public double Price { get; set; }
    public string Category { get; set; }
}

class Program
{
    static void Main()
    {
        var goods = new List<Good>
        {
            new Good { Id = 1, Title = "Nokia 1100", Price = 450.99, Category = "Mobile" },
            new Good { Id = 2, Title = "Iphone 4", Price = 5000, Category = "Mobile" },
            new Good { Id = 3, Title = "Refregirator 5000", Price = 2555, Category = "Kitchen" },
            new Good { Id = 4, Title = "Mixer", Price = 150, Category = "Kitchen" },
            new Good { Id = 5, Title = "Magnitola", Price = 1499, Category = "Car" },
            new Good { Id = 6, Title = "Samsung Galaxy", Price = 3100, Category = "Mobile" },
            new Good { Id = 7, Title = "Auto Cleaner", Price = 2300, Category = "Car" },
            new Good { Id = 8, Title = "Owen", Price = 700, Category = "Kitchen" },
            new Good { Id = 9, Title = "Siemens Turbo", Price = 3199, Category = "Mobile" },
            new Good { Id = 10, Title = "Lighter", Price = 150, Category = "Car" }
        };

        // 1. Товары категории Mobile с ценой > 1000
        var mobiles = goods.Where(g => g.Category == "Mobile" && g.Price > 1000);
        Console.WriteLine("Mobile > 1000:");
        mobiles.ToList().ForEach(g => Console.WriteLine($"{g.Title}: {g.Price}"));

        // 2. Товары не из Kitchen с ценой > 1000
        var notKitchen = goods.Where(g => g.Category != "Kitchen" && g.Price > 1000)
                               .Select(g => $"{g.Title}: {g.Price}");
        Console.WriteLine("\nNot Kitchen > 1000:");
        notKitchen.ToList().ForEach(Console.WriteLine);

        // 3. Средняя цена
        Console.WriteLine($"\nAverage Price: {goods.Average(g => g.Price):F2}");

        // 4. Уникальные категории
        Console.WriteLine("\nCategories:");
        goods.Select(g => g.Category).Distinct().ToList().ForEach(Console.WriteLine);

        // 5. Товары в алфавитном порядке
        Console.WriteLine("\nSorted Goods:");
        goods.OrderBy(g => g.Title)
             .ToList()
             .ForEach(g => Console.WriteLine($"{g.Title}: {g.Category}"));

        // 6. Сумма товаров Car и Mobile
        Console.WriteLine($"\nTotal Car and Mobile: {goods.Count(g => g.Category == "Car" || g.Category == "Mobile")}");

        // 7. Количество товаров в каждой категории
        Console.WriteLine("\nCategory Counts:");
        goods.GroupBy(g => g.Category)
             .ToList()
             .ForEach(g => Console.WriteLine($"{g.Key}: {g.Count()}"));
    }
}
