using Microsoft.VisualStudio.TestTools.UnitTesting;
using CircularLinkedList;

namespace CircularLinkedListTests
{
    [TestClass]
    public class LinkedListNodeTests
    {
        [TestMethod]
        public void LinkedListNode_Constructor_Returns_LinkedListNode_With_Value()
        {
            int expectedValue = 4;
            LinkedListNode linkedListNode = new LinkedListNode(4);
            Assert.AreEqual(expectedValue, linkedListNode.value);
        }

        [TestMethod]
        public void LinkedListNode_LinkNode_Returns_LinkedListNode_With_Correct_Value()
        {
            LinkedListNode linkedListNode = new LinkedListNode(4);
            LinkedListNode linkedListNodeNext = new LinkedListNode(100);
            var secondNode = linkedListNode.LinkNode(linkedListNodeNext);

            Assert.IsInstanceOfType(secondNode, typeof(LinkedListNode));
            Assert.AreEqual(100, secondNode.value);
            Assert.AreEqual(4, linkedListNode.value);

        }

        [TestMethod]
        public void LinkedListNode_Chain_Returns_LinkedListNode_With_Correct_Value()
        {
            LinkedListNode rootNode = new LinkedListNode(4);

            var secondNode = rootNode.LinkNode(new LinkedListNode(200));
            var thirdNode = secondNode.LinkNode(new LinkedListNode(300));

            Assert.IsInstanceOfType(secondNode, typeof(LinkedListNode));
            Assert.AreEqual(4, rootNode.value);
            Assert.AreEqual(secondNode, rootNode.next);
            Assert.AreEqual(200, secondNode.value);
            Assert.AreEqual(thirdNode, secondNode.next);
            Assert.AreEqual(300, thirdNode.value);
            Assert.IsNull(thirdNode.next);

        }

        [TestMethod]
        public void LinkedListNode_Chain_Loop_Returns_First_Last_Nodes()
        {
            LinkedListNode rootNode = new LinkedListNode(1);
            LinkedListNode loopNode = rootNode;
            for (int i = 2; i < 5; i++)
            {
                loopNode = loopNode.LinkNode(new LinkedListNode(i));
            }

            Assert.AreEqual(1, rootNode.value);
            Assert.AreEqual(4, loopNode.value);
        }

        [TestMethod]
        public void LinkedListNode_Chain_Loop_Returns_Circular_Nodes()
        {
            LinkedListNode rootNode = new LinkedListNode(1);
            var loopNode = rootNode.CreateChain(4);

            Assert.AreEqual(loopNode.next, rootNode);
            Assert.AreEqual(2, loopNode.next.next.value);
        }

        [TestMethod]
        public void Delete_Second_Node_Maintain_Chain()
        {
            LinkedListNode rootNode = new LinkedListNode(1);
            rootNode.CreateChain(4);

            var thirdNode = rootNode.next.next;

            rootNode.next = thirdNode;

            Assert.AreEqual(3, rootNode.next.value);
            Assert.AreEqual(4, rootNode.next.next.value);
        }

        [TestMethod]
        public void Delete_Method_Node_Maintain_Chain()
        {
            LinkedListNode rootNode = new LinkedListNode(1);
            rootNode.CreateChain(4);
            var followingNode = rootNode.next.DeleteNextNode();

            Assert.AreEqual(1, rootNode.value);
            Assert.AreEqual(2, rootNode.next.value);
            Assert.AreEqual(4, rootNode.next.next.value);
            Assert.AreEqual(4, followingNode.value);
        }

        [TestMethod]
        public void Delete_Loop_Returns_Null_Last_Two_Nodes()
        {
            LinkedListNode rootNode = new LinkedListNode(1);
            rootNode.CreateChain(4);

            var loopNode = rootNode;
            while(loopNode.next != null)
            {
                loopNode = loopNode.DeleteNextNode();
            }

            Assert.AreEqual(1, loopNode.value);
        }
    }
}
