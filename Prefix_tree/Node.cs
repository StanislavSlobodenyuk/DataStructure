
namespace Prefix_tree
{
    internal class Node<T>
    {
        public char Key { get; set; }
        public bool IsEndOFWord { get; set; }
        public Node<T> Parent { get; set; }
        public Dictionary<char, Node<T>> Children { get; set; }

        public Node(char key)
        {
            Key = key;
            Children = new Dictionary<char, Node<T>>();
        }
    }
}
