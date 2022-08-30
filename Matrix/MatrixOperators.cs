using System;

namespace Matrix
{
    public partial class Matrix
    {
        public static Matrix operator +(Matrix thisMatrix)
        {
            return new Matrix(thisMatrix._matrix);
        }

        public static Matrix operator -(Matrix thisMatrix)
        {
            for (int i = 0; i < thisMatrix.Rows; i++)
            {
                for (int j = 0; j < thisMatrix.Columns; j++)
                {
                    thisMatrix[i, j] = -thisMatrix[i, j];
                }
            }

            return new Matrix(thisMatrix._matrix);
        }

        public static Matrix operator +(Matrix thisMatrix, Matrix otherMatrix)
        {
            if (thisMatrix.Rows != otherMatrix.Rows || thisMatrix.Columns != otherMatrix.Columns)
                throw new IndexOutOfRangeException("Matrices of different sizes!");

            var result = new double[thisMatrix.Rows, thisMatrix.Columns];

            for (var i = 0; i < thisMatrix.Rows; i++)
            {
                for (var j = 0; j < thisMatrix.Columns; j++)
                {
                    thisMatrix[i, j] += otherMatrix[i, j];
                }
            }

            return new Matrix(thisMatrix._matrix);
        }

        public static Matrix operator -(Matrix thisMatrix, Matrix otherMatrix)
        {
            if (thisMatrix.Rows != otherMatrix.Rows || thisMatrix.Columns != otherMatrix.Columns)
                throw new IndexOutOfRangeException("Matrices of different sizes!");

            for (var i = 0; i < thisMatrix.Rows; i++)
            {
                for (var j = 0; j < thisMatrix.Columns; j++)
                {
                    thisMatrix[i, j] -= otherMatrix[i, j];
                }
            }

            return new Matrix(thisMatrix._matrix);
        }

        public static Matrix operator *(Matrix thisMatrix, Matrix otherMatrix)
        {
            if (thisMatrix.Columns != otherMatrix.Rows)
                throw new IndexOutOfRangeException("Columns number of the first matrix " +
                                                   "should be equal to the rows number of seconds matrix!");

            var result = new double[thisMatrix.Rows, thisMatrix.Columns];

            throw new NotImplementedException();
        }
    }
}