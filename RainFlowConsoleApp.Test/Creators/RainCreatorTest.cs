using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RainFlowConsoleApp.CreatorsImplementation;

namespace RainFlowConsoleApp.Test.Creators
{
    [TestFixture]
    class RainCreatorTest
    {
        [Test]
        public void GetListFlows_Test1()
        {
            //http://fsapr2000.ru/topic/68929-metod-dozhdia/
            var dataCreator = new DataCreator();
            var rainCreator = new RainCreator();
            string input = "-10 10 -20 40 20 40 0 20 -30 -10 -40 30 10 70 -10 10 -50 0 -30 50 -20 10 -10 30";
            var list = rainCreator.GetListFlows(input, dataCreator);
            const string expectedResult = @"10 -20 40 -40 40 20 20 0 -10 -30 70 10 30 -50 10 -10 50 -30 0 -20 30 -10 10 ";

            var names = list.Select(x => x.Value.EndPointValue);
            var result = String.Join(" ", names.ToArray());

            Assert.AreEqual(result, expectedResult);
        }

        [Test]
        public void GetListFlows_Test2()
        {
            //https://www.google.ru/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&ved=0ahUKEwj8osSV7NXPAhWGjiwKHeqfC10QjRwIBw&url=http%3A%2F%2Fwww.sigi.ca%2Fengineering%2Fsubsites%2Fsteel_eurofatigue%2Floads_reservoirmethod.html&psig=AFQjCNGvJvqbgdz6f-BOoXRF5VJPqKyqNA&ust=1476381537448800
            var dataCreator = new DataCreator();
            var rainCreator = new RainCreator();
            string input = "-5 3 -2 5 1 3 -3 -2 -5";
            var list = rainCreator.GetListFlows(input, dataCreator);
            const string expectedResult = "5 -2 3 -5 3 1 -2 -3 ";

            var names = list.Select(x => x.Value.EndPointValue);
            var result = String.Join(" ", names.ToArray());

            Assert.AreEqual(result, expectedResult);
        }

        [Test]
        public void GetListFlows_Test3()
        {
            var dataCreator = new DataCreator();
            var rainCreator = new RainCreator();
            string input = "-5 -2 -1,215 3 -2 5 1 3 -3 -2 -3,2222 -5";
            var list = rainCreator.GetListFlows(input, dataCreator);
            const string expectedResult = "5 -2 3 -5 3 1 -2 -3 ";

            var names = list.Select(x => x.Value.EndPointValue);
            var result = String.Join(" ", names.ToArray());

            Assert.AreEqual(result, expectedResult);
        }
    }
}
