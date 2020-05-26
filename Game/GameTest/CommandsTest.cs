using System;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameTest
{
    // TG: Consider implementing class CommandList using "OrderedDictionary"
    // https://docs.microsoft.com/en-us/dotnet/api/system.collections.specialized.ordereddictionary?view=netcore-3.1

    [TestClass]
    public class CommandsTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var commands = new CommandList();
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
        public void TestMethod1_1()
        {
            var commands = new CommandList();
            bool changed;
            commands.Add("name", () => { changed = true; });

            // test1
            changed = false;
            commands.Run(0, "name");
            Assert.AreEqual(true, changed);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var commands = new CommandList();
            var changed1 = false;
            var changed2 = false;
            commands.Add("name1", "descriprion1", () => changed1 = true);
            commands.Add("name2", "descriprion2", () => changed2 = true);

            commands.Run(1);
            Assert.AreEqual(false, changed1);
            Assert.AreEqual(true, changed2);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var commands = new CommandList();

            commands.Add("name1", "desc1",() => { });
            commands.Add("name2", "desc2", () => { });

            var cmd = commands.GetCommand(0);
            var name = cmd.Name;
            var description = cmd.Description;
            var action = cmd.CommandAction;

            Assert.AreEqual("name1", name);
            Assert.AreEqual("desc1", description);
           // Assert.AreEqual(() => { }, action);

            cmd = commands.GetCommand(1);
            name = cmd.Name;
            description = cmd.Description;
            action = cmd.CommandAction;

            Assert.AreEqual("name2", name);
            Assert.AreEqual("desc2", description);
            //Assert.AreEqual(() => { }, action);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var commands = new CommandList();

            commands.Add("name1", () => { });
            commands.Add("name2", () => { });
            commands.Add("name3", () => { });

            var size = commands.GetSize();

            Assert.AreEqual(3, size);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var commands = new CommandList();

            commands.Add("name1", "description1", () => { });
            commands.Add("name2", "description2", () => { });
            commands.Add("name3", "description3", () => { });

            commands.PrintCommandList();
        }
    }
}
