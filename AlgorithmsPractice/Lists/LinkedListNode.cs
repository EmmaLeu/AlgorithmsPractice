using System;
using System.Linq;

namespace AlgorithmsPractice.Lists
{
    public class LinkedListNode<T> where T : IEquatable<T>
    {
        public LinkedListNode<T> Next { get; set; }

        public T Value { get; set; }

        public LinkedListNode(T value)
        {
            Value = value;
        }

        public LinkedListNode(params T[] values)
        {
            if(values == null || values.Length == 0)
            {
                return;
            }

            var head = this;
            head.Value = values.First();

            for (var index = 1; index < values.Length ; index++)
            {
                head.Next = new LinkedListNode<T>(values[index]);
                head = head.Next;
            }
        }

        public void Add(T value)
        {
            var end = new LinkedListNode<T>(value);
            var current = this;
            while(current.Next != null)
            {
                current = current.Next;
            }
            current.Next = end;
        }

        public LinkedListNode<T> Delete(LinkedListNode<T> head, T value)
        {
            if(head == null)
            {
                return null;
            }

            var current = head;

            if (current.Value.Equals(value))
            {
                return head.Next;
            }

            while(current.Next != null)
            {
                if (!current.Next.Value.Equals(value))
                {
                    current.Next = current.Next.Next;
                    break;
                }

                current = current.Next;
            }

            return head;
        }
    }
}
