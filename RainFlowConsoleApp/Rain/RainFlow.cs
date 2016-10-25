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

        public MyLinkedList<FlowData> Data => RainCreator?.GetListFlows(Input, DataCreator);
        public IRainCreator<FlowData> RainCreator { get; set; }
        public IDataCreator<FlowData> DataCreator { get; set; }
        public string Input { get; set; }

        public RainFlow(string input, IRainCreator<FlowData> rainCreator, IDataCreator<FlowData> dataCreator)
        {
            Input = input;
            RainCreator = rainCreator;
            DataCreator = dataCreator;
        }

        public void PrintResult()
        {
            Console.WriteLine("Num\tStart\tEnd\tType\tStartId\tEndId");
            Data.ToList().ForEach(x=>Console.Write($"{x.Value.Id}\t{x.Value.StartPointValue}\t{x.Value.EndPointValue}\t{x.Value.PointType}\t{x.Value.StartId}\t{x.Value.EndId}\t\n"));
        }
    }
}
