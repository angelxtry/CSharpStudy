using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LambdaAndLinqBasic
{
    class ToDictionarySample
    {
        public static void ToDictionaryEx1()
        {
            List<Package> packages =
                new List<Package>
                {
                    new Package { Company = "Coho Vineyard", Weight = 25.2, TrackingNumber = 89453312L },
                    new Package { Company = "Lucerne Publishing", Weight = 18.7, TrackingNumber = 89112755L },
                    new Package { Company = "Wingtip Toys", Weight = 6.0, TrackingNumber = 299456122L },
                    new Package { Company = "Adventure Works", Weight = 33.8, TrackingNumber = 4665518773L },
                };

            /*
             * List<T>를 Dictionary로 변환했다.
             * ToDictionary 메서드에는 func를 전달하여 func의 리턴값이 Dictionary의 key가 된다.
             */
            Dictionary<long, Package> dictionary =
                packages.ToDictionary(p => p.TrackingNumber);

            foreach (KeyValuePair<long, Package> kvp in dictionary)
            {
                Console.WriteLine(
                    "Key {0}: {1}, {2} pounds",
                    kvp.Key,
                    kvp.Value.Company,
                    kvp.Value.Weight);
            }
        }
    }
}
