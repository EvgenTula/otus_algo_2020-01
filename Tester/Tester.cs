using System;
using System.Diagnostics;
using System.IO;

namespace SimpleTester
{
    public class Tester
    {
        private Task _task;
        private string _path;
        public Tester(Task task, string path)
        {
            this._task = task;
            this._path = path;
        }

        public void RunTests(String testName)
        {
            int num = 0;
            
            Console.WriteLine($"==={testName}===");

            File.AppendAllText(this._path + "\\Result.md", $"<table border=\"1\">\n");
            File.AppendAllText(this._path + "\\Result.md", $"<caption>{testName}</caption>\n");
            File.AppendAllText(this._path + "\\Result.md", $"<tr><th>Test</th><th>Time (ms)</th></tr>\n");

            while (true)
            {
                
                string test = $"{this._path}\\test.{num}.in";
                string result = $"{this._path}\\test.{num}.out";
                if (!File.Exists(test) || !File.Exists(result))
                    break;
                Stopwatch sw = Stopwatch.StartNew();
                bool resultTest = RunTest(test, result);
                sw.Stop();
                
                File.AppendAllText(this._path + "\\Result.md", $"<tr><th>Test #{num}</th><th>{sw.ElapsedMilliseconds}</th></tr>\n");
                Console.WriteLine($"Test #{num}\t {resultTest}\t time: {sw.ElapsedMilliseconds}");
                num++;
            }
            Console.WriteLine($"\n");
            File.AppendAllText(this._path + "\\Result.md", $"</table>\n");
        }

        private bool RunTest(string test, string result)
        {
            try
            {
                string[] data = File.ReadAllLines(test);
                string expect = this._task.ParseExpect(File.ReadAllText(result).Trim());
                string actual = this._task.Run(data);
                return actual == expect;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
