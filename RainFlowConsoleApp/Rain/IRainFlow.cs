using RainFlowConsoleApp.Data;
using System.Collections.Generic;
using RainFlowConsoleApp.Creators;
using RainFlowConsoleApp.LinkedList;

namespace RainFlowConsoleApp.Rain
{
    public interface IRainFlow<TData> where TData : IData
    {
        MyLinkedList<TData> Data { get; }
        IRainCreator<TData> RainCreator { get; set; }
        IDataCreator<TData> DataCreator { get; set; }
        void PrintResult();
    }
}
