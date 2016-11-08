using RF.Data;
using System.Collections.Generic;
using RF.Creators;
using RF.LinkedList;

namespace RF.Rain
{
    public interface IRainFlow<TData> where TData : IData
    {
        string Input { get; set; }
        MyLinkedList<TData> Data { get; }
    }
}
