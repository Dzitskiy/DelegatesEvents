class Program
{
    public delegate void SimpleDelegate(string message);

    public static void Main(string[] args)
    {
        SimpleDelegate del = DisplayMessage;
        
        del = del + DisplayUpperMessage;

        del += DisplayRevertedMessage;
        del -= DisplayRevertedMessage;

        del("Hello");
        del.Invoke("World!");

        Console.WriteLine($"Target: '{del.Target}'");
        Console.WriteLine($"Method: '{del.Method.Name}'");
        Console.WriteLine("InvocationList:");
        foreach (Delegate d in del.GetInvocationList())
        {
            Console.WriteLine(d.Method.Name);
        }

        void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        void DisplayRevertedMessage(string message)
        {
            Console.WriteLine(new string(message.Reverse().ToArray()));
        }

        void DisplayUpperMessage(string message)
        {
            Console.WriteLine(new string(message.ToUpper()));
        }        
    }
}
