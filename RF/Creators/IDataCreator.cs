using System;
using System.Collections.Generic;
using RF.Data;
using RF.LinkedList;

namespace RF.Creators
{
    public interface IDataCreator<TData> where TData : IData
    {
        MyLinkedList<TData> CreateList(string input);
    }
}
