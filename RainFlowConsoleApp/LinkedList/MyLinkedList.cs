using RainFlowConsoleApp.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace RainFlowConsoleApp.LinkedList
{
    public class MyLinkedList<TData> : IEnumerable<Node<TData>> where TData : IData
    {
        public Node<TData> Head { get; set; }

        public void AddAfter(int? currentId, TData data)
        {
            if (currentId == null)
            {
                Head = new Node<TData> { Value = data };
                return;
            }
            var current = Head;
            while (current != null)
            {
                if (current.Value.Id == currentId)
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



        public void RemoveFirst(Func<TData, bool> func)
        {
            var current = Head;
            while (current != null)
            {
                if (func(current.Value))
                {
                    if (current.Previous == null)
                    {
                        if (current.Next != null)
                            current.Next.Previous = null;
                        Head = current.Next;
                        return;
                    }
                    current.Previous.Next = current.Next;

                    if (current.Next != null)
                        current.Next.Previous = current.Previous;
                    return;
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
