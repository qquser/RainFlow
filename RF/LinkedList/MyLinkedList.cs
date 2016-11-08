using RF.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace RF.LinkedList
{
    public class MyLinkedList<TData> : IEnumerable<Node<TData>>
    {
        public Node<TData> Head { get; set; }

        public void AddFirst(TData data)
        {
            var toAdd = new Node<TData>
            {
                Value = data,
                Next = Head
            };
            Head = toAdd;
        }

        public void AddLast(TData data)
        {
            if (Head == null)
            {
                Head = new Node<TData>
                {
                    Value = data,
                    Next = null
                };
                return;
            }
            this.AddAfter(x => x.Next == null, data);
        }


        public void AddAfter(Func<Node<TData>, bool> func, TData data)
        {
            var current = Head;
            while (current != null)
            {
                if (func(current))
                {
                    var newNode = new Node<TData>
                    {
                        Previous = current,
                        Next = current.Next,
                        Value = data
                    };

                    if (current.Next != null)
                        current.Next.Previous = newNode;
                    current.Next = newNode;
                    return;
                }
                current = current.Next;
            }
        }

        public void RemoveAll(Func<Node<TData>, bool> func)
        {
            var current = Head;
            while (current != null)
            {
                if (func(current))
                {
                    if (current.Previous == null)
                    {
                        if (current.Next != null)
                            current.Next.Previous = null;
                        Head = current.Next;
                        current = current.Next;
                        continue;
                    }
                    current.Previous.Next = current.Next;

                    if (current.Next != null)
                        current.Next.Previous = current.Previous;
                }
                current = current.Next;
            }
        }

        public IEnumerator<Node<TData>> Enumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current;
                current = current.Next;
            }
        }

        IEnumerator<Node<TData>> IEnumerable<Node<TData>>.GetEnumerator()
        {
            return Enumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return Enumerator();
        }
    }
}
