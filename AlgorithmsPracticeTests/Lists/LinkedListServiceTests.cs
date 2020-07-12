using AlgorithmsPractice.Lists;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsPracticeTests.Lists
{
    public class LinkedListServiceTests
    {
        [Test]
        public void RemoveDuplicates_Int_Test()
        {
            var values = new[] { 1, 2, 1, 4, 5, 5 };
            var head = new AlgorithmsPractice.Lists.LinkedListNode<int>(values);

            LinkedListService.RemoveDuplicates(head);

            var newValues = new List<int>();
            while(head != null)
            {
                newValues.Add(head.Value);
                head = head.Next;
            }

            Assert.AreEqual(newValues.Distinct().ToList().Count, newValues.Count);
            Assert.AreEqual(newValues.Count, values.Distinct().ToList().Count);

            foreach (var value in newValues)
            {
                values.Contains(value);
            }
        }

        [Test]
        public void RemoveDuplicatesTwoPointers_Int_Test()
        {
            var values = new[] { 1, 2, 1, 4, 5, 5 };
            var head = new AlgorithmsPractice.Lists.LinkedListNode<int>(values);

            LinkedListService.RemoveDuplicatesTwoPointers(head);

            var newValues = new List<int>();
            while (head != null)
            {
                newValues.Add(head.Value);
                head = head.Next;
            }

            Assert.AreEqual(newValues.Distinct().ToList().Count, newValues.Count);
            Assert.AreEqual(newValues.Count, values.Distinct().ToList().Count);

            foreach (var value in newValues)
            {
                values.Contains(value);
            }
        }

        [Test]
        public void FindNthToLastElement_Int_Test()
        {
            var head = new AlgorithmsPractice.Lists.LinkedListNode<int>(1, 2, 3, 4, 5, 6, 7);

            var nthToLast = LinkedListService.FindNthToLastElement<int>(head, 3);

            Assert.AreEqual(5, nthToLast.Value);
        }

        [Test]
        public void DeleteNode_IntLast_Test()
        {
            var head = new AlgorithmsPractice.Lists.LinkedListNode<int>(1);
            var next = new AlgorithmsPractice.Lists.LinkedListNode<int>(2);
            head.Next = next;

            var result = LinkedListService.DeleteNode<int>(next);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void DeletNode_IntNull_Test()
        {
            var head = new AlgorithmsPractice.Lists.LinkedListNode<int>(1);
            var next = new AlgorithmsPractice.Lists.LinkedListNode<int>(2);
            head.Next = next;

            var result = LinkedListService.DeleteNode<int>(next);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void DeleteNode_IntMiddle_Test()
        {
            var head = new AlgorithmsPractice.Lists.LinkedListNode<int>(1);
            var middle = new AlgorithmsPractice.Lists.LinkedListNode<int>(2);
            var last = new AlgorithmsPractice.Lists.LinkedListNode<int>(3);

            head.Next = middle;
            middle.Next = last;

            var result = LinkedListService.DeleteNode<int>(middle);

            Assert.AreEqual(true, result);
            Assert.AreEqual(head.Next, middle);
            Assert.AreEqual(3, head.Next.Value);
            Assert.IsNull(middle.Next);
        }
    }
}
