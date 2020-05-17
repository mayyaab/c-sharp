﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameTest
{

    [TestClass]
    class CommandsTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var commands = new Commands();
            bool changed;
            commands.Add("name", () => { changed = true; });

            // test1
            changed = false;
            commands.Run("name");
            Assert.AreEqual(true, changed);

            // test 2
            changed = false;
            commands.Run("NAME");
            Assert.AreEqual(true, changed);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var commands = new Commands();
            bool changed1 = false;
            bool changed2 = false;
            commands.Add("name1", "description1", () => changed1 = true);
            commands.Add("name2", "description2", () => changed2 = true);

            commands.Run(1);
            Assert.AreEqual(false, changed1);
            Assert.AreEqual(true, changed2);
        }
    }
}
