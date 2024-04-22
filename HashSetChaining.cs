using Hashing;

public class HashSetChaining : HashSet
{
    private Node[] buckets;
    private int currentSize;

    private class Node
    {
        public Node(Object data, Node next)
        {
            this.Data = data;
            this.Next = next;   
        }
        public Object Data { get; set; }
        public Node Next { get; set; }
    }

    public HashSetChaining(int size)
    {
        buckets = new Node[size];
        currentSize = 0;
    }

    public bool Contains(Object x)
    {
        int h = HashValue(x);
        Node bucket = buckets[h];
        bool found = false;
        while (!found && bucket != null)
        {
            if (bucket.Data.Equals(x))
            {
                found = true;
            }
            else
            {
                bucket = bucket.Next;
            }
        }
        return found;
    }

    public bool Add(Object x)
    {
        if ((double)currentSize / buckets.Length > 0.75)
        {
            Rehash();
        }

        int h = HashValue(x);

        Node bucket = buckets[h];
        bool found = false;
        while (!found && bucket != null)
        {
            if (bucket.Data.Equals(x))
            {
                found = true;
            }
            else
            {
                bucket = bucket.Next;
            }
        }

        if (!found)
        {
            Node newNode = new Node(x, buckets[h]);
            buckets[h] = newNode;
            currentSize++;
        }

        return !found;
    }

    public bool Remove(Object x)
    {
        int h = HashValue(x);
        Node bucket = buckets[h];
        Node previous = null;

        // Gennemgå listen for at finde x
        while (bucket != null)
        {
            if (bucket.Data.Equals(x))
            {
                // Hvis x er det første element i listen
                if (previous == null)
                {
                    // Fjern elementet og opdater head af listen
                    buckets[h] = bucket.Next;
                }
                else
                {
                    // Fjern elementet og opdater pointerne i listen
                    previous.Next = bucket.Next;
                }
                currentSize--;
                return true;
            }

            // Opdater pointers
            previous = bucket;
            bucket = bucket.Next;
        }

        // x blev ikke fundet
        return false;
    }

    private int HashValue(Object x)
    {
        int h = x.GetHashCode();
        if (h < 0)
        {
            h = -h;
        }
        h = h % buckets.Length;
        return h;
    }

    public int Size()
    {
        return currentSize;
    }

    public override String ToString()
    {
        String result = "";
        for (int i = 0; i < buckets.Length; i++)
        {
            Node temp = buckets[i];
            if (temp != null)
            {
                result += i + "\t";
                while (temp != null)
                {
                    result += temp.Data + " (h:" + HashValue(temp.Data) + ")\t";
                    temp = temp.Next;
                }
                result += "\n";
            }
        }
        return result;
    }
    private void Rehash()
    {
        Node[] oldBuckets = buckets;
        buckets = new Node[oldBuckets.Length * 2];
        currentSize = 0;

        foreach (Node head in oldBuckets)
        {
            Node current = head;
            while (current != null)
            {
                Add(current.Data);
                current = current.Next;
            }
        }
    }

}
