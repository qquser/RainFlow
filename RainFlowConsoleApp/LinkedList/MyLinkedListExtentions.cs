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
        public static void RemoveListNodesById<TData>(this MyLinkedList<TData> list, List<int> listIds) where TData : IData
        {
            foreach (var id in listIds)
                list.RemoveFirst(x => x.Id == id);
        }
    }
}
