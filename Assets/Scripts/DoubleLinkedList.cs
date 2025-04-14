using System;
using UnityEngine;

public class DoubleLinkedList<T> 
{
    public Node<T> head = null;
    public Node<T> last = null;

    public int count = 0;

    /// <summary>
    /// Añado un tipo cualquiera de valor como puede ser int list string float etc etc
    /// y añade a la lista 
    /// </summary>
    /// <param name="value"></param>
    public virtual void Add(T value)
    {
        Node<T> newNode = new Node<T>(value);
        count++;

        if (head == null)
        {
            head = newNode;
            last = newNode;

            return;
        }
        last.SetNext(newNode);
        newNode.SetPrev(last);

        last = newNode;
    }

    public Node<T> Seek(T objective, Node<T> _head = null, int deep = 0)
    {
        if (_head == null)
        {
            _head = head;
            if (_head == null)
            {
                throw new NullReferenceException("La lista está vacía.");
            }
        }

        if (_head.Value == null)
        {
            throw new NullReferenceException("Nodo sin valor.");
        }

        if (_head.Value.Equals(objective))
        {
            return _head;
        }

        if (_head.Next == null)
        {
            throw new NullReferenceException("Elemento no encontrado en la lista.");
        }

        return Seek(objective, _head.Next, deep + 1);
    }
    public Node<T> Seek(int index, Node<T> _head = null, int deep = 0)
    {
        if (index < 0 || index >= count)
        {
            throw new ArgumentOutOfRangeException("Índice fuera del rango de la lista.");
        }

        if (_head == null)
        {
            _head = head;
            if (_head == null)
            {
                throw new NullReferenceException("La lista está vacía.");
            }
        }

        if (deep == index)
        {
            return _head;
        }

        if (_head.Next == null)
        {
            throw new NullReferenceException("No se pudo avanzar al siguiente nodo. Posiblemente la lista esté corrupta.");
        }

        return Seek(index, _head.Next, deep + 1);
    }
    public Node<T> SeekPrev(T objective) => Seek(objective).Prev;
    public Node<T> SeekPrev(int _pos) => Seek(_pos).Prev;
    public Node<T> SeekNext(T objective) => Seek(objective).Next;
    public Node<T> SeekNext(int _pos) => Seek(_pos).Next;


    /*public virtual void ReadFromStart(Node<T> _head = null, int deep = 0)
    {
        if (head == null || deep >= count) return;

        if (_head == null)
        {
            _head = head;
        }
        print("" + _head.Value.ToString());
        print(" ↓ ");

        ReadFromStart(_head.Next, deep + 1);
    }
    public virtual void ReadFromEnd(Node<T> _last = null, int deep = 0)
    {
        if (last == null || deep >= count) return;

        if (_last == null)
        {
            _last = last;
        }
        print("" + _last.Value.ToString());
        print(" ↓ ");

        ReadFromEnd(_last.Prev, deep + 1);
    }
    */
    public virtual void RemoveNode(Node<T> node)
    {
        if (node == null)
        {
            Debug.LogWarning("Intentando eliminar un nodo nulo.");
            return;
        }

        // Nodo único
        if (node == head && node == last)
        {
            RemoveAll();
            return;
        }

        // Nodo al principio
        if (node == head)
        {
            head = node.Next;
            if (head != null) head.SetPrev(null);
            count--;
            return;
        }

        // Nodo al final
        if (node == last)
        {
            last = node.Prev;
            if (last != null) last.SetNext(null);
            count--;
            return;
        }

        // Nodo en el medio
        node.Prev?.SetNext(node.Next);
        node.Next?.SetPrev(node.Prev);
        count--;
    }

    public virtual void RemoveAll()
    {
        head = null;
        last = null;
        count = 0;
    }
}
