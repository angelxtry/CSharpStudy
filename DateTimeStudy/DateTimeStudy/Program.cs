using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            var today = DateTime.Today;
            Console.WriteLine(today);

            var now = DateTime.Now;
            Console.WriteLine(now);

            // DateTime은 구조체
            // DateTime 구조체의 인스턴스를 생성
            // 년, 월, 일 or 년, 월, 일, 시, 분, 초가 필요
            var dt1 = new DateTime(2018, 12, 25);
            Console.WriteLine(dt1);
            var dt2 = new DateTime(2018, 12, 25, 13, 10, 10);
            Console.WriteLine(dt2);
            Console.ReadLine();
        }
    }
}
