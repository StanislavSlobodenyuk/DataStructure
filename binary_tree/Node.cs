

using System.Net.Http.Headers;
using System.Xml.Linq;

namespace binary_tree
{
    class Node<T> : IComparable
        where T : IComparable<T>
    {
        public T Data { get; set; }
        public Node<T>? Rigth { get; set; }
        public Node<T>? Left { get; set; }

        public Node(T data, Node<T> left, Node<T> right)
        {
            Data = data;
            Left = left;
            Rigth = right;
        }
        public Node(T data)
        {
            Data = data;
        }

        public void Add(T data)
        {
            var node = new Node<T>(data);

            if (node.Data.CompareTo(Data) == -1)
            {
                if (Left == null)
                {
                    Left = node;
                }
                else
                {
                    Left.Add(data);
                }
            }
            else
            {
                if(Rigth == null)
                {
                    Rigth = node;  
                }
                else
                {
                    Rigth.Add(data); 
                }
            }
        }

        public int CompareTo(object obj) 
        {

            if (obj is Node<T> item )
            {
                return Data.CompareTo(item.Data);
            }
            else
            {
                throw new Exception("Типи не збігаються");
            }
        }
        public int CompareTo(T other)
        {
            return Data.CompareTo(other);
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }

}
