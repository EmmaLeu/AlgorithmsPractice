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

        /// <summary>
        /// Add 2 numbers having each digit in a node
        /// Last digit in number is head of the list
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static LinkedListNode<int> AddNodes(LinkedListNode<int> n1, LinkedListNode<int> n2, int carry)
        {
            if(n1 == null || n2 == null)
            {
                return null;
            }

            var result = new LinkedListNode<int>(carry);

            var value = carry;

            if(n1 != null)
            {
                value += n1.Value;
            }

            if(n2 != null)
            {
                value += n2.Value;
            }

            result.Value = value % 10;

            var next = AddNodes(n1 == null ? null : n1.Next,
                n2 == null ? null : n2.Next,
                value > 10 ? 1 : 0);

            result.Next = next;

            return result;
        }
    }
}
