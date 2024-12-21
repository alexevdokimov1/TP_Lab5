using Items;
using System;
using System.Linq;
namespace UI
{
    public class UI
    {
        public static void Main()
        {
            List<Item> items =
            [
                new Item(1285, "помидоры", "красные", 250.0, "Помидорный завод \"Пимидор\"", new DateOnly(2024,11,25)),
                new Item(1850, "кактусы", "зелёные", 800.0, "Аранжирея №4", new DateOnly(2023,5,17)),
                new Item(780, "огурцы", "зелёные", 170.0, "Ферма \"Валера\"", new DateOnly(2024, 12, 01)),
                new Item(1653, "виноград", "чёрный", 230.0, "Ферма \"Игорь\"", new DateOnly(2025, 01, 01)),
                new Item(8965, "апельсины", "оранжевые", 300.0, "Ферма \"Тёмное место\"", new DateOnly(2024,12,3)),
                new Item(8965, "апельсины", "красные", 300.0, "Ферма \"Игоря\"", new DateOnly(2024, 12, 15)),
                new Item(8965, "вино", "красное", 27000.0, "Винзавод \"Сила Кота Бориса\"", new DateOnly(2019, 2, 10)),
                new Item(8965, "коньяк", "красное", 37000.0, "Винзавод \"Сила Кота Бориса\"", new DateOnly(2019, 2, 12))
            ];

            Console.WriteLine("#1_1 Сортировка по поставщику");

            var task1 = items.OrderBy(each =>  each.Supplier);
            
            foreach (var single in task1)
            {
                Console.WriteLine(single);
            }

            Console.WriteLine("#1_2 Сортировка по имени товара");
            var task1_2 = items.OrderBy(each => each.Name);

            foreach (var single in task1_2)
            {
                Console.WriteLine(single);
            }

            Console.WriteLine("#3 Вывести информацию о товарах конкретного поставщика.");
            Console.Write("Введите поставщика: ");
            string enteredSupplier = Console.ReadLine();
            var task2 = from single in items where single.Supplier == enteredSupplier select single;

            if (!task2.Any()) Console.WriteLine($"Нет товаров с {enteredSupplier}");

            foreach (var single in task2)
            {
                Console.WriteLine(single);
            }

            Console.WriteLine("#4 Три самых дорогих товара");

            var task3 = items.OrderByDescending(item => item.Cost).Take(3);

            foreach(var single in task3)
            {
                Console.WriteLine(single);
            }

            Console.WriteLine("#5 Товары, произведённые в этом году");

            var task4 = from single in items where single.ProductionDate.Year == DateTime.Now.Year select single;

            foreach (var single in task4)
            {
                Console.WriteLine(single);
            }

            Console.WriteLine("#6 Самый новый товар");

            var task5 = items.OrderBy(item => item.ProductionDate.Year).Last();
            Console.WriteLine(task5);

            Console.WriteLine("#7 Количество поставщиков с задданым товаром");
            Console.WriteLine("Введите имя товара");
            string enteredName = Console.ReadLine();
            var task6 = items.Where(item => item.Name == enteredName).Distinct().Count();
            Console.WriteLine("Количество поставщиков с заданным товаром " + task6);

            Console.WriteLine("#8 Вывести поставщиков, которые поставляют товары только дороже 10000.");
            var task7 = items.GroupBy(item => item.Supplier).Where(each => each.All(item => item.Cost > 10000));

            foreach (var each in task7)
            {
                Console.WriteLine($"Поставщик {each.Key}");
            }

            Console.WriteLine("#9 Вывести товары, которые либо не поставлялись в текущем году, либо их цена ниже средней цены всех товаров.");

            var task8 = items.Where(item => item.ProductionDate.Year != DateTime.Now.Year).Where(item => item.Cost < items.Average(item=>item.Cost));
            
            foreach (var each in task8)
            {
                Console.WriteLine(each);
            }

            Console.WriteLine("#10 Вывести полные наименования товаров в виде {Артикул} {Наименование} {Цвет}.");

            var task9 = items.Select(item => $"Артикул: {item.Articul} Наименование: {item.Name} Цвет: {item.Color}");

            foreach (var each in task9)
            {
                Console.WriteLine(each);
            }

            Console.WriteLine("#11 Вывести минимальную цену товара для каждого поставщика.");

            var task10 = items
            .GroupBy(item => item.Supplier)
            .Select(group => $"Поставщик: {group.Key} Минимальная цена: {group.Min(item => item.Cost)}");

            foreach (var each in task10)
            {
                Console.WriteLine(each);
            }
        }
    }
}