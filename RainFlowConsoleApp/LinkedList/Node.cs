using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RainFlowConsoleApp.Data;

namespace RainFlowConsoleApp.LinkedList
{
    public class Node<TData> where TData: IData
    {
        public Node<TData> Previous { get; set; }
        public Node<TData> Next { get; set; }
        public TData Value { get; set; }
    }
}
