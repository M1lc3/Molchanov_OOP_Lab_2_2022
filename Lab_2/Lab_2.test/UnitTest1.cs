using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab_2.test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSumMatrix()
        {
            // arrange 
            MyMatrix myDoubleMatrix = new MyMatrix(new double[,]
            {
                {1, 2 ,3},
                {4, 5 ,6},
                {7, 8 ,9}
            });

            MyMatrix myStringMatrix = new MyMatrix(new string[]
            {
                "1 2 3",
                "4 5 6",
                "7 8 9"
            });

            // act
            MyMatrix actualSum = new MyMatrix(myDoubleMatrix + myStringMatrix);

            // assert
            MyMatrix expected = new MyMatrix(new double[,]
            {
                {2, 4 ,6},
                {8, 10 ,12},
                {14, 16 ,18}
            });
            Assert.AreEqual(expected, actualSum);
        }

        [TestMethod]
        public void TestMultMatrix()
        {
            // arrange
            MyMatrix myStringMatrix = new MyMatrix(new string[]
            {
                "1 2",
                "4 5",
                "7 8"
            });

            MyMatrix myDoubleArray = new MyMatrix(new double[][]
            {
                new double[] {1, 2, 3},
                new double[] {4, 5, 6}
            });

            // act
            MyMatrix actualMult = new MyMatrix(myStringMatrix * myDoubleArray);

            // assert
            MyMatrix expected = new MyMatrix(new double[,]
            {
                {9, 12 ,15},
                {24, 33 ,42},
                {39, 54 ,69}
            });
            Assert.AreEqual(expected, actualMult);
        }

        [TestMethod]
        public void TestIncorrectSum()
        {
            // arrange
            MyMatrix myIncorrectStringMatrix = new MyMatrix(new string[]
            {
                "1 2 3",
                "4 5 6",
                "7 8 9"
            });

            MyMatrix myIncorrectDoubleArray = new MyMatrix(new double[][]
            {
                    new double[] {1, 2, 3},
                    new double[] {4, 5},
                    new double[] {7, 8, 9}
            });

            // act
            MyMatrix actualIncorrectSum = new MyMatrix(myIncorrectStringMatrix + myIncorrectDoubleArray);

            // assert
            Assert.AreEqual(0, actualIncorrectSum);
        }

        [TestMethod]
        public void TestTranspositionDouble()
        {
            // arrange
            MyMatrix myDoubleMatrix = new MyMatrix(new double[,]
            {
                    {1, 2, 3},
                    {4, 5, 6},
                    {7, 8, 9}
            });

            // assert
            MyMatrix expectedDouble = new MyMatrix(new double[,]
            {
                    {1, 4, 7},
                    {2, 5, 8},
                    {3, 6, 9}
            });

            Assert.AreEqual(expectedDouble, myDoubleMatrix.GetTransponedCopy());
        }

        [TestMethod]
        public void TestTranspositionString()
        {
            // arrange
            MyMatrix myStringMatrix = new MyMatrix(new string[]
            {
                    "1 2",
                    "4 5",
                    "7 8"
            });

            MyMatrix expectedString = new MyMatrix(new double[,]
            {
                    {1, 4 ,7},
                    {2, 5 ,8}
            });

            // assert
            Assert.AreEqual(expectedString, myStringMatrix.GetTransponedCopy());
        }

        [TestMethod]
        public void TestTranspositionArray()
        {
            // arrange
            MyMatrix myDoubleArray = new MyMatrix(new double[][]
            {
                    new double[] {1, 2, 3},
                    new double[] {4, 5, 6}
            });

            MyMatrix expectedArray = new MyMatrix(new double[,]
            {
                    {1, 4},
                    {2, 5},
                    {3, 6}
            });

            // assert
            Assert.AreEqual(expectedArray, myDoubleArray.GetTransponedCopy()); 
        }

    }
}
