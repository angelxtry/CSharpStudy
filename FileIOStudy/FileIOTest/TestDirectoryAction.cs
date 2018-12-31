using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using FileIOStudy;

namespace FileIOTest
{
    [TestClass]
    public class TestDirectoryAction
    {
        [TestMethod]
        public void TestDirectoryExist()
        {
            var srcPath = @"../../../src";
            var destPath = @"../../../dest";

            FileIOSample.CreateDirectory(srcPath);
            FileIOSample.CreateDirectory(destPath);

            Assert.AreEqual(Directory.Exists(srcPath), true);
            Assert.AreEqual(Directory.Exists(destPath), true);
        }

        [TestMethod]
        public void TestDirectoryCreate()
        {
            var srcPath = @"../../../src";
            var destPath = @"../../../dest";

            var directoryInfo = Directory.CreateDirectory(srcPath);
            Assert.AreEqual(directoryInfo is System.IO.DirectoryInfo, true);

            var dirInfo = new DirectoryInfo(destPath);
            Assert.AreEqual(dirInfo is System.IO.DirectoryInfo, true);
        }

        [TestMethod]
        public void TestSubDirectoryCreate()
        {
            var srcPath = @"../../../src";
            var directoryInfo = Directory.CreateDirectory(srcPath);
            Assert.AreEqual(directoryInfo is System.IO.DirectoryInfo, true);

            var subDirInfo = directoryInfo.CreateSubdirectory("temp");
            var tempPath = Path.Combine(srcPath, "temp");
            Assert.AreEqual(Directory.Exists(tempPath), true);
        }
    }
}
