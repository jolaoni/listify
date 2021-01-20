using System.Collections.Generic;
using System.Linq;

public class ListifyCollection : IList<int>
{
    private IEnumerable<int> enumeration;

    public ListifyCollection(int start, int end)
    {
        enumeration = Enumerable.Range(start, end);
    }

    public int this[int index]
    {
        get
        {
            return enumeration.ElementAt(index);
        }
        set
        {
            enumeration = enumeration.Select((x, i) =>
            {
                if (i == index)
                    return value;
                return x;
            });
        }
    }

    public int Count => enumeration.Count();

    public bool IsReadOnly => false;

    public void Add(int item)
    {
        enumeration = enumeration.Concat(new[] { item });
    }

    public void Clear()
    {
        enumeration = Enumerable.Empty<int>();
    }

    public bool Contains(int item)
    {
        return enumeration.Contains(item);
    }

    public void CopyTo(int[] array, int arrayIndex)
    {
        for (int i = arrayIndex; i < Count; i++)
        {
            array[i] = this[i];
        }
    }

    public IEnumerator<int> GetEnumerator()
    {
        return enumeration.GetEnumerator();
    }

    public int IndexOf(int item)
    {
        var idx = enumeration.TakeWhile(x => x != item).Count();
        if (enumeration.Any() && idx == Count && enumeration.Last() != item)
        {
            return -1;
        }

        return idx;
    }

    public void Insert(int index, int item)
    {
        this[index] = item;
    }

    public bool Remove(int item)
    {
        var countBefore = Count;
        enumeration = enumeration.Except(new[] { item });
        var countAfter = Count;

        return countAfter < countBefore;
    }

    public void RemoveAt(int index)
    {
        enumeration = enumeration.Where((x, i) => i != index);
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return enumeration.GetEnumerator();
    }
}
