using RainFlowConsoleApp.Creators;
using RainFlowConsoleApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using RainFlowConsoleApp.DataImplementation;
using RainFlowConsoleApp.LinkedList;

namespace RainFlowConsoleApp.Rain
{
    public class RainFlow : IRainFlow<FlowData>
    {
        public MyLinkedList<FlowData> Data { get; set;}

        public RainFlow(string input, IRainCreator<FlowData> rainCreator, IDataCreator<FlowData> dataCreator)
        {
            Data = rainCreator?.GetListFlows(input, dataCreator);
        }

        public void PrintResult()
        {
            Console.WriteLine("Num\tStart\tEnd\tFlow Type");
            Data.ToList().ForEach(x=>Console.Write($"{x.Value.Id}\t{x.Value.StartPointValue}\t{x.Value.EndPointValue}\t{x.Value.PointType}\t\n"));
        }
    }
}
