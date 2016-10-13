using NUnit.Framework;
using RainFlowConsoleApp.Data;
using RainFlowConsoleApp.DataImplementation;
using RainFlowConsoleApp.LinkedList;

namespace RainFlowConsoleApp.Test.LinkedList
{
    [TestFixture]
    public class MyLinkedListTest
    {
        [Test]
        public void RemoveFirst_None_FirstEqual2()
        {
            var list = new MyLinkedList<IData>();
            var data1 = new FlowData { Id = 1, PointType = EnumPointType.None };
            var data2 = new FlowData { Id = 2 };
            var data3 = new FlowData { Id = 3, PointType = EnumPointType.None};
            var data5 = new FlowData { Id = 5 };
            list.AddAfter(null, data1);
            list.AddAfter(1, data2);
            list.AddAfter(2, data3);
            list.AddAfter(2, data5);

            list.RemoveFirst(x=>x.PointType == EnumPointType.None);

            Assert.AreEqual(list.Head.Value.Id, 2);
        }

        [Test]
        public void Remove_First_FirstEqual2()
        {
            var list = new MyLinkedList<IData>();
            var data1 = new FlowData { Id = 1 };
            var data2 = new FlowData { Id = 2 };
            var data3 = new FlowData { Id = 3 };
            var data5 = new FlowData { Id = 5 };
            list.AddAfter(null, data1);
            list.AddAfter(1, data2);
            list.AddAfter(2, data3);
            list.AddAfter(2, data5);

            list.RemoveFirst(x=>x.Id == 1);

            Assert.AreEqual(list.Head.Value.Id, 2);
        }

        [Test]
        public void Remove_First_FirstEqualNull()
        {
            var list = new MyLinkedList<IData>();
            var data1 = new FlowData { Id = 1 };
            list.AddAfter(null, data1);

            list.RemoveFirst(x => x.Id == 1);

            Assert.That(list.Head, Is.Null);
        }

        [Test]
        public void Remove_Second_SecondEqual5()
        {
            var list = new MyLinkedList<IData>();
            var data1 = new FlowData { Id = 1 };
            var data2 = new FlowData { Id = 2 };
            var data3 = new FlowData { Id = 3 };
            var data5 = new FlowData { Id = 5 };
            list.AddAfter(null, data1);
            list.AddAfter(1, data2);
            list.AddAfter(2, data3);
            list.AddAfter(2, data5);

            list.RemoveFirst(x => x.Id == 2);

            Assert.AreEqual(list.Head.Next.Value.Id, 5);
        }

        [Test]
        public void Remove_Second_NextLinkEqual5()
        {
            var list = new MyLinkedList<IData>();
            var data1 = new FlowData { Id = 1 };
            var data2 = new FlowData { Id = 2 };
            var data3 = new FlowData { Id = 3 };
            var data5 = new FlowData { Id = 5 };
            list.AddAfter(null, data1);
            list.AddAfter(1, data2);
            list.AddAfter(2, data3);
            list.AddAfter(2, data5);

            list.RemoveFirst(x => x.Id == 2);

            Assert.AreEqual(list.Head.Next.Next.Previous.Value.Id, 5);
        }

        [Test]
        public void Remove_Last_FirstEqualNull()
        {
            var list = new MyLinkedList<IData>();
            var data1 = new FlowData { Id = 1 };
            var data2 = new FlowData { Id = 2 };
            list.AddAfter(null, data1);
            list.AddAfter(1, data2);

            list.RemoveFirst(x => x.Id == 2);

            Assert.That(list.Head.Next, Is.Null);
        }



        [Test]
        public void AddAfter_CreateFirstValue_EqualTo1()
        {

            var list = new MyLinkedList<IData>();
            var data1 = new FlowData { Id = 1 };

            list.AddAfter(null, data1);

            Assert.AreEqual(list.Head.Value.Id, 1);
        }

        [Test]
        public void AddAfter_CreateFirstValue_PreviousValueIsNull()
        {

            var list = new MyLinkedList<IData>();
            var data1 = new FlowData { Id = 1 };

            list.AddAfter(null, data1);

            Assert.That(list.Head.Previous, Is.Null);
        }

        [Test]
        public void AddAfter_AddSecondAfterFirst_EqualTo2()
        {

            var list = new MyLinkedList<IData>();
            var data1 = new FlowData { Id = 1 };
            var data2 = new FlowData { Id = 2 };

            list.AddAfter(null, data1);
            list.AddAfter(1, data2);

            Assert.AreEqual(list.Head.Next.Value.Id, 2);
        }

        [Test]
        public void AddAfter_InSecondNode_PreviousValueEqualTo1()
        {

            var list = new MyLinkedList<IData>();
            var data1 = new FlowData { Id = 1 };
            var data2 = new FlowData { Id = 2 };

            list.AddAfter(null, data1);
            list.AddAfter(1, data2);

            Assert.AreEqual(list.Head.Next.Previous.Value.Id, 1);
        }

        [Test]
        public void AddAfter_AddBetweenFirstAndSecond_SecondEqual5()
        {

            var list = new MyLinkedList<IData>();
            var data1 = new FlowData { Id = 1 };
            var data2 = new FlowData { Id = 2 };
            var data5 = new FlowData { Id = 5 };

            list.AddAfter(null, data1);
            list.AddAfter(1, data2);
            list.AddAfter(1, data5);

            Assert.AreEqual(list.Head.Next.Value.Id, 5);
        }

        [Test]
        public void AddAfter_AddBetweenFirstAndSecond_PreviousInLastNodeEqual5()
        {

            var list = new MyLinkedList<IData>();
            var data1 = new FlowData { Id = 1 };
            var data2 = new FlowData { Id = 2 };
            var data5 = new FlowData { Id = 5 };

            list.AddAfter(null, data1);
            list.AddAfter(1, data2);
            list.AddAfter(1, data5);

            var last = list.Head.Next.Next;
            Assert.AreEqual(last.Previous.Value.Id, 5);
        }


        [Test]
        public void AddAfter_CheckPreviousIsNull()
        {

            var list = new MyLinkedList<IData>();
            var data1 = new FlowData { };
            var data2 = new FlowData {  };
            var data5 = new FlowData {  };

            list.AddAfter(null, data1);
            list.AddAfter(1, data2);
            list.AddAfter(1, data5);

            Assert.That(list.Head.Previous, Is.Null);
        }


        [Test]
        public void AddAfter_CheckNextIsNull()
        {

            var list = new MyLinkedList<IData>();
            var data1 = new FlowData { };
            var data2 = new FlowData { };
            var data5 = new FlowData { };

            list.AddAfter(null, data1);
            list.AddAfter(1, data2);
            list.AddAfter(1, data5);

            Assert.That(list.Head.Next, Is.Null);
        }


        [Test]
        public void AddAfter_EmptyData_CheckValueEqual0()
        {

            var list = new MyLinkedList<IData>();
            var data1 = new FlowData { };
            var data2 = new FlowData { };
            var data5 = new FlowData { };

            list.AddAfter(null, data1);
            list.AddAfter(1, data2);
            list.AddAfter(1, data5);

            Assert.AreEqual(list.Head.Value.Id, 0);
        }
    }
}
