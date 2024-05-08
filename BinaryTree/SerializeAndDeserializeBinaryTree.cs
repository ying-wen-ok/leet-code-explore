using System;
using System.Text;
using DataStructure;

namespace BinaryTree
{
    public class SerializeAndDeserializeBinaryTree
    {  
        // (){}<>
        public string serialize(TreeNode root)
        {
            return preorderSerialize(root).ToString();
        }

        private string NULL = "N";

        private char startOfVal = '(';
        private char endOfVal = ')';

        private char startOfLeftNode = '{';
        private char endOfLeftNode = '}';

        private char startOfRightNode = '<';
        private char endOfRightNode = '>';

        private StringBuilder preorderSerialize(TreeNode node)
        {
            if (node == null) return new StringBuilder(NULL);

            StringBuilder currentNode = new StringBuilder();

            currentNode.Append(startOfVal + node.val.ToString() + endOfVal);

            currentNode.Append(startOfLeftNode);
            currentNode.Append(preorderSerialize(node.left));
            currentNode.Append(endOfLeftNode);

            currentNode.Append(startOfRightNode);
            currentNode.Append(preorderSerialize(node.right));
            currentNode.Append(endOfRightNode);


            return currentNode;
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            return deserializeRecursively(data);
        }

        private TreeNode deserializeRecursively(string data)
        {
            if (data == NULL) return null;

            int newNodeVal = ConverToVal(data);
            TreeNode newNode = new TreeNode(newNodeVal);

            string leftNodeString = getLeftNodeString(data);
            newNode.left = deserializeRecursively(leftNodeString);

            string rightNodeString = getRightNodeString(data);
            newNode.right = deserializeRecursively(rightNodeString);

            return newNode;
        }

        private int ConverToVal(string data)
        {
            int indexOfStartOfVal = data.IndexOf(startOfVal);
            int n = data.Length;
            string val = "";
            for (int i = indexOfStartOfVal + 1; i < n; i++)
            {
                char c = data[i];
                if (c == endOfVal) break;
                val = val + c;
            }

            return Convert.ToInt32(val.ToString());
        }

        private string getLeftNodeString(string data)
        {
            StringBuilder sb = new StringBuilder();
            int indexOfStartOfLeftNode = data.IndexOf(startOfLeftNode);
            int countOfLeftNodeStart = 1;

            int n = data.Length;
            for (int i = indexOfStartOfLeftNode + 1; i < n; i++)
            {
                char c = data[i];

                if (c == endOfLeftNode) { countOfLeftNodeStart--; }
                else if (c == startOfLeftNode) { countOfLeftNodeStart++; }

                if (countOfLeftNodeStart == 0) break;
                sb.Append(c);
            }
            return sb.ToString();
        }

        private string getRightNodeString(string data)
        {
            int indexOfEndOfRightNode = data.LastIndexOf(endOfRightNode);
            int countOfEndOfRightNode = 1;

            Stack<char> S = new Stack<char>();
            for (int i = indexOfEndOfRightNode - 1; i >= 0; i--)
            {
                char c = data[i];

                if (c == startOfRightNode) { countOfEndOfRightNode--; }
                else if (c == endOfRightNode) { countOfEndOfRightNode++; }

                if (countOfEndOfRightNode == 0) break;
                S.Push(c);
            }

            StringBuilder sb = new StringBuilder();
            while (S.Count > 0)
            {
                sb.Append(S.Pop());
            }

            return sb.ToString();
        }
    }
}
