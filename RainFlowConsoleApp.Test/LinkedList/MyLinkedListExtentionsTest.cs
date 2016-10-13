using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RainFlowConsoleApp.Data;
using RainFlowConsoleApp.DataImplementation;
using RainFlowConsoleApp.LinkedList;

namespace RainFlowConsoleApp.Test.LinkedList
{
    [TestFixture]
    public class MyLinkedListExtentionsTest
    {
        [Test]
        public void RemoveListNodesById_CountEqual2()
        {
            var list = new MyLinkedList<IData>();
            var data1 = new FlowData { Id = 1, PointType = EnumPointType.None };
            var data2 = new FlowData { Id = 2 };
            var data3 = new FlowData { Id = 3, PointType = EnumPointType.None };
            var data5 = new FlowData { Id = 5 };
            list.AddAfter(null, data1);
            list.AddAfter(1, data2);
            list.AddAfter(2, data3);
            list.AddAfter(2, data5);

            var listIds = list.Where(x => x.Value.PointType == EnumPointType.None).Select(x => x.Value.Id).ToList();
            list.RemoveListNodesById(listIds);

            Assert.AreEqual(list.Count(), 2);
        }

        [Test]
        public void RemoveListNodesById_FirstEqual2()
        {
            var list = new MyLinkedList<IData>();
            var data1 = new FlowData { Id = 1, PointType = EnumPointType.None };
            var data2 = new FlowData { Id = 2 };
            var data3 = new FlowData { Id = 3, PointType = EnumPointType.None };
            var data5 = new FlowData { Id = 5 };
            list.AddAfter(null, data1);
            list.AddAfter(1, data2);
            list.AddAfter(2, data3);
            list.AddAfter(2, data5);

            var listIds = list.Where(x => x.Value.PointType == EnumPointType.None).Select(x => x.Value.Id).ToList();
            list.RemoveListNodesById(listIds);

            Assert.AreEqual(list.First().Value.Id, 2);
        }

        [Test]
        public void RemoveListNodesById_LastEqual2()
        {
            var list = new MyLinkedList<IData>();
            var data1 = new FlowData { Id = 1, PointType = EnumPointType.None };
            var data2 = new FlowData { Id = 2 };
            var data3 = new FlowData { Id = 3, PointType = EnumPointType.None };
            var data5 = new FlowData { Id = 5 };
            list.AddAfter(null, data1);
            list.AddAfter(1, data2);
            list.AddAfter(2, data3);
            list.AddAfter(2, data5);

            var listIds = list.Where(x => x.Value.PointType == EnumPointType.None).Select(x => x.Value.Id).ToList();
            list.RemoveListNodesById(listIds);

            Assert.AreEqual(list.Last().Value.Id, 5);
        }
    }
}
