using System;
using System.Collections.Generic;

namespace E2
{
    public class LinkedList<T>
    {
        public Node<T> Head { get; set; } = null;
        public Node<T> Tail { get; set; } = null;

        public void AddLast(T value)
        {
            Node<T> node = new Node<T>(value);
            if (Tail != null)
            {
                Tail.Next = node;
                Tail = node;
            } else
            {
                Head = Tail = node;
            }
            size++;
        }

        public void AddFirst(T value)
        {
            Node<T> node = new Node<T>(value);
            if (Head != null)
            {
                node.Next = Head;
                Head = node;
            } else
            {
                Head = Tail = node;
            }
            size++;
        }

        public void RemoveFirst()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("LinkedList was empty");
            } else
            {
                Head = Head.Next;
            }
            size--;
        }
        private int size = 0;
        public int Size()
        {
            return size;
        }
    }

    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; } = null;

        public Node(T value)
        {
            Value = value;
        }
    }
}
