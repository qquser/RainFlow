using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RF.CreatorsImplementation;
using RF.Data;
using RF.DataImplementation;
using RF.LinkedList;

namespace RF.Test.Creators
{
    [TestFixture]
    public class DataCreatorTest 
    {
        [Test]
        public void CreateList_OnlyMinAndMax()
        {
            var dataCreator = new DataCreator();
            var list = dataCreator.CreateList("0 0 1 2 3 1").ToList();
            const string expectedResult = @"0 3 1";

            var names = list.Select(x => x.Value.StartPointValue);
            var result = string.Join(" ", names.ToArray()); 

            Assert.AreEqual(result, expectedResult);
        }

        [Test]
        public void CreateList_EqualEmpty()
        {
            var dataCreator = new DataCreator();
            var list = dataCreator.CreateList("0 0 0 0 0 0").ToList();
            const string expectedResult = @"";

            var names = list.Select(x => x.Value.StartPointValue);
            var result = string.Join(" ", names.ToArray());

            Assert.AreEqual(result, expectedResult);
        }

        [Test]
        public void CreateList_EqualTwoPoints()
        {
            var dataCreator = new DataCreator();
            var list = dataCreator.CreateList("0 0 0 0 0 0 1 1 1 1 1 1 1 1 1 1").ToList();
            const string expectedResult = @"0 1";

            var names = list.Select(x => x.Value.StartPointValue);
            var result = string.Join(" ", names.ToArray());

            Assert.AreEqual(result, expectedResult);
        }

        [Test]
        public void CreateList_MinMax()
        {
            var dataCreator = new DataCreator();
            var list = dataCreator.CreateList("0 0 0 0 0 0 1 1 -5 5 -3 -2 -2").ToList();
            const string expectedResult = @"Min Max Min Max Min Max";

            var names = list.Select(x => x.Value.PointType.ToString());
            var result = string.Join(" ", names.ToArray());

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void CreateList_ParseDecimal()
        {
            var dataCreator = new DataCreator();
            var list = dataCreator.CreateList("0.1 0,2 0.3 0.4 0.5 0,77 1,1 1,1 -5.55454654 5 -3 -2 -2").ToList();
            const string expectedResult = @"0.1 1.1 -5.55454654 5 -3 -2";
            string expectedResultDecemal =
                string.Join(" ",
                    expectedResult.Split(' ').ToList().Select(x => decimal.Parse(x, CultureInfo.InvariantCulture)));

            var names = list.Select(x => x.Value.StartPointValue);
            var result = string.Join(" ", names.ToArray());

            Assert.That(result, Is.EqualTo(expectedResultDecemal));
        }

        [Test]
        public void CreateList_ParseDecimalMinMax()
        {
            var dataCreator = new DataCreator();
            var list = dataCreator.CreateList("0.1 0,2 0.3 0.4 0.5 0,77 1 1 -5.55454654 5 -3 -2 -2").ToList();
            const string expectedResult = @"Min Max Min Max Min Max";

            var names = list.Select(x => x.Value.PointType.ToString());
            var result = string.Join(" ", names.ToArray());

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
