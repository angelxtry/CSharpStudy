using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileIOStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            FileIOSample fileIOTest = new FileIOSample();
            //fileIOTest.ReadLine();
            //fileIOTest.ReadAllLines();
            //fileIOTest.ReadLines();
            //fileIOTest.ReadFirstNLine(5);
            //fileIOTest.CountContainsKeywordLine("USD");
            //fileIOTest.ReadLineCondition();
            //fileIOTest.CheckCondition();
            //fileIOTest.AddLineNumber();
            //fileIOTest.WriteUsingStreamWriter();
            //fileIOTest.WriteAppend();
            //fileIOTest.WriteAllLines();
            //fileIOTest.WriteAllLinesCondition();
            //fileIOTest.AppendAllLines();
            //fileIOTest.AddDataAtOneLineOfFile();
            //fileIOTest.WriteSettingEncoding();
            //fileIOTest.CheckFileExist();
            //fileIOTest.CheckFileExistByFileInfoClass();
            //fileIOTest.DeleteFile();
            //fileIOTest.CopyFile();
            fileIOTest.CreateSubDirectory();
        }
    }
}
