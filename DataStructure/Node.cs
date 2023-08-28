namespace DataStructure
{
    public class Node
    {
        public int val;
        public Node? left;
        public Node? right;
        public Node? next;
        public IList<Node> children;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
            left = null;
            right = null;
            next = null;
            children = new List<Node>();
        }

        public Node(int _val, Node _left, Node _right)
        {
            val = _val;
            left = _left;
            right = _right;
            next = null;
            children = new List<Node>();
        }

        public Node(int _val, Node _left, Node _right, Node _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
            children = new List<Node>();
        }

        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }
}