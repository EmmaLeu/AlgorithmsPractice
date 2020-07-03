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
    }
}
