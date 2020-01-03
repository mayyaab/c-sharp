using Microsoft.VisualStudio.TestTools.UnitTesting;
using List1;
using System;

namespace List1UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddOneElement()
        {
            List list = new List();
            var res = list.GetSize();
            Assert.AreEqual(0, res);
            list.AddElement(12);
            res = list.GetSize();
            Assert.AreEqual(1, res);
            var value = list.GetValueOfElement(0);
            Assert.AreEqual(12, value);
        }

        [TestMethod]
        public void TestIndexIsBigger()
        {
            List list = new List();
            list.AddElement(13);
            var value = 0;
            Assert.ThrowsException<IndexOutOfRangeException>(() => value = list.GetValueOfElement(20));
        }

        [TestMethod]
        public void TestIndexIsBiggerBorderCase()
        {
            List list = new List();
            list.AddElement(10);
            list.AddElement(11);

            var value = 0;
            Assert.ThrowsException<IndexOutOfRangeException>(() => value = list.GetValueOfElement(2));
        }

        [TestMethod]
        public void TestIndexIsNegative()
        {
            List list = new List();
            list.AddElement(10);

            var value = 0;
            Assert.ThrowsException<IndexOutOfRangeException>(() => value = list.GetValueOfElement(-1));
        }

        [TestMethod]
        public void TestIndex0innoList()
        {
            List list = new List();
            var value = 0;
            Assert.ThrowsException<IndexOutOfRangeException>(() => value = list.GetValueOfElement(0));
        }

        [TestMethod]
        public void TestDeleteElemet1()
        {
            List list = new List();
            list.AddElement(123);
            list.AddElement(124);
            var res = list.GetSize();
            Assert.AreEqual(2, res);
            list.DeleteNElement(1);
            res = list.GetSize();
            Assert.AreEqual(1, res);
        }

        [TestMethod]
        public void TestDeleteElementInEmptyList()
        {
            List list = new List();
            Assert.ThrowsException<IndexOutOfRangeException>(() => list.DeleteNElement(0));
        }

        [TestMethod]
        public void TestDeleteElementIsBiggerThenListSize()
        {
            List list = new List();
            list.AddElement(123);
            Assert.ThrowsException<IndexOutOfRangeException>(() => list.DeleteNElement(1));
        }

        [TestMethod]
        public void TestAddSecondElement()
        {
            List list = new List();
            list.AddElement(123);
            list.AddElement(124);
            var res = list.GetSize();
            Assert.AreEqual(2, res);
            list.AddNElement(1, 125);
            res = list.GetSize();
            Assert.AreEqual(3, res);
        }
        [TestMethod]
        public void TestAddElementIsBiggerThenListSize()
        {
            List list = new List();
            list.AddElement(123);
            Assert.ThrowsException<IndexOutOfRangeException>(() => list.AddNElement(2, 1234));
        }



        [TestMethod]
        public void TestDeleteElement_11()
        {
            List list = new List();
            list.AddElement(1);
            list.AddElement(2);
            list.AddElement(1);
            list.AddElement(11);
            list.AddElement(5);
            var res = list.GetSize();
            Assert.AreEqual(5, res);
            list.DeleteElementByValue(11);
            res = list.GetSize();
            Assert.AreEqual(4, res);
        }

        



    }
}
