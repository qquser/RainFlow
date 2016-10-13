using RainFlowConsoleApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RainFlowConsoleApp.DataImplementation;
using RainFlowConsoleApp.LinkedList;

namespace RainFlowConsoleApp.Creators
{
    public interface IRainCreator<TData> where TData : IData
    {
        MyLinkedList<TData> GetListFlows(string input, IDataCreator<TData> dataCreator);
    }
}
