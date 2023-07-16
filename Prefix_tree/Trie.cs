
using Prefix_tree;
using System.Text;
using System.Xml.Linq;

namespace Prefix_trie
{
    internal class Trie<T>
    {
        private Node<T> root;
        public int Count { get; set; }

        public Trie()
        {
            root = new Node<T>('\0') ;
        }


        public void Add(string word)
        {
            Node<T> current = root;

            foreach (char c in word)
            {
                if (!current.Children.ContainsKey(c))
                {
                    Node<T> newNode = new Node<T>(c) { Parent = current, };

                    current.Children[c] = newNode;
                }
                current = current.Children[c];
            }
            current.IsEndOFWord = true;
        }

        public bool Remove(string word)
        {
            Node<T> current = FindNode(word);

            if (current == null && !current.IsEndOFWord)
            {
                return false;
            }

            current.IsEndOFWord = false;

            if (current.Children.Count == 0)
            {
                Node<T> parent = current.Parent;

                while (parent != null)
                {
                    parent.Children.Remove(current.Key);

                    if (parent.IsEndOFWord == true || parent.Children.Count > 0)
                    {
                        break;
                    }
                }
            }
            return true;
        }

        public Node<T> FindNode(string word)
        {
            Node<T> current = root;

            foreach (char c in word)
            {
                if (current.Children.ContainsKey(c))
                {
                    current = current.Children[c];
                }
                else
                {
                    return null;
                }
            }
            return current;
        }

        public bool Search(string word)
        {
            Node<T> current = FindNode(word);
            return current != null && current.IsEndOFWord;
        }

        public bool SearchPrefix(string prefix) 
        { 
            Node<T> current = FindNode(prefix);
            return current != null;
        }

        public List<string> FindAllWords()
        {
            List<string> words = new List<string>();
            GetAllWordsRecursive(root, "", words);
            return words;   
        }
        private void GetAllWordsRecursive(Node<T> current, string currentWord, List<string> words)
        {
            if( current == null)
            {
                return;
            }

            if (current.IsEndOFWord)
            {
                words.Add(currentWord);
            }

            foreach (var child in current.Children)
            {
                string childWord = currentWord + child.Key;
                GetAllWordsRecursive(child.Value, childWord, words);
            }
        }

        public string LongestCommonPrefix()
        {
            StringBuilder longestPrefix = new StringBuilder();
            Node<T> current = root;

            while (current != null && current.Children.Count == 1)
            {
                var child = current.Children.First();
                longestPrefix.Append(child.Key);
                current = child.Value;
            }

            return longestPrefix.ToString();
        }
    }
}

