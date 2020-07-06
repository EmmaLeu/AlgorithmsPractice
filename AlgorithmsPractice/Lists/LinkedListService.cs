using System;
using System.Collections.Generic;

namespace AlgorithmsPractice.Lists
{
    public class LinkedListService
    {
        public static void RemoveDuplicates<T>(LinkedListNode<T> node) where T : IEquatable<T>
        {
            if(node == null)
            {
                return;
            }

            var hashset = new HashSet<T>();

            LinkedListNode<T> previous = null;

            while(node != null)
            {
                if(hashset.Contains(node.Value))
                {
                    previous.Next = node.Next;
                }
                else
                {
                    hashset.Add(node.Value);
                    previous = node;
                }

                node = node.Next;
            }
        }

        public static void RemoveDuplicatesTwoPointers<T>(LinkedListNode<T> head) where T : IEquatable<T>
        {
            if(head == null)
            {
                return;
            }

            var previous = head;
            var current = previous.Next;

            while(current != null)
            {
                var runner = head;

                while(runner != current)
                {
                    if(runner.Value.Equals(current.Value))
                    {
                        var temp = current.Next;
                        previous.Next = temp;
                        current = temp;
                        break;
                    }

                    runner = runner.Next;
                }

                if(runner == current)
                {
                    previous = current;
                    current = current.Next;
                }
            }
        }
    }
}
