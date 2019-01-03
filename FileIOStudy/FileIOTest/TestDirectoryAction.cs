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

        [TestMethod]
        public void TestDirectoryDelete()
        {
            var srcPath = @"../../../src";
            Directory.CreateDirectory(srcPath);
            Directory.Delete(srcPath, recursive: true);
            Assert.AreEqual(Directory.Exists(srcPath), false);

            var destPath = @"../../../dest";
            var directoryInfo = Directory.CreateDirectory(destPath);
            directoryInfo.Delete(recursive: true);
            Assert.AreEqual(Directory.Exists(destPath), false);
        }

        [TestMethod]
        public void TestCurrentDirectory()
        {
            var currentDir = Directory.GetCurrentDirectory();
            var srcPath = @"../../../src";
            var dirInfo = Directory.CreateDirectory(srcPath);
            Directory.SetCurrentDirectory(srcPath);
            var newCurrentDir = Directory.GetCurrentDirectory();
            Assert.AreNotEqual(currentDir, newCurrentDir);
            Assert.AreEqual(newCurrentDir, dirInfo.FullName);
        }

        [TestMethod]
        public void TestGetDirectories()
        {
            var srcPath = @"../../../src";
            var directoryInfo = Directory.CreateDirectory(srcPath);
            var subDirChild1 = directoryInfo.CreateSubdirectory("Child1");
            var subDirDescendant1 = subDirChild1.CreateSubdirectory("Descendant1");
            var subDirDescendant2 = subDirChild1.CreateSubdirectory("Descendant2");
            var subDirDescendant3 = subDirChild1.CreateSubdirectory("Descendant3");
            var subDirChild1_1 = subDirChild1.CreateSubdirectory("Child1_1");
            var subDirChild1_2 = subDirChild1.CreateSubdirectory("Child1_2");
            var subDirChild2 = directoryInfo.CreateSubdirectory("Child2");

            DirectoryInfo[] srcUnderDirs = directoryInfo.GetDirectories();
            Assert.AreEqual(srcUnderDirs.Length, 2);

            DirectoryInfo[] subDirChild1Dirs = subDirChild1.GetDirectories();
            Assert.AreEqual(subDirChild1Dirs.Length, 5);

            DirectoryInfo[] subDirChild1DescDirs = subDirChild1.GetDirectories("D*");
            Assert.AreEqual(subDirChild1DescDirs.Length, 3);

            DirectoryInfo[] srcUnderAllDirs = directoryInfo.GetDirectories("*", SearchOption.AllDirectories);
            Assert.AreEqual(srcUnderAllDirs.Length, 7);
        }

        [TestMethod]
        public void TestEnumerateDirectories()
        {
            var srcPath = @"../../../src";
            var directoryInfo = Directory.CreateDirectory(srcPath);
            var subDirChild1 = directoryInfo.CreateSubdirectory("Child1");
            var subDirDescendant1 = subDirChild1.CreateSubdirectory("Descendant1");
            var subDirDescendant2 = subDirChild1.CreateSubdirectory("Descendant2");
            var subDirDescendant3 = subDirChild1.CreateSubdirectory("Descendant3");
            var subDirChild1_1 = subDirChild1.CreateSubdirectory("Child1_1");
            var subDirChild1_2 = subDirChild1.CreateSubdirectory("Child1_2");

            var srcUnderAllDirs = directoryInfo.EnumerateDirectories("*", SearchOption.AllDirectories);
            Assert.AreEqual(srcUnderAllDirs.Count(), 7);
            var dirStartWithD = srcUnderAllDirs.Where(d => d.Name.ToString().StartsWith("D"))
                                               .OrderBy(d => d.Name)
                                               .First();
            Assert.AreEqual(dirStartWithD.Name, "Descendant1");
        }

        [TestMethod]
        public void TestDirectoryGetFiles()
        {
            var srcPath = @"../../../src";
            var directoryInfo = Directory.CreateDirectory(srcPath);
            foreach (var i in Enumerable.Range(1, 10))
            {
                var fileName = "abc" + i + ".txt";
                FileIOSample.WriteUsingStreamWriter(Path.Combine(srcPath, fileName));
            }
            foreach (var i in Enumerable.Range(1, 5))
            {
                var fileName = "def" + i + ".txt";
                FileIOSample.WriteUsingStreamWriter(Path.Combine(srcPath, fileName));
            }
            FileInfo[] files = directoryInfo.GetFiles();
            Assert.AreEqual(files.Length, 15);

            FileInfo[] filesNameStartWithA = directoryInfo.GetFiles("a*", SearchOption.AllDirectories);
            Assert.AreEqual(filesNameStartWithA.Length, 10);
        }

        [TestMethod]
        public void TestDriectoryEnumerateFiles()
        {
            var srcPath = @"../../../src";
            var directoryInfo = Directory.CreateDirectory(srcPath);
            foreach (var i in Enumerable.Range(1, 10))
            {
                var fileName = "abc" + i + ".txt";
                FileIOSample.WriteUsingStreamWriter(Path.Combine(srcPath, fileName));
            }
            foreach (var i in Enumerable.Range(1, 5))
            {
                var fileName = "def" + i + ".txt";
                FileIOSample.WriteUsingStreamWriter(Path.Combine(srcPath, fileName));
            }

            var filesNameStartWithAandCount5 = directoryInfo.EnumerateFiles("a*", SearchOption.AllDirectories)
                                                            .Take(5);
            Assert.AreEqual(filesNameStartWithAandCount5.Count(), 5);
        }

        [TestMethod]
        public void TestGetFileSystemInfo()
        {
            var srcPath = @"../../../src";
            var directoryInfo = Directory.CreateDirectory(srcPath);
            var subDirChild1 = directoryInfo.CreateSubdirectory("Child1");
            var subDirDescendant1 = subDirChild1.CreateSubdirectory("Descendant1");
            var subDirDescendant2 = subDirChild1.CreateSubdirectory("Descendant2");
            var subDirDescendant3 = subDirChild1.CreateSubdirectory("Descendant3");
            var subDirChild1_1 = subDirChild1.CreateSubdirectory("Child1_1");
            var subDirChild1_2 = subDirChild1.CreateSubdirectory("Child1_2");
            foreach (var i in Enumerable.Range(1, 10))
            {
                var fileName = "abc" + i + ".txt";
                FileIOSample.WriteUsingStreamWriter(Path.Combine(srcPath, fileName));
            }
            foreach (var i in Enumerable.Range(1, 5))
            {
                var fileName = "def" + i + ".txt";
                FileIOSample.WriteUsingStreamWriter(Path.Combine(srcPath, fileName));
            }
            var fileSystems = directoryInfo.EnumerateFileSystemInfos("*", SearchOption.AllDirectories);
            var dirCount = fileSystems.Where(f => (f.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                                      .Count();
            Assert.AreEqual(dirCount, 7);
            var fileCount = fileSystems.Where(f => (f.Attributes & FileAttributes.Directory) != FileAttributes.Directory)
                                      .Count();
            Assert.AreEqual(fileCount, 15);
        }
    }
}
