using System;
using System.Collections.Generic;
using System.Linq;

public class CircularBuffer<T>(int capacity)
{
    private int Capacity { get; } = capacity;
    private List<T> Items { get; } = new(capacity);

    public T Read()
    {
        if (Items.Count == 0)
        {
            throw new InvalidOperationException();
        }

        T item = Items.First();
        Items.RemoveAt(0);

        return item;
    }

    public void Write(T value)
    {
        if (Items.Count == Capacity)
        {
            throw new InvalidOperationException();
        }

        Items.Add(value);
    }

    public void Overwrite(T value)
    {
        if (Items.Count == Capacity)
        {
            Items.RemoveAt(0);
        }

        Write(value);
    }

    public void Clear()
    {
        if (Items.Count == 0)
        {
            return;
        }

        Items.Clear();
    }
}
