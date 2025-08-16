using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_Activity_12
{

    class Product
    {
        public string Brand, Category, Color, Size, CustomCode;
        public int Year;

        public Product(string brand, string category, string color, string size, int year, string customCode)
        {
            Brand = brand;
            Category = category;
            Color = color;
            Size = size;
            Year = year;
            CustomCode = customCode;
        }

        public string GenerateSku()
        {
            string b = Brand.Substring(0, Math.Min(3, Brand.Length));
            string c = Category.Substring(0, Math.Min(3, Category.Length));
            string col = Color.Substring(0, Math.Min(3, Color.Length));
            string s = Size.Substring(0, Math.Min(2, Size.Length));
            string y = (Year % 100).ToString();
            string code = string.IsNullOrEmpty(CustomCode) ? "000" : CustomCode.ToUpper().Substring(0, Math.Min(3, CustomCode.Length));
            return (b + "-" + c + "-" + col + "-" + s + "-" + y + "-" + code).ToUpper();
        }
    }

    class Program
    {
        static void Main()
        {
            List<string> allowedCategories = new List<string> { "Shoes", "Shirt", "Pants" };
            List<string> allowedColors = new List<string> { "Red", "Blue", "Black" };

            Console.Write("Brand: ");
            string brand = Console.ReadLine();

            Console.Write("Category: ");
            string category = Console.ReadLine();
            if (!allowedCategories.Contains(category))
            {
                Console.WriteLine("Invalid category!");
                return;
            }

            Console.Write("Color: ");
            string color = Console.ReadLine();
            if (!allowedColors.Contains(color))
            {
                Console.WriteLine("Invalid color!");
                return;
            }

            Console.Write("Size: ");
            string size = Console.ReadLine();

            Console.Write("Year: ");
            int year;
            while (!int.TryParse(Console.ReadLine(), out year))
            {
                Console.Write("Invalid input. Please enter a valid year: ");
            }

            Console.Write("Custom Code (optional): ");
            string customCode = Console.ReadLine();

            Product p = new Product(brand, category, color, size, year, customCode);
            Console.WriteLine("Generated SKU: " + p.GenerateSku());
        }
    }
}

           