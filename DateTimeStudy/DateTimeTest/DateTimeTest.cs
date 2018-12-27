using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace DateTimeTest
{
    [TestClass]
    public class DateTimeTest
    {
        [TestMethod]
        public void TestDateTimeAttribute()
        {
            var dt = new DateTime(2018, 12, 25, 13, 10, 10);
            Assert.AreEqual(dt.Year, 2018);
            Assert.AreEqual(dt.Month, 12);
            Assert.AreEqual(dt.Day, 25);
            Assert.AreEqual(dt.Hour, 13);
            Assert.AreEqual(dt.Minute, 10);
            Assert.AreEqual(dt.Second, 10);
            Assert.AreEqual(dt.Millisecond, 0);
        }

        [TestMethod]
        public void TestDateTimeDayOfWeek()
        {
            var dt = new DateTime(2018, 12, 25);
            DayOfWeek dayOfWeek = dt.DayOfWeek;
            Assert.AreEqual(DayOfWeek.Tuesday, dayOfWeek);

            var dt2 = new DateTime(2018, 12, 25);
            DayOfWeek dayOfWeek2 = dt2.DayOfWeek;
            Assert.AreEqual(DayOfWeek.Tuesday, dayOfWeek2);
        }

        [TestMethod]
        public void TestDateTimeLeapYear()
        {
            var isLeapYear = DateTime.IsLeapYear(2018);
            Assert.AreEqual(isLeapYear, false);

            isLeapYear = DateTime.IsLeapYear(2016);
            Assert.AreEqual(isLeapYear, true);
        }

        [TestMethod]
        public void TestDateTimeTryParse()
        {
            DateTime dt;
            var isBool = DateTime.TryParse("20181225", out dt);
            Assert.AreEqual(isBool, false);

            isBool = DateTime.TryParse("2018/12/25", out dt);
            Assert.AreEqual(isBool, true                                     );
            Assert.AreEqual(dt, new DateTime(2018, 12, 25));
        }

        [TestMethod]
        public void TestDateTimeParse()
        {
            try
            {
                DateTime dt = DateTime.Parse("20181215");
            }
            catch(FormatException)
            {
            }
        }

        [TestMethod]
        public void TestDateTimeFormat()
        {
            var dt = new DateTime(2018, 12, 25);
            Assert.AreEqual(dt.ToString("d"), "2018-12-25");
            Assert.AreEqual(dt.ToString("yyyyMMdd"), "20181225");

            var dt2 = new DateTime(2018, 12, 25, 13, 10, 10);
            Assert.AreEqual(dt2.ToString("T"), "오후 1:10:10");
            Assert.AreEqual(dt2.ToString("HHmmss"), "131010");
        }

        [TestMethod]
        public void TestGetDayName()
        {
            var dt = new DateTime(2018, 12, 25);
            // using System.Globalization;
            var culture = new CultureInfo("ko-KR");
            culture.DateTimeFormat.Calendar = new KoreanCalendar();
            var dayOfWeek = culture.DateTimeFormat.GetDayName(dt.DayOfWeek);
            Assert.AreEqual(dayOfWeek, "화요일");
            var dayOfWeekShort = culture.DateTimeFormat.GetShortestDayName(dt.DayOfWeek);
            Assert.AreEqual(dayOfWeekShort, "화");
        }

        [TestMethod]
        public void TestDateTimeCompare()
        {
            var dt1 = new DateTime(2018, 12, 25, 13, 10, 10);
            var dt2 = new DateTime(2018, 12, 25, 14, 10, 10);
            Assert.AreEqual(dt2 > dt1, true);
            Assert.AreEqual(dt2.Date > dt1.Date, false);
            Assert.AreEqual(dt2.Date == dt1.Date, true);
            Assert.AreEqual(dt2.Date, new DateTime(2018, 12, 25));
            // 날짜만 비교해야 할 때 어렵게 처리하지 말자.
        }
    }
}
