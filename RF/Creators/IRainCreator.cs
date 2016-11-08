using RF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RF.DataImplementation;
using RF.LinkedList;

namespace RF.Creators
{
    public interface IRainCreator<TData> where TData : IData
    {
        MyLinkedList<TData> GetListFlows(string input, IDataCreator<TData> dataCreator);
    }
}
