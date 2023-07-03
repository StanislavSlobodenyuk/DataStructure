
class ArrayStack<T>
{
    private T[] array;

    private int top;

    public ArrayStack(int capacity)
    {
        array = new T[capacity];
        top = -1;
    }

    public void Push(T item)
    {
        // якщо потрібно розширити стек
        if (top == array.Length - 1)
        {
           Array.Resize(ref array, array.Length * 2);
        }

        top++;
        array[top] = item;
    }
    public T Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Стек порожній");
        }

        T temp = array[top];
        top--;
        
        return temp;
    }

    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Стек порожній");
        }

        return array[top];
    }
    
    public bool IsEmpty() 
    {
        if (top == -1   )
        {
            return true;
        }
        return false;
    }

    public int Count() 
    {
        if(!IsEmpty()) 
        {
            top++;
            return top;
        }
        else
        {
            return 0;
        }
    }
}
