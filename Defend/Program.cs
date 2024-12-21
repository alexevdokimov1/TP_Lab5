using Items;

public class Defend
{
    public static void Main()
    {
        List<Item> items =
           [
               new Item(1285, "помидоры", "красное", 250.0, "Помидорный завод \"Пимидор\"", new DateOnly(2024,11,25)),
                new Item(1850, "кактусы", "зелёные", 800.0, "Аранжирея №4", new DateOnly(2023,5,17)),
                new Item(780, "огурцы", "зелёные", 170.0, "Ферма \"Валера\"", new DateOnly(2024, 12, 01)),
                new Item(1653, "виноград", "чёрный", 230.0, "Ферма \"Игорь\"", new DateOnly(2025, 01, 01)),
                new Item(8965, "апельсины", "оранжевые", 300.0, "Ферма \"Тёмное место\"", new DateOnly(2024,12,3)),
                new Item(8965, "апельсины", "красное", 300.0, "Ферма \"Игоря\"", new DateOnly(2024, 12, 15)),
                new Item(8965, "вино", "красное", 27000.0, "Винзавод \"Сила Кота Бориса\"", new DateOnly(2019, 2, 10)),
                new Item(8965, "коньяк", "красное", 37000.0, "Винзавод \"Сила Кота Бориса\"", new DateOnly(2019, 2, 12))
           ];

        Console.WriteLine("Task 1");

        var mostPopularColor = items.GroupBy(item => item.Color).OrderBy(each => each.Count()).Last().Key;
        var task1 = items.Where(each => each.Color == mostPopularColor);

        foreach (var item in task1)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("Task 2");

        var mostPopularSup = items.GroupBy(item => item.Supplier).OrderBy(each => each.Count()).Last().Key;
        var mostPopularSupCount = items.GroupBy(item => item.Supplier).OrderBy(each => each.Count()).Last().Count();

        Console.WriteLine(mostPopularSup + " with count " + mostPopularSupCount);
    }
}