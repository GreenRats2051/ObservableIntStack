using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class ObservableIntStack
    {
        public event Action<int> ItemAdded;
        public event Action<int> ItemRemoved;

        private Stack<int> stack;

        public ObservableIntStack(IEnumerable<int> initialValues)
        {
            stack = new Stack<int>(initialValues);
        }

        public void Subscribe(Action<int> subscriber)
        {
            if (subscriber == null) throw new ArgumentNullException(nameof(subscriber));
            ItemAdded += subscriber;
            ItemRemoved += subscriber;
        }

        public void Unsubscribe(Action<int> subscriber)
        {
            if (subscriber == null) throw new ArgumentNullException(nameof(subscriber));
            ItemAdded -= subscriber;
            ItemRemoved -= subscriber;
        }

        public void Push(int item)
        {
            stack.Push(item);
            ItemAdded?.Invoke(item);
        }

        public int Pop()
        {
            int item = stack.Pop();
            ItemRemoved?.Invoke(item);
            return item;
        }

        public int Peek()
        {
            return stack.Peek();
        }

        public int Count => stack.Count;
    }
}
