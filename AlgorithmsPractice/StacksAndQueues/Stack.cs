using AlgorithmsPractice.Lists;
using System;

namespace AlgorithmsPractice.StacksAndQueues
{
    //Last in, first out
    public class Stack<T> where T : IEquatable<T>
    {
        private LinkedListNode<T> _top;

        public T Pop()
        {
            if(_top != null)
            {
                var item = _top.Value;
                _top = _top.Next;
                return item;
            }

            return default;
        }

        public T Peek()
        {
            if (_top != null)
            {
                return _top.Value;
            }
            return default;
        }

        public void Push(T item)
        {
            var newTop = new LinkedListNode<T>(item);
            newTop.Next = _top;
            _top = newTop;
        }

        public bool IsEmpty()
        {
            if(_top == null)
            {
                return true;
            }

            return false;
        }
    }
}
