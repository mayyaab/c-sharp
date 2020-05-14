using Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameTest
{
    [TestClass]
    public class FieldTest
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
        public void TestRemoveLinesVertical()
        {
            var field = new Field();

            field.SetBallColorAt(new Position(1, 2), BallColor.White);
            field.SetBallColorAt(new Position(2, 2), BallColor.White);
            field.SetBallColorAt(new Position(3, 2), BallColor.White);
            field.SetBallColorAt(new Position(4, 2), BallColor.White);

            field.RemoveLines(new Position(2, 2));

            Assert.AreEqual(BallColor.Empty, field.GetBallColorAt(1, 2));
            Assert.AreEqual(BallColor.Empty, field.GetBallColorAt(2, 2));
            Assert.AreEqual(BallColor.Empty, field.GetBallColorAt(3, 2));
            Assert.AreEqual(BallColor.Empty, field.GetBallColorAt(4, 2));
        }


        [TestMethod]
        public void TestRemoveLinesHorizontal()
        {
            var field = new Field();

            field.SetBallColorAt(new Position(0, 0), BallColor.Red);
            field.SetBallColorAt(new Position(0, 1), BallColor.Red);
            field.SetBallColorAt(new Position(0, 2), BallColor.Red);
            field.SetBallColorAt(new Position(0, 3), BallColor.Red);
            field.SetBallColorAt(new Position(0, 4), BallColor.Red);

            field.RemoveLines(new Position(0, 0));

            Assert.AreEqual(BallColor.Empty, field.GetBallColorAt(0,0));
            Assert.AreEqual(BallColor.Empty, field.GetBallColorAt(0, 1));
            Assert.AreEqual(BallColor.Empty, field.GetBallColorAt(0, 2));
            Assert.AreEqual(BallColor.Empty, field.GetBallColorAt(0, 3));
            Assert.AreEqual(BallColor.Empty, field.GetBallColorAt(0, 4));
        }

        [TestMethod]
        public void TestRemoveLinesDescending()
        {
            var field = new Field();

            field.SetBallColorAt(new Position(0, 0), BallColor.Red);
            field.SetBallColorAt(new Position(1, 1), BallColor.Red);
            field.SetBallColorAt(new Position(2, 2), BallColor.Red);
            field.SetBallColorAt(new Position(3, 3), BallColor.Red);

            field.RemoveLines(new Position(0, 0));

            Assert.AreEqual(BallColor.Empty, field.GetBallColorAt(0, 0));
            Assert.AreEqual(BallColor.Empty, field.GetBallColorAt(1, 1));
            Assert.AreEqual(BallColor.Empty, field.GetBallColorAt(2, 2));
            Assert.AreEqual(BallColor.Empty, field.GetBallColorAt(3, 3));
        }

        [TestMethod]
        public void TestRemoveLinesAscending()
        {
            var field = new Field();

            field.SetBallColorAt(new Position(0, 3), BallColor.Yellow);
            field.SetBallColorAt(new Position(1, 2), BallColor.Yellow);
            field.SetBallColorAt(new Position(2, 1), BallColor.Yellow);
            field.SetBallColorAt(new Position(3, 0), BallColor.Yellow);

            field.RemoveLines(new Position(0, 3));

            Assert.AreEqual(BallColor.Empty, field.GetBallColorAt(0, 3));
            Assert.AreEqual(BallColor.Empty, field.GetBallColorAt(1, 2));
            Assert.AreEqual(BallColor.Empty, field.GetBallColorAt(2, 1));
            Assert.AreEqual(BallColor.Empty, field.GetBallColorAt(3, 0));
        }

        [TestMethod]
        public void TestNotRemoveLinesLessThan4()
        {
            var field = new Field();

            field.SetBallColorAt(new Position(1, 2), BallColor.White);
            field.SetBallColorAt(new Position(2, 2), BallColor.White);
            field.SetBallColorAt(new Position(3, 2), BallColor.White);

            field.RemoveLines(new Position(2, 3));

            Assert.AreEqual(BallColor.White, field.GetBallColorAt(1, 2));
            Assert.AreEqual(BallColor.White, field.GetBallColorAt(2, 2));
            Assert.AreEqual(BallColor.White, field.GetBallColorAt(3, 2));
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