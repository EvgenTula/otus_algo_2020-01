namespace SimpleTester
{
    class StringLength : ITask
    {
        public string Run(string[] data)
        {
            return data[0].Length.ToString();
        }
    }
}
