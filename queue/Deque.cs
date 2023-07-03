using System.Collections;

class Deque<T> : IEnumerable<T>
{
    Node<T>? head = null;
    Node<T>? tail = null;
    int count = 0;
    public void AddFirst(T data)
    {
        Node<T> node = new Node<T>(data);
        if (head == null)
        {
            head = node;
            tail = node;
        }
        else
        {
            node.Next = head;
            head.Prev = node;
            head = node;
        }
        count++;
    }
    public void AddLast(T data)
    {
        Node<T> node = new Node<T>(data);   
        if (head == null)
        {
            head = node;
        }
        else
        {
            tail.Next = node;
            node.Prev = tail;
        }
        tail = node;
        count++;
    }
    public void RemoveFirst()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Deque is empty");
        }
        else if (count == 1)
        {
            head = tail = null;
        }
        else
        {
            head = head.Next;
            head.Prev = null;
        }
        count--;

    }

    public void RemoveLast()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Deque is empty");
        }
        else if(count == 1)
        {
            head = tail = null;
        }
        else 
        {
            tail = tail.Prev;
            tail.Next = null;
        }
        count--;
    }
    public bool IsEmpty()
    {
        if (count == 0)
        {
            return true;
        }
        else return false;
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        Node<T>? current = head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }
    public IEnumerator GetEnumerator()
    {
        return ((IEnumerable<T>)this).GetEnumerator();
    }
}
