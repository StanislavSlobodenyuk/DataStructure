// реалізація однозв'язкового списку 
using System;
using System.Collections;
using System.Collections.Generic;

LinkedList<int> linkedList = new LinkedList<int>();
linkedList.Add(1);
linkedList.Add(2);

Console.WriteLine(linkedList);

linkedList.FindCentralElement();

//linkedList.Reverse();


public class Node<T>
{
    public T Data { get; set; }
    public Node<T>? Next { get; set; }

    public Node(T data)
    {
        Data = data;
    }
}

class LinkedList<T> : IEnumerable<T>
{
    Node<T>? head;
    Node<T>? tail;
    int count = 0;

    public void Add(T data)
    {
        Node<T> node = new Node<T>(data);

        if (head == null)
        {
            head = node;
        }
        else
            tail!.Next = node;
        tail = node;
        count++;
    }
    public bool Remove(T data)
    {
        Node<T>? current = head;
        Node<T>? previous = null;

        while (current != null && current.Data != null)
        {
            if (current.Data.Equals(data))
            {
                if (previous != null)
                {
                    previous.Next = current.Next;
                    if (current.Next == null)
                    {
                        tail = previous;
                    }
                }
                else
                {
                    head = head?.Next;
                    if (head == null)
                    {
                        tail = null;
                    }
                }
                count--;
                return true;
            }
            previous = current;
            current = current.Next;
        }
        return false;
    }

    public int Count { get { return count; } }
    public bool isEmpy { get { return count == 0; } }

    public void Clear()
    {
        head = null;
        tail = null;
        count = 0;
    }
    public bool Contains(T data)
    {
        Node<T>? current = head;

        if (current.Data != null && current != null)
        {
            if (current.Data.Equals(data))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public void AppendFirst(T data)
    {
        Node<T> node = new Node<T>(data);
        node.Next = head;
        head = node;
        if (count == 0) tail = head;
        count++;
    }
    public void Reverse()
    {
        Node<T>? prev = null;
        Node<T>? next = null;
        Node<T>? current = head;

        while (current != null)
        {
            next = current.Next;
            current.Next = prev;
            prev = current;
            current = next;
        }
        head = tail;
        tail = head;
    }
    public void DeleteCopy()
    {
        Node<T>? current = head;

        while (current != null)
        {
            Node<T>? runner = current;
            while (runner.Next != null)
            {
                if (current.Data.Equals(runner.Next.Data))
                {
                    runner.Next = runner.Next.Next;
                    count--;
                }
                else
                {
                    runner = runner.Next;
                }
            }
            current = current.Next;
        }
    }

    public Node<T> FindCentralElement()
    {
        Node<T>? slow = head;
        Node<T>? fast = head;

        while (fast != null && fast.Next != null)
        {
            slow = slow.Next;
            fast = fast.Next.Next;
        }

        return slow;
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
