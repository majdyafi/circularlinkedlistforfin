namespace CircularLinkedList
{
    public class LinkedListNode
    {
        public int value;
        public LinkedListNode next;
        public LinkedListNode()
        {

        }
        public LinkedListNode(int v)
        {
            this.value = v;
        }

        public LinkedListNode LinkNode(LinkedListNode node)
        {
            this.next = node;
            return this.next;
        }

        public LinkedListNode CreateChain(int size)
        {
            LinkedListNode loopNode = this;
            for (int i = 2; i <= size; i++)
            {
                loopNode = loopNode.LinkNode(new LinkedListNode(i));
            }
            loopNode.LinkNode(this);

            return loopNode;
        }

        public LinkedListNode DeleteNextNode()
        {
            LinkedListNode followingNode = this.next.next;
            if(followingNode == this)
            {
                this.next = null;
                return this;
            }

            this.next = followingNode;

            return followingNode;
        }
    }
}
