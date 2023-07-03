//// Як стек можна реалізувати за допомогою c#
//Stack<int> defaultStack = new Stack<int>();

//// додавання елемену у стек
//defaultStack.Push(0);
//defaultStack.Push(1);
//defaultStack.Push(2);
//defaultStack.Push(3);

//// видалення елементу з стеку
//Console.WriteLine(defaultStack.Pop() + " pop ");
//Console.WriteLine(defaultStack.Pop() + " pop ");

//// перегляд  останнього елементу в стеку
//Console.WriteLine(defaultStack.Peek() + " peek ");


class ListStack<T>
{
    class Node<T>
    {

        public T? Data { get; set; }

        public Node<T>? Next { get; set; }

        public Node(T data)
        {
            Data = data;
        }
    }

    Node<T>? head = null;
    int count = 0;

    public void Push(T data)
    {
        Node<T> node = new Node<T>(data);

        node.Next = head;
        head = node;
        count++;
    }
    public T Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Стек порожній");
        }

        T tempItem = head.Data;
        head = head.Next;
        count--;

        return tempItem;
    }
    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Стек порожній");
        }
        return head.Data;
    }
    public bool IsEmpty()
    {
        if (count == 0)
        {
            return true;
        }
        return false;
    }
}