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
    public class TestFileAction
    {
        [TestMethod]
        public void TestFileMove()
        {
            var srcPath = @"../../../src";
            var destPath = @"../../../dest";

            FileIOSample.CreateDirectory(srcPath);
            FileIOSample.CreateDirectory(destPath);

            var fileName = "SampleWriteFile.TXT";
            var srcFilePath = Path.Combine(srcPath, fileName);
            var destFilePath = Path.Combine(destPath, fileName);

            File.Delete(srcFilePath);
            File.Delete(destFilePath);

            FileIOSample.WriteUsingStreamWriter(srcFilePath);
            Assert.AreEqual(File.Exists(srcFilePath), true);

            File.Move(srcFilePath, destFilePath);
        }

        [TestMethod]
        public void TestFileMoveByFileInfo()
        {
            var srcPath = @"../../../src";
            var destPath = @"../../../dest";

            FileIOSample.CreateDirectory(srcPath);
            FileIOSample.CreateDirectory(destPath);

            var fileName = "SampleWriteFile.TXT";
            var srcFilePath = Path.Combine(srcPath, fileName);
            var destFilePath = Path.Combine(destPath, fileName);
            
            File.Delete(srcFilePath);
            File.Delete(destFilePath);

            FileIOSample.WriteUsingStreamWriter(srcFilePath);
            Assert.AreEqual(File.Exists(srcFilePath), true);

            var fileInfo = new FileInfo(srcFilePath);
            fileInfo.MoveTo(destFilePath);
            Assert.AreEqual(File.Exists(destFilePath), true);
        }

        [TestMethod]
        public void TestLastModifiedTime()
        {
            var srcPath = @"../../../src";
            var destPath = @"../../../dest";

            FileIOSample.CreateDirectory(srcPath);
            FileIOSample.CreateDirectory(destPath);

            var fileName = "SampleWriteFile.TXT";
            var srcFilePath = Path.Combine(srcPath, fileName);
            var destFilePath = Path.Combine(destPath, fileName);

            File.Delete(srcFilePath);
            File.Delete(destFilePath);

            FileIOSample.WriteUsingStreamWriter(srcFilePath);
            FileIOSample.WriteUsingStreamWriter(destFilePath);

            var lastWriteTime = File.GetLastWriteTime(srcFilePath);
            File.SetLastWriteTime(destFilePath, lastWriteTime);

            Assert.AreEqual(File.GetLastWriteTime(srcFilePath), File.GetLastWriteTime(destFilePath));
        }

        [TestMethod]
        public void TestFileSize()
        {
            var srcPath = @"../../../src";
            var destPath = @"../../../dest";

            FileIOSample.CreateDirectory(srcPath);
            FileIOSample.CreateDirectory(destPath);

            var fileName = "SampleWriteFile.TXT";
            var srcFilePath = Path.Combine(srcPath, fileName);
            var destFilePath = Path.Combine(destPath, fileName);

            File.Delete(srcFilePath);
            File.Delete(destFilePath);

            FileIOSample.WriteUsingStreamWriter(srcFilePath);
            FileIOSample.WriteUsingStreamWriter(destFilePath);
            var fileInfo = new FileInfo(srcFilePath);
            long size = fileInfo.Length;
        }
    }
}
