using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    internal class Product
    {
        public int ProCode { get; set; }

        public string ProName { get; set; }

        public string ProCategory { get; set; }

        public double ProMrp { get; set; }

        public List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product{ProCode=1001,ProName="Colgate-100gm",ProCategory="FMCG",ProMrp=55 },
                 new Product{ProCode=1002,ProName="Colgate-50gm",ProCategory="FMCG",ProMrp=30 },
                 new Product{ProCode=1009,ProName="DaburRed-100gm",ProCategory="FMCG",ProMrp=50 },
                 new Product{ProCode=1006,ProName="DaburRed-50gm",ProCategory="FMCG",ProMrp=28 },
                 new Product{ProCode=1008,ProName="Himalaya Neem Face Wash",ProCategory="FMCG",ProMrp=70 },
                 new Product{ProCode=1007,ProName="Niviea Face Wash",ProCategory="FMCG",ProMrp=120 },
                 new Product{ProCode=1010,ProName="Daawat-Basmati",ProCategory="Grain",ProMrp=130 },
                  new Product{ProCode=1011,ProName="Delhi Gate-Basmati",ProCategory="Grain",ProMrp=120 },
                  new Product{ProCode=1014,ProName="Saffola-Oil",ProCategory="Edible-Oil",ProMrp=160 },
                   new Product{ProCode=1016,ProName="Fortune-Oil",ProCategory="Edible-Oil",ProMrp=150 },
                   new Product{ProCode=1018,ProName="Nescafe",ProCategory="FMCG",ProMrp=70 },
                   new Product{ProCode=1019,ProName="Bru",ProCategory="FMCG",ProMrp=90},
                    new Product{ProCode=1015,ProName="Parachut",ProCategory="Edible-Oil",ProMrp=60}
            };

        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            Product product = new Product();
            var products = product.GetProducts();

            //1. Write a LINQ query to search and display all products with category “FMCG”.
            var problem1 = from x in products
                           where x.ProCategory == "FMCG"
                           select x;

            Console.WriteLine("Problem 1");
            foreach (var item in problem1)
            {
                Console.WriteLine($"{"Procode Code: " + item.ProCode} - {" Product Name: " + item.ProName} - {"Product MRP :" + item.ProMrp}");
            }

            //2. Write a LINQ query to search and display all products with category “Grain”.

            var problem2 = from x in products
                           where x.ProCategory == "Grain"
                           select x;
            Console.WriteLine("Problem 2");
            foreach (var item in problem2)
            {
                Console.WriteLine($"{"Procode Code: " + item.ProCode} - {" Product Name: " + item.ProName} - {"Product MRP :" + item.ProMrp}");
            }

            //3. Write a LINQ query to sort products in ascending order by product code.
            Console.WriteLine("Problem 3");
            var result = from x in products
                         orderby x.ProCode ascending
                         select x;
            foreach (var item in result)
            {
                Console.WriteLine("Procode Code: " + item.ProCode);

            }

            //4. Write a LINQ query to sort products in ascending order by product Category.

            Console.WriteLine("Problem 4");

            var problem4 = from x in products
                           orderby x.ProCategory ascending
                           select x;

            foreach(var item in problem4)
            {
                Console.WriteLine("ProCategory: "+ item.ProCategory);
            }

            //5. Write a LINQ query to sort products in ascending order by product Mrp.

            Console.WriteLine("Problem 5");
            var problem5 = from x in products
                           orderby x.ProMrp ascending
                           select x;
            foreach( var item in problem5)
            {
                Console.WriteLine("Product Mrp: " + item.ProMrp);
            }

            //6. Write a LINQ query to sort products in descending order by product Mrp.

            Console.WriteLine("Problem 6");

            var problem6 = from x in products
                           orderby x.ProMrp descending
                           select x;

            foreach (var item in problem6)
            {
                Console.WriteLine("Product Mrp: " + item.ProMrp);
            }


            //7. Write a LINQ query to display products group by product Category.

            Console.WriteLine("Problem 7");

            var problem7 = from x in products
                           group x by x.ProCategory;

            foreach (var group in problem7)
            {
                Console.WriteLine("Category: " + group.Key);
                foreach (var item in group)
                {
                    Console.WriteLine(item.ProName + " - " + item.ProMrp);
                }
            }


            //8. Write a LINQ query to display products group by product Mrp.

            Console.WriteLine("Problem 8");

            var problem8 = from x in products
                           group x by x.ProMrp;

            foreach (var group in problem8)
            {
                Console.WriteLine("MRP: " + group.Key);
                foreach (var item in group)
                {
                    Console.WriteLine(item.ProName);
                }
            }


            //9. Write a LINQ query to display product detail with highest price in FMCG category.

            Console.WriteLine("Problem 9");

            var problem9 = (from x in products
                            where x.ProCategory == "FMCG"
                            orderby x.ProMrp descending
                            select x).First();

            Console.WriteLine($"{problem9.ProCode} - {problem9.ProName} - {problem9.ProMrp}");


            //10. Write a LINQ query to display count of total products.

            Console.WriteLine("Problem 10");

            var problem10 = products.Count();

            Console.WriteLine("Total Products: " + problem10);


            //11. Write a LINQ query to display count of total products with category FMCG.

            Console.WriteLine("Problem 11");

            var problem11 = products.Count(x => x.ProCategory == "FMCG");

            Console.WriteLine("FMCG Count: " + problem11);


            //12. Write a LINQ query to display Max price.

            Console.WriteLine("Problem 12");

            var problem12 = products.Max(x => x.ProMrp);

            Console.WriteLine("Max Price: " + problem12);


            //13. Write a LINQ query to display Min price.

            Console.WriteLine("Problem 13");

            var problem13 = products.Min(x => x.ProMrp);

            Console.WriteLine("Min Price: " + problem13);


            //14. Write a LINQ query to display whether all products are below Mrp Rs.30 or not.

            Console.WriteLine("Problem 14");

            var problem14 = products.All(x => x.ProMrp < 30);

            Console.WriteLine("All products below 30: " + problem14);


            //15. Write a LINQ query to display whether any products are below Mrp Rs.30 or not.

            Console.WriteLine("Problem 15");

            var problem15 = products.Any(x => x.ProMrp < 30);

            Console.WriteLine("Any product below 30: " + problem15);

        }
    }
}
