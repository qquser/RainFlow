using System;
using System.Collections.Generic;
using RainFlowConsoleApp.Data;
using RainFlowConsoleApp.LinkedList;

namespace RainFlowConsoleApp.Creators
{
    public interface IDataCreator<TData> where TData : IData
    {
        MyLinkedList<TData> CreateList(string input);
    }
}
