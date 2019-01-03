using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLambdaAndLinq
{
    [TestClass]
    public class LambdaAndLinqTest
    {
        public IEnumerable<string> GetListData()
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

        [TestMethod]
        public void TestExists()
        {
            var list = GetListData() as List<string>;
            var exists = list.Exists(s => s[0] == 'S');
            Assert.AreEqual(exists, true);

            var exists2 = list.Exists(s => s.StartsWith("S"));
            Assert.AreEqual(exists2, true);
        }

        [TestMethod]
        public void TestFind()
        {
            var list = GetListData() as List<string>;
            var name = list.Find(s => s.Length == 5);
            Assert.AreEqual(name, "Seoul");
        }

        [TestMethod]
        public void TestFindIndex()
        {
            var list = GetListData() as List<string>;
            var index = list.FindIndex(s => s.Length == 5);
            Assert.AreEqual(index, 0);
        }

        [TestMethod]
        public void TestFindAll()
        {
            var list = GetListData() as List<string>;
            var names = list.FindAll(s => s.Length == 5);
            Assert.AreEqual(names.Count(), 2);

            Assert.AreEqual(list.FindAll(s => s.Contains(' ')).Count(), 2);
        }

        public string[] GetArrayData()
        {
            return new string[]
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

        [TestMethod]
        public void TestFindAllInArray()
        {
            string[] arrayData = GetArrayData();
            string[] fiveCharCities = Array.FindAll(arrayData, s => s.Length <= 5);
            Assert.AreEqual(fiveCharCities.Length, 2);
        }
    }
}
