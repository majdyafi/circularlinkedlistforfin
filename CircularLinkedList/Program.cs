using System;

namespace CircularLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedListNode rootNode = new LinkedListNode(1);
            rootNode.CreateChain(100);

            var loopNode = rootNode;
            while (loopNode.next != null)
            {
                Console.WriteLine($"Person {loopNode.value} will kill {loopNode.next.value}");
                loopNode = loopNode.DeleteNextNode();
            }

            Console.WriteLine($"The winner is {loopNode.value}");
        }
    }

   
}
