using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester
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

        public void RunTests()
        {
            int num = 0;
            while(true)
            {
                string test = $"{this._path}\\test.{num}.in";
                string result = $"{this._path}\\test.{num}.out";
                if (!File.Exists(test) || !File.Exists(result))
                    break;
                Console.WriteLine($"Test #{num} - " + RunTest(test, result));
                num++;
            }
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
