using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LambdaAndLinqBasic
{
    class ToLookupSample2
    {
        public static void GroupingPackages()
        {
            List<Package> packages = new List<Package>
            {
                new Package { Company = "Coho Vineyard", 
                    Weight = 25.2, TrackingNumber = 89453312L },
                new Package { Company = "Lucerne Publishing", 
                    Weight = 18.7, TrackingNumber = 89112755L },
                new Package { Company = "Wingtip Toys", 
                    Weight = 6.0, TrackingNumber = 299456122L },
                new Package { Company = "Contoso Pharmaceuticals", 
                    Weight = 9.3, TrackingNumber = 670053128L },
                new Package { Company = "Wide World Importers", 
                    Weight = 33.8, TrackingNumber = 4665518773L }
            };

            /*
             * ToLookup의 리턴값이 ILookup이라는 것을 명확하게 보여준다.
             * 평소의 나라면 아무생각 없이 <string, string>을 사용했을텐데
             * 이 예제에서는 <char, string>을 사용했다.
             * 그러기위해 Convert.ToChar 메서드를 이용했다.
             * string을 남용하지말고 char를 사용하는 것도 항상 염두에 두자.
             */
            ILookup<char, string> lookup =
                packages
                .ToLookup(p => Convert.ToChar(p.Company.Substring(0, 1)),
                          p => p.Company + " " + p.TrackingNumber);

            /*
             * foreach문에서 dictionay를 KeyValuePair<>로 받는 것 처럼
             * ToLookup은 IGrouping<>으로 처리한다.
             */
            foreach (IGrouping<char, string> packageGroup in lookup)
            {
                Console.WriteLine(packageGroup.Key);
                foreach (string str in packageGroup)
                    Console.WriteLine("    {0}", str);
            }
        }
        /*
            C
                Coho Vineyard 89453312
                Contoso Pharmaceuticals 670053128
            L
                Lucerne Publishing 89112755
            W
                Wingtip Toys 299456122
                Wide World Importers 4665518773
         */
    }
}
