using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LambdaAndLinqBasic
{
    class Program
    {
        static void Main(string[] args)
        {
            Lookup();
            Console.ReadLine();
        }

        private static void Lookup()
        {
            var cities = GetListData();
            var lookup = cities.ToLookup(city => city.Length)
                               .OrderBy(city => city.Key);
            foreach (var group in lookup)
            {
                Console.WriteLine("Key: " + group.Key);
                foreach (var city in group)
                {
                    Console.WriteLine(city);
                }
            }
        }

        public static IEnumerable<string> GetListData()
        {
            return new List<string>
            {
                "Seoul",
                "New Delhi",
                "Bangkok",
                "London",
                "Paris",
                "Berlin",
                "Canberra",
                "Hong Kong",
            };
        }
    }
}
