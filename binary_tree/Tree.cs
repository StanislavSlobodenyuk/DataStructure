
using System.ComponentModel.Design;

namespace binary_tree
{
    class Tree<T> where T : IComparable<T>
    {
        public Node<T> Root { get;  set; }
        public int Count { get;  set; }

        public void Add(T data)
        {
            if (Root == null)
            {
                Root = new Node<T>(data);
                Count = 1;
                return;
            }

            var current = Root;
            Root.Add(data);
            Count++;
        }

        public void DeleteNode(T data)
        {
            Root = DeleteNode(Root, data);
        }
        private Node<T> DeleteNode(Node<T> root, T data)
        {
            // Перевіряємо, чи дерево пусте
            if (root == null)
                return root;

            // Якщо ключ менший за поточний вузол, рекурсивно видаляємо його з лівого піддерева
            if (root.Data.CompareTo(data) == -1)
                root.Left = DeleteNode(root.Left, data);
            // Якщо ключ більший за поточний вузол, рекурсивно видаляємо його з правого піддерева
            else if (root.Data.CompareTo(data) == 1)
                root.Rigth = DeleteNode(root.Rigth, data);
            // Якщо ключ співпадає з поточним вузлом, то це вузол, який потрібно видалити
            else
            {
                // Випадок 1: Вузол не має дітей або має тільки одне піддерево
                if (root.Left == null)
                    return root.Rigth;
                else if (root.Rigth == null)
                    return root.Left;

                // Випадок 2: Вузол має два піддерева
                // Знаходимо найменший вузол в правому піддереві (мінімальний правий вузол)
                Node<T> minRight = FindMin(root.Rigth);
                // Копіюємо значення мінімального вузла в поточний вузол
                root.Data = minRight.Data;
                // Рекурсивно видаляємо мінімальний вузол з правого піддерева
                root.Rigth = DeleteNode(root.Rigth, minRight.Data);
            }

            return root;
        }
        // Використовується для методу  DeleteNode
        private Node<T> FindMin(Node<T> node)
        {
            // Знаходимо найменший вузол (найлівіший вузол) в дереві
            while (node.Left != null)
                node = node.Left;   

            return node;
        }
        // Використовується для методу  DeleteNode
      
        public bool Search(T data)
        {
            foreach (var item in Postorder())
            {
                if (item.CompareTo(data) == 0)
                { 
                    return true;
                }
            }

            return false;
        }

        public Node<T> FindMin()
        {
            Node<T> node = Root;
            while(node.Left != null)
            {
                node = node.Left;
            }
            return node;
        }
        public Node<T> FindMax()
        {
            Node<T> node = Root;
            while (node.Rigth != null)
            {
                node = node.Rigth;
            }
            return node;
        }

        public List<T> Preorder()
        {
            if (Root == null)
            {
                return new List<T>();
            }
            return Preorder(Root);
        }
        private List<T> Preorder(Node<T> node)
        {
            var list = new List<T>();

            if (node != null)
            {
                list.Add(node.Data);

                if (node.Left != null)
                {
                    list.AddRange(Preorder(node.Left));
                }

                if (node.Rigth != null)
                {
                    list.AddRange(Preorder(node.Rigth));
                }
            }

            return list;
        }

        public List<T> Postorder()
        {
            if (Root == null)
            {
                return new List<T>();
            }

            return Postorder(Root);
        }
        private List<T> Postorder(Node<T> node)
        {
            var list = new List<T>();
            if (node != null)
            {
                if (node.Left != null)
                {
                    list.AddRange(Postorder(node.Left));
                }
                if (node.Rigth != null)
                {
                    list.AddRange(Postorder(node.Rigth));
                }

                list.Add(node.Data);
            }
            return list;
        }

        public List<T> Inorder()
        {
            if (Root == null)
            {
                return new List<T>();
            }

            return Inorder(Root);
        }
        private List<T> Inorder(Node<T> node)
        {
            var list = new List<T>();
            if (node != null)
            {
                if (node.Left != null)
                {
                    list.AddRange(Inorder(node.Left));
                }

                list.Add(node.Data);

                if (node.Rigth != null)
                {
                    list.AddRange(Inorder(node.Rigth));
                }
            }
            return list;
        }
    }
}


