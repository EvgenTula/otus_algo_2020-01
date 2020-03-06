namespace SimpleTester
{
    public abstract class Task
    {
        abstract public string  Run(string[] data);

        virtual public string ParseExpect(string data)        
        {
            return data;
        }
    }
}
