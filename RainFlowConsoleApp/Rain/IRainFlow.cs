using RainFlowConsoleApp.Data;
using System.Collections.Generic;
using RainFlowConsoleApp.LinkedList;

namespace RainFlowConsoleApp.Rain
{
    public interface IRainFlow<TData> where TData : IData
    {
        MyLinkedList<TData> Data { get; set; }
        void PrintResult();
    }
}
