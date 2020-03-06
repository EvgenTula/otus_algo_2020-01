namespace SimpleTester
{
    class StringLength : Task
    {
        public override string Run(string[] data)
        {
            return data[0].Length.ToString();
        }
    }
}
