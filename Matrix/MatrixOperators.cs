using System;

namespace Matrix
{
    public partial class Matrix
    {
        public static Matrix operator +(Matrix thisMatrix)
        {
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

        public static Matrix operator +(Matrix thisMatrix, int num)
        {
            for (int i = 0; i < thisMatrix.Rows; i++)
            {
                for (int j = 0; j < thisMatrix.Columns; j++)
                {
                    thisMatrix[i, j] += num;
                }
            }

            return new Matrix(thisMatrix._matrix);
        }

        public static Matrix operator +(Matrix thisMatrix, double num)
        {
            for (int i = 0; i < thisMatrix.Rows; i++)
            {
                for (int j = 0; j < thisMatrix.Columns; j++)
                {
                    thisMatrix[i, j] += num;
                }
            }

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

        public static Matrix operator -(Matrix thisMatrix, int num)
        {
            for (var i = 0; i < thisMatrix.Rows; i++)
            {
                for (var j = 0; j < thisMatrix.Columns; j++)
                {
                    thisMatrix[i, j] -= num;
                }
            }

            return new Matrix(thisMatrix._matrix);
        }

        public static Matrix operator -(Matrix thisMatrix, double num)
        {
            for (var i = 0; i < thisMatrix.Rows; i++)
            {
                for (var j = 0; j < thisMatrix.Columns; j++)
                {
                    thisMatrix[i, j] -= num;
                }
            }

            return new Matrix(thisMatrix._matrix);
        }

        public static Matrix operator *(Matrix thisMatrix, Matrix otherMatrix)
        {
            if (thisMatrix.Columns != otherMatrix.Rows)
                throw new IndexOutOfRangeException("Columns number of the first matrix " +
                                                   "should be equal to the rows number of seconds matrix!");

            var result = new double[thisMatrix.Rows, otherMatrix.Columns];

            for (var i = 0; i < thisMatrix.Rows; i++)
            {
                for (var j = 0; j < otherMatrix.Columns; j++)
                {
                    for (var k = 0; k < otherMatrix.Rows; k++)
                    {
                        result[i, j] += thisMatrix[i, k] * otherMatrix[k, j];
                    }
                }
            }

            return new Matrix(result);
        }

        public static Matrix operator *(Matrix thisMatrix, int num)
        {
            for (var i = 0; i < thisMatrix.Rows; i++)
            {
                for (var j = 0; j < thisMatrix.Columns; j++)
                {
                    thisMatrix[i, j] *= num;
                }
            }

            return new Matrix(thisMatrix._matrix);
        }

        public static Matrix operator *(Matrix thisMatrix, double num)
        {
            for (var i = 0; i < thisMatrix.Rows; i++)
            {
                for (var j = 0; j < thisMatrix.Columns; j++)
                {
                    thisMatrix[i, j] *= num;
                }
            }

            return new Matrix(thisMatrix._matrix);
        }

        public static bool operator ==(Matrix thisMatrix, Matrix otherMatrix)
        {
            if (thisMatrix == null || otherMatrix == null)
                throw new NullReferenceException();

            if (thisMatrix.Rows != otherMatrix.Rows || thisMatrix.Columns != otherMatrix.Columns)
                return false;

            for (var i = 0; i < thisMatrix.Rows; i++)
            {
                for (var j = 0; j < thisMatrix.Columns; j++)
                {
                    if (thisMatrix[i, j] - otherMatrix[i, j] != 0)
                        return false;
                }
            }

            return true;
        }

        public static bool operator !=(Matrix thisMatrix, Matrix otherMatrix)
        {
            return !(thisMatrix == otherMatrix);
        }
    }
}