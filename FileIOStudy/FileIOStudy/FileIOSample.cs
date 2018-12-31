using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileIOStudy
{
    public class FileIOSample
    {
        public void ReadLine()
        {
            var filePath = @"../../SampleData.TXT";
            if (File.Exists(filePath))
            {
                //using (var reader = new StreamReader(filePath, Encoding.UTF8))
                using (var reader = new StreamReader(filePath, Encoding.GetEncoding("euc-kr")))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        Console.WriteLine(line);
                    }
                }
            }
            Console.ReadLine();
        }

        public void ReadAllLines()
        {
            var filePath = @"../../SampleData.TXT";
            var lines = File.ReadAllLines(filePath, Encoding.GetEncoding("euc-kr"));
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine(lines.GetType());
            Console.ReadLine();
        }

        public void ReadLines()
        {
            var filePath = @"../../SampleData.TXT";
            var lines = File.ReadLines(filePath, Encoding.GetEncoding("euc-kr"));
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine(lines.GetType());
            Console.ReadLine();
        }

        public void ReadFirstNLine(int numberOfLine)
        {
            var filePath = @"../../SampleData.TXT";
            var lines = File.ReadLines(filePath, Encoding.GetEncoding("euc-kr"))
                            .Take(numberOfLine);
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine(lines.GetType());
            Console.ReadLine();
        }

        public void CountContainsKeywordLine(string keyword)
        {
            // 단어를 count하는 것이 아니라 line을 count한다.
            var filePath = @"../../SampleData.TXT";
            var count = File.ReadLines(filePath, Encoding.GetEncoding("euc-kr"))
                            .Count(s => s.Contains(keyword));
            Console.WriteLine(keyword + ": " + count);
            Console.ReadLine();
        }

        public void ReadLineCondition()
        {
            var filePath = @"../../SampleData.TXT";
            var lines = File.ReadLines(filePath, Encoding.GetEncoding("euc-kr"))
                            .Where(s => s.Contains("USD"));
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
            Console.ReadLine();
        }

        public void CheckCondition()
        {
            var filePath = @"../../SampleData.TXT";
            var exist = File.ReadLines(filePath, Encoding.GetEncoding("euc-kr"))
                            .Any(s => s.Contains("USD"));
            if (exist)
                Console.WriteLine("True");
            else
                Console.WriteLine("False");
            Console.ReadLine();
        }

        public void AddLineNumber()
        {
            var filePath = @"../../SampleData.TXT";
            var lines = File.ReadLines(filePath, Encoding.GetEncoding("euc-kr"))
                            .Select((s, index) => string.Format("{0, 4}: {1}", index + 1, s));
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
            Console.ReadLine();
        }

        public static void WriteUsingStreamWriter(string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine("에베베베베베베");
                writer.WriteLine("원");
                writer.WriteLine("둘");
                writer.WriteLine("3");
                writer.WriteLine("넷");
            }
        }

        public void WriteAppend()
        {
            var lines = new[] { "====", "다섯", "6" };
            var filePath = @"../../SampleWriteFile.TXT";
            using (var writer = new StreamWriter(filePath, append: true))
            {
                foreach (var line in lines)
                {
                    writer.WriteLine(line);
                }
            }
        }

        public void WriteAllLines()
        {
            var lines = new List<string>
            {
                "Seoul",
                "New Delhi",
                "Bangkok",
                "London",
                "Paris",
            };
            var filePath = @"../../Cities.txt";
            File.WriteAllLines(filePath, lines);
            // WriteAllLines의 return은 IEnumerable
        }

        public void WriteAllLinesCondition()
        {
            var names = new List<string>
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
            var filePath = @"../../Over5CharactersCitis.txt";
            File.WriteAllLines(filePath, names.Where(c => c.Length > 5));
        }

        public void AppendAllLines()
        {
            var names = new List<string>
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
            var filePath = @"../../Over5CharactersCitis.txt";
            File.AppendAllLines(filePath, names.Where(c => c.Length > 7));
        }

        public void AddDataAtOneLineOfFile()
        {
            /*
             * 파일을 모두 읽고 나서 일단 파일을 닫고 파일을 다시 쓰기 전용으로 열어서 행을 삽입해도 된다.
             * 파일에 여러 프로세스가 접근할 경우 닫기와 열기 사이에 다른 프로세스가 작업할 가능성이 있다.
             */
            var filePath = @"../../SampleWriteFile.TXT";
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
            {
                using (var reader = new StreamReader(stream))
                using (var writer = new StreamWriter(stream))
                {
                    string texts = reader.ReadToEnd();
                    stream.Position = 0;
                    writer.WriteLine("Insert New Line 1.");
                    writer.WriteLine("Insert New Line 2.");
                    writer.Write(texts);
                }
            }
        }

        public void WriteSettingEncoding()
        {
            var filePath = @"../../EucKrEncoding.txt";
            var euckr = Encoding.GetEncoding("euc-kr");
            using (var writer = new StreamWriter(filePath, append: false, encoding: euckr))
            {
                writer.WriteLine("euc-kr encoding");
            }
        }

        public void CheckFileExist()
        {
            var filePath = @"../../SampleWriteFile.TXT";
            WriteUsingStreamWriter(filePath);
            if (File.Exists(filePath))
            {
                Console.WriteLine("File Exist.");
            }
            Console.ReadLine();
        }

        public void CheckFileExistByFileInfoClass()
        {
            var filePath = @"../../SampleWriteFile.TXT";
            WriteUsingStreamWriter(filePath);
            var fileInfo = new FileInfo(filePath);
            if (fileInfo.Exists)
            {
                Console.WriteLine("File Exist.");
            }
            Console.ReadLine();
        }

        public void DeleteFile()
        {
            var filePath = @"../../SampleWriteFile.TXT";
            File.Delete(filePath);

            var fileInfor = new FileInfo(filePath);
            fileInfor.Delete();
        }

        public void CopyFile()
        {
            var filePath = @"../../SampleWriteFile.TXT";
            WriteUsingStreamWriter(filePath);
            var resultPath = filePath + "_backup";
            //File.Copy(filePath, resultPath);
            File.Copy(filePath, resultPath, overwrite: true);
        }

        public static void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        public void CreateSubDirectory()
        {
            var srcPath = @"../../src";
            var directoryInfo = Directory.CreateDirectory(srcPath);

            var subDirInfo = directoryInfo.CreateSubdirectory("temp");
        }
    }
}
