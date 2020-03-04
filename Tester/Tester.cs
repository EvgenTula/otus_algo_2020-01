using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTester
{
    public class Tester
    {
        private ITask _task;
        private string _path;
        public Tester(ITask task, string path)
        {
            this._task = task;
            this._path = path;
        }

        public void RunTests(String testName)
        {
            int num = 0;
            Stopwatch sw = new Stopwatch();
            Console.WriteLine($"==={testName}===");
            while (true)
            {
                
                string test = $"{this._path}\\test.{num}.in";
                string result = $"{this._path}\\test.{num}.out";
                if (!File.Exists(test) || !File.Exists(result))
                    break;
                sw.Restart();
                bool resultTest = RunTest(test, result);
                sw.Stop();
                Console.WriteLine($"Test #{num}\t {resultTest}\t time: {sw.ElapsedMilliseconds}");
                num++;
            }
            Console.WriteLine($"\n");
        }

        private bool RunTest(string test, string result)
        {
            try
            {
                string[] data = File.ReadAllLines(test);
                string expect = File.ReadAllText(result).Trim();
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
