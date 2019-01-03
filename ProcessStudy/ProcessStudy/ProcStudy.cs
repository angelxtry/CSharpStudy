using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ProcessStudy
{
    class ProcStudy
    {
        public static void RunNotepad()
        {
            var path = @"%SystemRoot%\system32\notepad.exe";
            var fullpath = Environment.ExpandEnvironmentVariables(path);
            // Environment.ExpandEnvironmentVariables 메서드는
            // %SystemRoot%를 환경 변수가 나타내는 값으로 치환한다.
            Console.WriteLine(fullpath);
            Console.ReadLine();
            Process.Start(fullpath);
        }

        public static int RunAndWaitNotepad()
        {
            var path = @"%SystemRoot%\system32\notepad.exe";
            var fullpath = Environment.ExpandEnvironmentVariables(path);
            // Process.Start 메서드가 반환하는 객체에 WaitForExit 메서드를 호출한다.
            // 10000 밀리세컨드는 10초
            // 10초가 지나도 끝나지 않을 경우 TimeoutException
            using (var process = Process.Start(fullpath))
            {
                if (process.WaitForExit(10000))
                    return process.ExitCode;
                throw new TimeoutException();
            }
        }
    }
}
