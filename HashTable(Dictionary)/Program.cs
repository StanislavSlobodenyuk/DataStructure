// реалізація хеш-таблиці

using System.Collections;


HashTable<string, int> hashTable = new HashTable<string, int>();


hashTable.Add("One", 1);
hashTable.Add("Two", 2);
hashTable.Add("Three", 3);
hashTable.Add("Four", 4);

Console.WriteLine(hashTable.Remove("Four"));

hashTable.Get("Four");


class HashTable<Tkey, Tvalue>
{
    private const int DefaultCapacity = 16;
    private LinkedList<KeyValuePair<Tkey, Tvalue>>[] buckets;

    public HashTable() 
    {
        buckets = new LinkedList<KeyValuePair<Tkey, Tvalue>>[DefaultCapacity];  
    }

    public void Add(Tkey key, Tvalue value)
    {
        int bucketIndex = GetBucketIndex(key);

        if (buckets[bucketIndex] == null)
        {
            buckets[bucketIndex] = new LinkedList<KeyValuePair<Tkey, Tvalue>>();
        }

        var bucket = buckets[bucketIndex];

        foreach (var pair in bucket)
        {
            if (pair.Key.Equals(key))
            {
                throw new ArgumentException("Вже iснує елемент з таким ключем!");
            }
        }

        bucket.AddLast(new KeyValuePair<Tkey, Tvalue>(key, value));
    }

    public string Remove(Tkey key)
    {
        int bucketIndex = GetBucketIndex(key);
        var bucket = buckets[bucketIndex];

        if (bucket != null)
        {
            foreach (var pair in bucket)
            {
                if (pair.Key.Equals(key))
                {
                    bucket.Remove(pair);
                    return "Елемент з ключем: " + key + " був видалений!";
                }
            }
        }
        throw new KeyNotFoundException("Недiйсний ключ");
    }

    public Tvalue Get(Tkey key)
    {
        int bucketIndex = GetBucketIndex(key);
        var bucket = buckets[bucketIndex];

        if (bucket != null)
        {
            foreach (var pair in bucket)
            {
                if (pair.Key.Equals(key))
                {
                    return pair.Value;
                }
            }

        }
        throw new KeyNotFoundException("Недiйсний ключ");
    }

    public bool ContainsKey(Tkey key)
    {
        int bucketIndex = GetBucketIndex(key);
        var bucket = buckets[bucketIndex];
        
        if(bucket != null)
        {
            foreach(var pair in bucket)
            {
                if (pair.Key.Equals(key))
                {
                    return true;
                }
            }
        }
        return false;
    }

    private int GetBucketIndex(Tkey key)
    {
        int hashCode = key.GetHashCode();
        return (hashCode & 0x7FFFFFFF) % buckets.Length;
    }


}