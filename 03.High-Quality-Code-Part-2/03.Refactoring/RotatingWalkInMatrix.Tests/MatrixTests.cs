namespace RotatingWalkInMatrix.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RotatingWalkInMatrix;

    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExpectToThrowIfZeroSizeIsPassed()
        {
            MatrixGenerator matrix = new MatrixGenerator(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExpectToThrowIfNegativeSizeIsPassed()
        {
            MatrixGenerator matrix = new MatrixGenerator(-5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExpectToThrowIfBiggerThanTheAllowedSizeIsPassed()
        {
            MatrixGenerator matrix = new MatrixGenerator(101);
        }

        [TestMethod]
        public void ExpectProperResultForSizeOne()
        {
            MatrixGenerator matrix = new MatrixGenerator(1);

            Assert.IsTrue(matrix.ToString() == string.Format("  1\r\n"));
        }

        [TestMethod]
        public void ExpectProperResultForSizeTwo()
        {
            MatrixGenerator matrix = new MatrixGenerator(2);

            Assert.IsTrue(matrix.ToString() == string.Format("  1  4\r\n  3  2\r\n"));
        }

        [TestMethod]
        public void ExpectProperResultForSizeThree()
        {
            MatrixGenerator matrix = new MatrixGenerator(3);

            Assert.IsTrue(matrix.ToString() == string.Format("  1  7  8\r\n  6  2  9\r\n  5  4  3\r\n"));
        }

        [TestMethod]
        public void ExpectProperResultForSizeFive()
        {
            MatrixGenerator matrix = new MatrixGenerator(5);
            var expectedResult = new string[]
            {
                "  1 13 14 15 16",
                " 12  2 21 22 17",
                " 11 23  3 20 18",
                " 10 25 24  4 19",
                "  9  8  7  6  5\r\n"
            };

            Assert.AreEqual(string.Join("\r\n", expectedResult), matrix.ToString());
        }

        [TestMethod]
        public void ExpectProperResultForSizeSix()
        {
            MatrixGenerator matrix = new MatrixGenerator(6);
            var expectedResult = new string[]
            {
                "  1 16 17 18 19 20",
                " 15  2 27 28 29 21",
                " 14 31  3 26 30 22",
                " 13 36 32  4 25 23",
                " 12 35 34 33  5 24",
                " 11 10  9  8  7  6\r\n"
            };

            Assert.AreEqual(string.Join("\r\n", expectedResult), matrix.ToString());
        }
    }
}
