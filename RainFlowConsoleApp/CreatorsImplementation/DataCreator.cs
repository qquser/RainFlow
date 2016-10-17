using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RainFlowConsoleApp.Creators;
using RainFlowConsoleApp.Data;
using RainFlowConsoleApp.DataImplementation;
using RainFlowConsoleApp.LinkedList;

namespace RainFlowConsoleApp.CreatorsImplementation
{
    public class DataCreator : IDataCreator<FlowData>
    {
        public MyLinkedList<FlowData> CreateList(string input)
        {
            int i = 0;
            var list = new MyLinkedList<FlowData>();

            foreach (var item in input.Split(' '))
            {
                int? previousId = i == 0 ? null : (int?)i - 1;
                var data = new FlowData
                {
                    Id = i++,
                    StartPointValue = decimal.Parse(item.Replace(',','.'), CultureInfo.InvariantCulture)
                };
                list.AddAfter(previousId, data);
            }
            FillPointType(list);
            return list;
        }

        private void FillPointType(MyLinkedList<FlowData> list)
        {
            DeleteDuplicatePoints(list);

            foreach (Node<FlowData> item in list)
            {
                if (item.Previous == null)
                {
                    FillTypeForFirstOrLastPoint(item.Value, item.Next?.Value);
                    continue;
                }

                if (item.Next == null)
                {
                    FillTypeForFirstOrLastPoint(item.Value, item.Previous.Value);
                    continue;
                }

                if (item.Previous.Value.StartPointValue > item.Value.StartPointValue && item.Next.Value.StartPointValue > item.Value.StartPointValue)
                    item.Value.PointType = EnumPointType.Min;
                else if (item.Previous.Value.StartPointValue < item.Value.StartPointValue && item.Next.Value.StartPointValue < item.Value.StartPointValue)
                    item.Value.PointType = EnumPointType.Max;
                else
                    item.Value.PointType = EnumPointType.None;
            }
            list.RemoveAll(x => x.PointType == EnumPointType.None);
        }


        private void FillTypeForFirstOrLastPoint(FlowData currentItem, FlowData nextOrPrevPoint)
        {
            if (nextOrPrevPoint == null)
            {
                currentItem.PointType = EnumPointType.None;
                return;
            }
            if (nextOrPrevPoint.StartPointValue > currentItem.StartPointValue)
                currentItem.PointType = EnumPointType.Min;
            else if (nextOrPrevPoint.StartPointValue < currentItem.StartPointValue)
                currentItem.PointType = EnumPointType.Max;
        }

        private void DeleteDuplicatePoints(MyLinkedList<FlowData> list)
        {
            foreach (Node<FlowData> item in list)
            {
                if (item.Value.StartPointValue == item.Previous?.Value?.StartPointValue)
                    item.Value.PointType = EnumPointType.None;
            }
            list.RemoveAll(x => x.PointType == EnumPointType.None);
        }
    }
}
