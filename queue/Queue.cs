// Реалізація черги

using System.Collections;

class Queue<T> : IEnumerable<T>
{
    private List<T> list = new List<T> ();

    public void Enqueue(T item)
    {
        list.Add (item);
    }

    public T Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Черга порожня");
        }
        else
        {
            T item = list.First();
            list.Remove(list.First());
            return item;
        }
      
    }

    public bool IsEmpty()
    {
        if (list.Count == 0)
        {
            return true;
        }
        else return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
