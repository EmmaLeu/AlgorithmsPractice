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
    }
}
