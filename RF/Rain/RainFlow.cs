using RF.Creators;
using RF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using RF.DataImplementation;
using RF.LinkedList;

namespace RF.Rain
{
    public class RainFlow : IRainFlow<FlowData>
    {
        private readonly IRainCreator<FlowData> _rainCreator;
        private readonly IDataCreator<FlowData> _dataCreator;

        public MyLinkedList<FlowData> Data
        {
            get
            {
                return _rainCreator?.GetListFlows(Input, _dataCreator);
            }
        }

        public string Input { get; set; }

        public RainFlow(IRainCreator<FlowData> rainCreator, IDataCreator<FlowData> dataCreator)
        {
            _rainCreator = rainCreator;
            _dataCreator = dataCreator;
        }

        public override string ToString()
        {
            string res = "\t\n" + Input +"\t\n"+ "Num\tStart\tEnd\tType\tStartId\tEndId"+ "\t\n";
            foreach (var entry in Data.ToList())
            {
                res += 
                entry.Value.Id + "\t" +
                entry.Value.StartPointValue + "\t" +
                entry.Value.EndPointValue + "\t" +
                entry.Value.PointType + "\t" +
                entry.Value.StartId + "\t"+
                entry.Value.EndId +"\t\n";
            }
            return res;
        }
    }
}
