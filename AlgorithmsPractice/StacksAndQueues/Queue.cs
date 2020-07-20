using AlgorithmsPractice.Lists;
using System;

namespace AlgorithmsPractice.StacksAndQueues
{
    //First in, first out
    public class Queue<T> where T : IEquatable<T>
    {
        private LinkedListNode<T> _first;
        private LinkedListNode<T> _last;

        public void Enqueue(T value)
        {
            if(_first == null)
            {
                _last = new LinkedListNode<T>(value);
                _first = _last;
            }
            else
            {
                _last.Next = new LinkedListNode<T>(value);
                _last = _last.Next;
            }
        }

        public T Dequeue()
        {
            if(_first != null)
            {
                var item = _first.Value;
                _first = _first.Next;
                return item;
            }

            return default;
        }
    }
}
