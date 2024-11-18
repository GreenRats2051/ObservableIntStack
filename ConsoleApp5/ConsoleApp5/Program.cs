namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            void Subscriber1(int value) => Console.WriteLine($"Subscriber 1: Added/Removed {value}");
            void Subscriber2(int value) => Console.WriteLine($"Subscriber 2: Added/Removed {value}");

            var observableStack = new ObservableIntStack(new List<int> { 1, 2, 3 });

            observableStack.Subscribe(Subscriber1);
            observableStack.Subscribe(Subscriber2);

            observableStack.Push(4);
            observableStack.Push(5);
            Console.WriteLine($"Current Count: {observableStack.Count}");

            observableStack.Pop();
            observableStack.Pop();
            Console.WriteLine($"Current Count: {observableStack.Count}");
        }
    }
}
