using System.Collections;

LinkedList<int> numbers = new LinkedList<int>();

numbers.AddToBack(0);
numbers.AddToBack(1);
numbers.AddToBack(2);
numbers.AddToBack(3);

LinkedList<int> numbers2 = new LinkedList<int>();

numbers2.AddToBack(4);
numbers2.AddToBack(5);
numbers2.AddToBack(6);


numbers = numbers.JoinNewList(numbers, numbers2);

foreach (var item in numbers)
{
    Console.WriteLine(item);
}


public class Node<T>
{
    public T? data { get; set; }
    public Node<T>? next { get; set; }
    public Node<T>? previous { get; set; }

    public Node(T? data)
    {
        this.data = data;
    }
}

class LinkedList<T> : IEnumerable<T>
{
    Node<T>? head = null;
    Node<T>? tail = null;
    int count = 0;

    public void AddToFront(T data)
    {
        Node<T> node = new Node<T>(data);
        if (head == null)
        {
            head = node;
            tail = node;
        }
        else
        {
            node.next = head;
            head.previous = node;
            head = node;
        }
        count++;
    }

    public void AddToBack(T data)
    {
        Node<T> node = new Node<T>(data);

        if (head == null)
        {
            head = node;
            tail = node;
        }
        else
        {
            node.previous = tail;
            tail.next = node;
            tail = node;
        }
        count++;
    }

    public void Remove(T data)
    {
        Node<T>? current = head;

        while (current != null)
        {
            if (current.data.Equals(data))
            {
                if (current == head)
                {
                    head = current.next;
                    if (head != null)
                    {
                        head.previous = null;
                    }
                    else
                    {
                        tail = null;
                    }
                }
                else if (current == tail)
                {
                    tail = current.previous;
                    tail.next = null;
                }
                else
                {
                    current.next.previous = current.previous;
                    current.previous.next = current.next;
                }
                count--;
                break;
            }
            current = current.next;
        }
    }

    public void Clear()
    {
        head = null;
        tail = null;
    }

    public T GetElementAt(int index)
    {
        Node<T>? current = head;
        int counterIndex = 0;

        while (counterIndex != index - 1)
        {
            current = current.next;
            counterIndex++;
        }
        return current.data;
    }

    public LinkedList<T> JoinNewList(LinkedList<T> list1, LinkedList<T> list2)
    {
        Node<T>? current = list2.head;
        int counter = 0;

        while (counter != list2.count)
        {
            list1.AddToBack(current.data);
            current = current.next;
            counter++;
        }
        return list1;
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        Node<T>? current = head;
        while (current != null)
        {
            yield return current.data;
            current = current.next;
        }
    }
    public IEnumerator GetEnumerator()
    {
        return ((IEnumerable<T>)this).GetEnumerator();
    }
}
