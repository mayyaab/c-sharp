using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LinearDataStructures;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinearDataStructersUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Exercise4Test1()
        {
            /*List<int> intList = new List<int>(); //generic class able to select type <t>
            intList.Add(0);
            intList.Add(0);
            List<int> listToPrint = LongestSequensNumber(intList, ref currentValue, ref currentValueLength, ref maxValue, ref maxValueLength);
            */
        }

        public void Exercise65Test1()
        {
            List<int> ex5List = new List<int>();
            ex5List.Add(19);
            ex5List.Add(-10);
            ex5List.Add(12);
            ex5List.Add(-6);
            ex5List.Add(-3);
            ex5List.Add(34);
            ex5List.Add(-2);
            ex5List.Add(5);
            var res = ex5List.Count;
            Assert.AreEqual(8, res);
            List<int> positiveList = RemoveNegativeElements(ex5List);
            res = ex5List.Count;
            Assert.AreEqual(4, res);
        }
    }
}
