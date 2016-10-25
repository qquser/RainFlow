using System;
using RainFlowConsoleApp.Data;

namespace RainFlowConsoleApp.DataImplementation
{
    public class FlowData : IData
    {
        public int Id { get; set; }
        public decimal StartPointValue { get; set; }
        public decimal? EndPointValue { get; set; }
        public EnumPointType PointType { get; set; }
        public int StartId { get; set; }
        public int EndId { get; set; }
        public bool MinFlowAlreadyExist { get; set; }
        public bool MaxFlowAlreadyExist { get; set; }
    }
}
