using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using RainFlowConsoleApp.Data;

namespace RainFlowConsoleApp.LinkedList
{
    public static class MyLinkedListExtentions
    {
        public static void RemoveAll<TData>(this MyLinkedList<TData> list, IEnumerable<Node<TData>> listNodes) where TData : IData
        {
            foreach (Node<TData> node in listNodes)
                list.RemoveFirst(x => x.Id == node.Value.Id);
        }
    }
}
