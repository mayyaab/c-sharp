using System;
using Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var field = new Field();

            int initialEmptyCount = field.Width * field.Height;
            Assert.AreEqual(initialEmptyCount, CountEmptySquares(field));

            field.PlaceBalls();

            Assert.AreEqual(initialEmptyCount - field.BallsCount, CountEmptySquares(field));
        }

        [TestMethod]
        public void TesTestMethod2()
        {
            var field = new Field();

            field.SetBallColorAt(new Position(2,2), BallColor.Red);
            field.SetBallColorAt(new Position(2,3), BallColor.Red);
            field.SetBallColorAt(new Position(2,4), BallColor.Red);

            var line = field.GetLineHorizontal(new Position(2, 2));
            Assert.AreEqual(line.Count, 3);
        }


        [TestMethod]
        public void TesTestMethod3()
        {
            var field = new Field();

            field.SetBallColorAt(new Position(0, 0), BallColor.Red);
            field.SetBallColorAt(new Position(0, 1), BallColor.Red);
            field.SetBallColorAt(new Position(0, 2), BallColor.Red);
            field.SetBallColorAt(new Position(0, 3), BallColor.Red);

            field.RemoveLines(new Position(0, 0));
            Assert.AreEqual(BallColor.Empty, field.GetBallColorAt(0,0));
            Assert.AreEqual(BallColor.Empty, field.GetBallColorAt(0, 1));
            Assert.AreEqual(BallColor.Empty, field.GetBallColorAt(0, 2));
            Assert.AreEqual(BallColor.Empty, field.GetBallColorAt(0, 3));
        }

        [TestMethod]
        public void TesTestMethod4()
        {
            var field = new Field();

            field.SetBallColorAt(new Position(0, 0), BallColor.Red);
            field.SetBallColorAt(new Position(1, 0), BallColor.Red);
            field.SetBallColorAt(new Position(2, 0), BallColor.Red);

            var line = field.GetLineHorizontal(new Position(1, 0));
            Assert.AreEqual(line.Count, 3);
        }

        [TestMethod]
        public void TesTestMethod5()
        {
            var field = new Field();

            field.SetBallColorAt(new Position(2, 2), BallColor.Red);
            field.SetBallColorAt(new Position(2, 3), BallColor.Red);
            field.SetBallColorAt(new Position(2, 4), BallColor.Red);

            var line = field.GetLineHorizontal(new Position(2, 2));
            Assert.AreEqual(line.Count, 3);
        }

        private static int CountEmptySquares(Field field)
        {
            int emptyCount = 0;

            for (int row = 0; row < field.Height; row++)
            {
                for (int col = 0; col < field.Width; col++)
                {
                    if (field.GetBallColorAt(row, col) == BallColor.Empty)
                    {
                        ++emptyCount;
                    }
                }
            }

            return emptyCount;
        }
    }
}
