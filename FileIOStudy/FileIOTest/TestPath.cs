using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace FileIOTest
{
    [TestClass]
    public class TestPath
    {
        [TestMethod]
        public void TestGetFileName()
        {
            var path = @"C:\Program Files\Microsoft Office\Office16\EXCEL.EXE";
            var fileName = Path.GetFileName(path);
            Assert.AreEqual(fileName, "EXCEL.EXE");
        }

        [TestMethod]
        public void TestGetDirectoryName()
        {
            var path = @"C:\Program Files\Microsoft Office\Office16\EXCEL.EXE";
            var dirName = Path.GetDirectoryName(path);
            Assert.AreEqual(dirName, @"C:\Program Files\Microsoft Office\Office16");
        }

        [TestMethod]
        public void TestGetExtension()
        {
            var path = @"C:\Program Files\Microsoft Office\Office16\EXCEL.EXE";
            var dirName = Path.GetExtension(path);
            Assert.AreEqual(dirName, ".EXE");
        }

        [TestMethod]
        public void TestGetFileNameWithoutExtension()
        {
            var path = @"C:\Program Files\Microsoft Office\Office16\EXCEL.EXE";
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
            Assert.AreEqual(fileNameWithoutExtension, "EXCEL");
        }

        [TestMethod]
        public void TestGetPathRoow()
        {
            var path = @"C:\Program Files\Microsoft Office\Office16\EXCEL.EXE";
            var pathRoot = Path.GetPathRoot(path);
            Assert.AreEqual(pathRoot, @"C:\");
        }

        [TestMethod]
        public void TestGetAbPath()
        {
            var path = @"../../../";
            var fullPath = Path.GetFullPath(path);
        }
    }
}
