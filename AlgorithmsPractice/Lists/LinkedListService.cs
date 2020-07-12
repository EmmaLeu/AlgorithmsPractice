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

        public static LinkedListNode<T> FindNthToLastElement<T>(LinkedListNode<T> head, int n) where T: IEquatable<T>
        {
            if (head == null || n < 1)
            {
                return null;
            }

            var p1 = head;
            var p2 = head;

            for(var index = 0; index < n - 1; ++index)
            {
                if(p2 == null)
                {
                    return null;
                }

                p2 = p2.Next;
            }

            while(p2.Next != null)
            {
                p1 = p1.Next;
                p2 = p2.Next;
            }

            return p1;
        }

        public static bool DeleteNode<T>(LinkedListNode<T> node) where T : IEquatable<T>
        {
            if (node == null || node.Next == null)
            {
                return false;
            }

            var next = node.Next;
            node.Value = next.Value;
            node.Next = next.Next;

            return true;
        }
    }
}
