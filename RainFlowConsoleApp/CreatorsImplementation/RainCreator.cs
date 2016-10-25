using RainFlowConsoleApp.Data;
using System.Collections.Generic;
using System.Linq;
using RainFlowConsoleApp.Creators;
using RainFlowConsoleApp.DataImplementation;
using RainFlowConsoleApp.LinkedList;

namespace RainFlowConsoleApp.CreatorsImplementation
{
    public class RainCreator : IRainCreator<FlowData>
    {
        public MyLinkedList<FlowData> GetListFlows(string input, IDataCreator<FlowData> dataCreator)
        {
            MyLinkedList<FlowData> list = dataCreator.CreateList(input);
            foreach (Node<FlowData> item in list)
            {
                if (item.Value.PointType == EnumPointType.Min)
                    StartMinFlow(item.Value.Id, list);
                else if (item.Value.PointType == EnumPointType.Max)
                    StartMaxFlow(item.Value.Id, list);
            }
            return list;
        }

        private void StartMinFlow(int startIndex, MyLinkedList<FlowData> list)
        {
            var startValue = list.FirstOrDefault(x=>x.Value.Id == startIndex)?.Value;
            if (startValue == null || startValue.PointType == EnumPointType.Max)
                return;
            startValue.StartId = startValue.Id;
            foreach (var entry in list.Where(x => x.Value.Id >= startIndex))
            {
                var item = entry.Value;
                //Поток, начавшийся в точке минимума, прерывается, когда встретится минимум меньший, чем исходный.  
                var maxItem = list.Where(x => x.Value.Id >= startIndex && x.Value.Id < item.Id).ToList();
                decimal? maxValue = null;
                if (maxItem.Any())
                    maxValue = maxItem.Max(x => x.Value.StartPointValue);

                if (item.StartPointValue < startValue.StartPointValue)
                {
                    startValue.EndPointValue = maxValue;
                    startValue.EndId = entry.Value.Id;
                    return;
                }

                //При встрече на одной из крыш нескольких потоков движение продолжает тот,
                //который берет начало в экстремуме с меньшим номером, а остальные прерываются.
                var previousItem = entry.Previous?.Value;
                var nextItem = entry.Next?.Value;
                if (previousItem != null && nextItem != null && item.MinFlowAlreadyExist && nextItem.StartPointValue > previousItem.StartPointValue)
                {
                    startValue.EndPointValue = previousItem.StartPointValue;
                    startValue.EndId = entry.Value.Id;
                    return;
                }

                // Поток, не встретивший препятствий, падает на землю
                var endItem = list.Where(x => x.Value.Id > startIndex).ToList(); 
                decimal? endValue = null;
                if (endItem.Any())
                    endValue = endItem.Max(x => x.Value.StartPointValue);
                if (item.StartPointValue == endValue)
                {
                    startValue.EndPointValue = endValue;
                    startValue.EndId = entry.Value.Id;
                    return;
                }
                //Течет дальше
                item.MinFlowAlreadyExist = true;
            }

        }

        private void StartMaxFlow(int startIndex, MyLinkedList<FlowData> list)
        {
            var startValue = list.FirstOrDefault(x => x.Value.Id == startIndex)?.Value;
            if (startValue == null || startValue.PointType == EnumPointType.Min)
                return;

            startValue.StartId = startValue.Id;
            foreach (var entry in list.Where(x => x.Value.Id >= startIndex))
            {
                var item = entry.Value;
                var minItem = list.Where(x => x.Value.Id >= startIndex && x.Value.Id < item.Id).ToList(); 
                decimal? minValue = null;
                if (minItem.Any())
                    minValue = minItem.Min(x => x.Value.StartPointValue);

                if (item.StartPointValue > startValue.StartPointValue)
                {
                    startValue.EndPointValue = minValue;
                    startValue.EndId = entry.Value.Id;
                    return;
                }

                var previousItem = entry.Previous?.Value;
                var nextItem = entry.Next?.Value;
                if (previousItem != null && nextItem != null && item.MaxFlowAlreadyExist && nextItem.StartPointValue < previousItem.StartPointValue)
                {
                    startValue.EndPointValue = previousItem.StartPointValue;
                    startValue.EndId = entry.Value.Id;
                    return;
                }

                var endItem = list.Where(x => x.Value.Id > startIndex).ToList(); 
                decimal? endValue = null;
                if (endItem.Any())
                    endValue = endItem.Min(x => x.Value.StartPointValue);
                if (item.StartPointValue == endValue)
                {
                    startValue.EndPointValue = endValue;
                    startValue.EndId = entry.Value.Id;
                    return;
                }

                item.MaxFlowAlreadyExist = true;
            }
        }
    }
}
