using System.Collections.Generic;
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

            Assert.AreEqual(initialEmptyCount - Field.ballsCount, CountEmptySquares(field));
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
