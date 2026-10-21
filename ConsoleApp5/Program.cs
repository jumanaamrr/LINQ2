using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqAllTasksDemo
{
    // ---------- Models ----------
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public bool Discontinued { get; set; }
    }

    public class Customer
    {
        public int CustomerID { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public decimal TotalOrderValue { get; set; }
    }

    internal class Program
    {
        // ---------- Seed data ----------
        private static readonly List<Product> ProductList = new List<Product>
        {
            new Product { ProductID = 1,  ProductName = "Ikura",             Category = "Seafood",      UnitPrice = 31.00m, UnitsInStock = 31 },
            new Product { ProductID = 2,  ProductName = "Konbu",            Category = "Seafood",      UnitPrice = 6.00m,  UnitsInStock = 24 },
            new Product { ProductID = 3,  ProductName = "Carnarvon Tigers", Category = "Seafood",      UnitPrice = 62.50m, UnitsInStock = 42 },
            new Product { ProductID = 4,  ProductName = "Boston Crab Meat", Category = "Seafood",      UnitPrice = 18.40m, UnitsInStock = 123 },
            new Product { ProductID = 5,  ProductName = "Nord-Ost Matjeshering", Category = "Seafood", UnitPrice = 25.89m, UnitsInStock = 10 },
            new Product { ProductID = 6,  ProductName = "Chai",             Category = "Beverages",    UnitPrice = 18.00m, UnitsInStock = 39 },
            new Product { ProductID = 7,  ProductName = "Chang",            Category = "Beverages",    UnitPrice = 19.00m, UnitsInStock = 17 },
            new Product { ProductID = 8,  ProductName = "Aniseed Syrup",    Category = "Condiments",   UnitPrice = 10.00m, UnitsInStock = 13 },
            new Product { ProductID = 9,  ProductName = "Chef Anton's Cajun Seasoning", Category = "Condiments", UnitPrice = 22.00m, UnitsInStock = 53 },
            new Product { ProductID = 10, ProductName = "Grandma's Boysenberry Spread", Category = "Condiments", UnitPrice = 25.00m, UnitsInStock = 0  },
            new Product { ProductID = 11, ProductName = "Sir Rodney's Marmalade",        Category = "Confections", UnitPrice = 81.00m, UnitsInStock = 40 },
            new Product { ProductID = 12, ProductName = "Pavlova",          Category = "Confections",  UnitPrice = 17.45m, UnitsInStock = 29 },
            new Product { ProductID = 13, ProductName = "Alice Mutton",     Category = "Meat/Poultry", UnitPrice = 39.00m, UnitsInStock = 0  },
            new Product { ProductID = 14, ProductName = "Mishi Kobe Niku",  Category = "Meat/Poultry", UnitPrice = 97.00m, UnitsInStock = 29 },
            new Product { ProductID = 15, ProductName = "Tofu",             Category = "Produce",      UnitPrice = 23.25m, UnitsInStock = 35 },
            new Product { ProductID = 16, ProductName = "Pâté chinois",     Category = "Meat/Poultry", UnitPrice = 24.00m, UnitsInStock = 48 },
            new Product { ProductID = 17, ProductName = "Côte de Blaye",    Category = "Beverages",    UnitPrice = 263.50m, UnitsInStock = 17 },
            new Product { ProductID = 18, ProductName = "Chartreuse verte", Category = "Beverages",    UnitPrice = 18.00m, UnitsInStock = 57 },
            new Product { ProductID = 19, ProductName = "Longlife Tofu",    Category = "Produce",      UnitPrice = 10.00m, UnitsInStock = 4  },
            new Product { ProductID = 20, ProductName = "Manjimup Dried Apples", Category = "Produce", UnitPrice = 53.00m, UnitsInStock = 20 },
            new Product { ProductID = 21, ProductName = "Sir Rodney's Scones",   Category = "Confections", UnitPrice = 10.00m, UnitsInStock = 3 },
        };

        private static readonly List<Customer> CustomerList = new List<Customer>
        {
            new Customer { CustomerID = 1, CompanyName = "Alfreds Futterkiste",  Country = "Germany", TotalOrderValue = 1234.50m },
            new Customer { CustomerID = 2, CompanyName = "Ana Trujillo Emparedados", Country = "Mexico", TotalOrderValue = 890.00m },
            new Customer { CustomerID = 3, CompanyName = "Antonio Moreno Taquería", Country = "Mexico", TotalOrderValue = 2200.75m },
            new Customer { CustomerID = 4, CompanyName = "Around the Horn",      Country = "UK",      TotalOrderValue = 450.00m },
            new Customer { CustomerID = 5, CompanyName = "Berglunds snabbköp",   Country = "Sweden",  TotalOrderValue = 3100.00m },
            new Customer { CustomerID = 6, CompanyName = "Blauer See Delikatessen", Country = "Germany", TotalOrderValue = 780.25m },
            new Customer { CustomerID = 7, CompanyName = "Bon app'",             Country = "France",  TotalOrderValue = 1650.00m },
            new Customer { CustomerID = 8, CompanyName = "Bottom-Dollar Markets", Country = "Canada", TotalOrderValue = 980.10m },
        };

        private static void Main()
        {
            // 1. Top 3 most expensive products
            Console.WriteLine("=== 1. Top 3 most expensive ===");
            var top3 = ProductList.OrderByDescending(p => p.UnitPrice).Take(3);
            foreach (var p in top3) Console.WriteLine($"{p.ProductName} - {p.UnitPrice:C}");

            // 2. Page 2, page size 5
            Console.WriteLine("\n=== 2. Page 2 (page size 5) ===");
            var page2 = ProductList.OrderBy(p => p.ProductID).Skip(5).Take(5);
            foreach (var p in page2) Console.WriteLine($"{p.ProductID}: {p.ProductName}");

            // 3. Take while UnitPrice < 25 (ordered by price)
            Console.WriteLine("\n=== 3. TakeWhile UnitPrice < 25 (ordered by price) ===");
            var takeWhile = ProductList.OrderBy(p => p.UnitPrice).TakeWhile(p => p.UnitPrice < 25m);
            foreach (var p in takeWhile) Console.WriteLine($"{p.ProductName} - {p.UnitPrice:C}");

            // 4. ALL Seafood in stock?
            Console.WriteLine("\n=== 4. All Seafood in stock? ===");
            bool allSeafoodInStock = ProductList.Where(p => p.Category == "Seafood").All(p => p.UnitsInStock > 0);
            Console.WriteLine(allSeafoodInStock);

            // 5. ID list contains 9?
            Console.WriteLine("\n=== 5. ids contains 9? ===");
            int[] ids = { 3, 9, 13, 18 };
            Console.WriteLine(ids.Contains(9));

            // 6. Group by Category with count
            Console.WriteLine("\n=== 6. Group by Category with count ===");
            var groups = ProductList.GroupBy(p => p.Category);
            foreach (var g in groups) Console.WriteLine($"{g.Key}: {g.Count()}");

            // 7. Group by Category, project names only
            Console.WriteLine("\n=== 7. Group by Category, names only ===");
            var groupNames = ProductList.GroupBy(p => p.Category)
                                        .Select(g => new { Category = g.Key, Names = g.Select(p => p.ProductName).ToList() });
            foreach (var g in groupNames)
                Console.WriteLine($"{g.Category}: {string.Join(", ", g.Names)}");

            // 8. Categories with MORE THAN 3 products
            Console.WriteLine("\n=== 8. Categories with > 3 products ===");
            var bigCats = ProductList.GroupBy(p => p.Category)
                                     .Where(g => g.Count() > 3)
                                     .Select(g => g.Key);
            foreach (var c in bigCats) Console.WriteLine(c);

            // 9. QUERY SYNTAX: group customers by Country -> {Country, Count, TotalOrderValue}
            Console.WriteLine("\n=== 9. Customers by Country (query syntax) ===");
            var countryStats =
                from c in CustomerList
                group c by c.Country into g
                select new
                {
                    Country = g.Key,
                    Count = g.Count(),
                    TotalOrderValue = g.Sum(x => x.TotalOrderValue)
                };
            foreach (var s in countryStats)
                Console.WriteLine($"{s.Country}: {s.Count} customers, total = {s.TotalOrderValue:C}");

            // 10. Total units in stock
            Console.WriteLine("\n=== 10. Total units in stock ===");
            Console.WriteLine(ProductList.Sum(p => p.UnitsInStock));

            // 11. Cheapest and most expensive prices
            Console.WriteLine("\n=== 11. Cheapest and most expensive ===");
            Console.WriteLine($"Min = {ProductList.Min(p => p.UnitPrice):C}, Max = {ProductList.Max(p => p.UnitPrice):C}");

            // 12. Distinct categories
            Console.WriteLine("\n=== 12. Distinct categories ===");
            foreach (var c in ProductList.Select(p => p.Category).Distinct())
                Console.WriteLine(c);

            // 13. IDs in setA but not in setB
            Console.WriteLine("\n=== 13. setA except setB ===");
            int[] setA = { 1, 3, 5, 7, 9, 11, 13 };
            int[] setB = { 3, 6, 9, 12, 15, 13 };
            foreach (var id in setA.Except(setB)) Console.WriteLine(id);

            // 14. Countries in list1 but not in list2 (case-insensitive)
            Console.WriteLine("\n=== 14. list1 except list2 (case-insensitive) ===");
            string[] list1 = { "Germany", "France", "UK", "Spain" };
            string[] list2 = { "france", "SPAIN", "Italy" };
            var onlyIn1 = list1.Except(list2, StringComparer.OrdinalIgnoreCase);
            foreach (var s in onlyIn1) Console.WriteLine(s);

            // 15. Dictionary<int, Product> keyed by ProductID; retrieve ID = 18
            Console.WriteLine("\n=== 15. Dictionary lookup ProductID = 18 ===");
            var dict = ProductList.ToDictionary(p => p.ProductID);
            var p18 = dict[18];
            Console.WriteLine($"{p18.ProductID}: {p18.ProductName} - {p18.UnitPrice:C}");

            // 16. First product with price > 50
            Console.WriteLine("\n=== 16. First product price > 50 ===");
            var firstOver50 = ProductList.First(p => p.UnitPrice > 50m);
            Console.WriteLine($"{firstOver50.ProductName} - {firstOver50.UnitPrice:C}");

            // 17. First product with price > 500 -> null (no throw)
            Console.WriteLine("\n=== 17. FirstOrDefault price > 500 ===");
            var tooExpensive = ProductList.FirstOrDefault(p => p.UnitPrice > 500m);
            Console.WriteLine(tooExpensive == null ? "null" : tooExpensive.ProductName);

            // 18. Multiplication table row for 7
            Console.WriteLine("\n=== 18. Multiplication table row for 7 ===");
            var row7 = Enumerable.Range(1, 10).Select(i => $"{7} x {i} = {7 * i}");
            foreach (var s in row7) Console.WriteLine(s);

            // 19. Even numbers between 1 and 30
            Console.WriteLine("\n=== 19. Even numbers 1..30 ===");
            var evens = Enumerable.Range(1, 30).Where(n => n % 2 == 0);
            Console.WriteLine(string.Join(", ", evens));

            // 20. Concatenate first 3 product names with first 3 customer company names
            Console.WriteLine("\n=== 20. Concat first 3 names ===");
            var combined = ProductList.Take(3).Select(p => p.ProductName)
                            .Concat(CustomerList.Take(3).Select(c => c.CompanyName));
            foreach (var s in combined) Console.WriteLine(s);

            // 21. Pair each product with a customer (by position)
            Console.WriteLine("\n=== 21. Pair product with customer by position ===");
            var pairs = ProductList.Zip(CustomerList,
                (p, c) => $"{p.ProductName} sold to {c.CompanyName}");
            foreach (var s in pairs) Console.WriteLine(s);

            Console.WriteLine("\n--- Done. ---");
        }
    }
}