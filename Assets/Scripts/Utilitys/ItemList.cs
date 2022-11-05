using System.Collections.Generic;
using UnityEngine;

public abstract class ItemList<T> : ScriptableObject
{
    [SerializeField] private List<T> Items;

    public void Add(T item)
    {
        Items.Add(item);
    }

    public void Remove(T item)
    {
        Items.Remove(item);
    }

    public int Count()
    {
        return Items.Count;
    }

    public T GetElement(int index)
    {
        return Items[index];
    }
}
