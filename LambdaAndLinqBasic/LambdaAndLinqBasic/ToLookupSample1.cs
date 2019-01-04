using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LambdaAndLinqBasic
{
    class ToLookupSample1
    {
        /*
         * ToLookup 메서드는 SQL의 GROUP BY와 비슷한 느낌이다.
         */
        public static void Lookup()
        {
            var cities = GetListData();
            var lookup = cities.ToLookup(city => city.Length)
                               .OrderBy(city => city.Key);
            foreach (var group in lookup)
            {
                Console.WriteLine("Key: " + group.Key);
                foreach (var city in group)
                {
                    Console.WriteLine("    {0}", city);
                }
            }
        }

        private static IEnumerable<string> GetListData()
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

    /*
        Key: 5
            Seoul
            Paris
        Key: 6
            London
            Berlin
        Key: 7
            Bangkok
        Key: 8
            Canberra
        Key: 9
            New Delhi
            Hong Kong
     */
}
