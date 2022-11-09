using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Lab_2
{
    public partial class MyMatrix
    {
        //_________________________________Operators_____________________________________
        //===============================================================================
        public static MyMatrix operator +(MyMatrix matrix1, MyMatrix matrix2)
        {
            return Add(matrix1, matrix2);
        }
        public static MyMatrix operator *(MyMatrix matrix1, MyMatrix matrix2)
        {
            return Multiply(matrix1, matrix2);
        }
        //===============================================================================

        //_________________________________Methods_______________________________________
        //===============================================================================

        //---------------------------------For Constuctors-------------------------------
        static public double[,] ConvertArrayToMatrix(double[][] array) // Convert jagged array to matrix
        {
            int rows = array[0].Length;
            double[,] temp = new double[array.Length, rows];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Length == rows)
                {
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        temp[i, j] = array[i][j];
                    }
                }
                else
                {
                    throw new ArgumentException("Array is not rectangular!!!");
                }
            }
            return temp;
        }
        static public double[,] ConvertStringArrToMatrix(string[] strings) // Convert string array to matrix
        {
            string[] tempstr = Convert.ToString(strings[0]).Trim().Split();
            double[,] temp = new double[strings.Length, tempstr.Length];
            for (int i = 0; i < strings.Length; i++)
            {
                tempstr = strings[i].Trim().Split();
                for (int j = 0; j < tempstr.Length; j++)
                {
                    temp[i, j] = Convert.ToDouble(tempstr[j]);  
                }
            }
            return temp;
        }
        //-------------------------------------------------------------------------------
        
        //------------------------------------Calc---------------------------------------
        static MyMatrix Add(MyMatrix matrix1, MyMatrix matrix2)
        {
            int m1Rows = getWidthMatrix(matrix1.Matrix);
            int m2Rows = getWidthMatrix(matrix2.Matrix);
            int m1Cols = getHeightMatrix(matrix1.Matrix);
            int m2Cols = getHeightMatrix(matrix2.Matrix);

            if (m1Rows == m2Rows && m1Cols == m2Cols)
            {
                MyMatrix returns = new MyMatrix(new double[m1Rows, m1Cols]);
                for (int i = 0; i < m1Cols; i++)
                {
                    for (int j = 0; j < m1Rows; j++)
                    {
                        returns.matrix[i, j] = matrix1.matrix[i, j] + matrix2.matrix[i, j];
                    }
                }
                return returns;
            }
            else
            {
                throw new ArgumentException("The matrices are not equal");
            }
        }

        static MyMatrix Multiply(MyMatrix matrix1, MyMatrix matrix2)
        {
            int m1Rows = getWidthMatrix(matrix1.Matrix);
            int m2Rows = getWidthMatrix(matrix2.Matrix);
            int m1Cols = getHeightMatrix(matrix1.Matrix);
            int m2Cols = getHeightMatrix(matrix2.Matrix);

            if (m1Cols != m2Rows)
            {
                throw new Exception("Multiplication is not possible! The number of columns in the first matrix is ​​not equal to the number of rows in the second matrix.");
            }

            MyMatrix returns = new MyMatrix(new double[m1Rows, m2Cols]);

            for (int i = 0; i < m1Rows; i++)
            {
                for (int j = 0; j < m2Cols; j++)
                {
                    returns.matrix[i, j] = 0;

                    for (int k = 0; k < m1Cols; k++)
                    {
                        returns.matrix[i, j] += matrix1.matrix[i, k] * matrix2.matrix[k, j];
                    }
                }
            }
            return returns;
        }
        //-------------------------------------------------------------------------------

        //-----------------------------------Transposition-------------------------------
        protected double[,] GetTransponedArray()
        {
            double[,] transponsed = new double[getHeightMatrix(matrix), getWidthMatrix(matrix)];
            for (int i = 0; i < getHeightMatrix(matrix); i++)
            {
                for (int j = 0; j < getWidthMatrix(matrix); j++)
                {
                    transponsed[i, j] = matrix[j, i];
                }
            }
            return transponsed;
        }
        public MyMatrix GetTransponedCopy() 
        { 
            return new MyMatrix(GetTransponedArray()); 
        }

        public void TransponeMe(double[,] matrix)
        {
            matrix = GetTransponedArray();
        }
        //-------------------------------------------------------------------------------
        //===============================================================================
    }
}
