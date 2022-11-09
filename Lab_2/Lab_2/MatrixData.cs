using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_2
{
    public partial class MyMatrix
    {
        //______________________________Constuctors______________________________________
        //===============================================================================
        public MyMatrix()
        {
            matrix = new double[1, 1];
            matrix[0, 0] = 1;
        }     
        public MyMatrix(MyMatrix matrix)
        {
            this.matrix = matrix.matrix;
        }
        public MyMatrix(double[,] matrix)
        {
            this.matrix = matrix;
        }
        public MyMatrix(double[][] array)
        {
            this.matrix = ConvertArrayToMatrix(array);
        }
        public MyMatrix(string[] strings)
        {
            this.matrix = ConvertStringArrToMatrix(strings);
        }
        //===============================================================================

        //_________________________________Indexers______________________________________
        //===============================================================================    
        public double[,] Matrix
        {
            get { return matrix; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException();
                }
                else matrix = value;
            }
        }
        //===============================================================================

        //_________________________________Java style____________________________________
        static public int getWidthMatrix(double[,] matrix)
        {
            return matrix.GetLength(0);
        }
        static public int getHeightMatrix(double[,] matrix)
        {
            return matrix.GetLength(1);
        }
        public int GetHeight()
        {
            return this.matrix.GetLength(0);
        }
        public int GetWidth()
        {
            return this.matrix.GetLength(1);
        }
        //_______________________________________________________________________________ 

        //__________________________________ToString_____________________________________
        override public String ToString()
        {
            string returns = null;
            for (int i = 0; i < GetHeight(); i++)
            {
                for (int j = 0; j < GetWidth(); j++)
                {
                    returns += matrix[i,j].ToString() + ' ';  
                }
                returns += '\n';
            }
            return returns;
        }
        //_______________________________________________________________________________
    }
}
