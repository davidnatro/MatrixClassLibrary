using System;

namespace MatrixLib
{
    public partial class Matrix
    {
        public static Matrix operator +(Matrix thisMatrix)
        {
            return new Matrix(thisMatrix);
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
                    result[i, j] = thisMatrix[i, j] + otherMatrix[i, j];
                }
            }

            return new Matrix(result);
        }

        public static Matrix operator +(Matrix thisMatrix, int num)
        {
            var result = new double[thisMatrix.Rows, thisMatrix.Columns];

            for (var i = 0; i < thisMatrix.Rows; i++)
            {
                for (var j = 0; j < thisMatrix.Columns; j++)
                {
                    result[i, j] = thisMatrix[i, j] + num;
                }
            }

            return new Matrix(result);
        }

        public static Matrix operator +(Matrix thisMatrix, double num)
        {
            var result = new double[thisMatrix.Rows, thisMatrix.Columns];

            for (var i = 0; i < thisMatrix.Rows; i++)
            {
                for (var j = 0; j < thisMatrix.Columns; j++)
                {
                    result[i, j] = thisMatrix[i, j] + num;
                }
            }

            return new Matrix(result);
        }

        public static Matrix operator -(Matrix thisMatrix)
        {
            var result = new double[thisMatrix.Rows, thisMatrix.Columns];

            for (var i = 0; i < thisMatrix.Rows; i++)
            {
                for (var j = 0; j < thisMatrix.Columns; j++)
                {
                    result[i, j] = -thisMatrix[i, j];
                }
            }

            return new Matrix(result);
        }

        public static Matrix operator -(Matrix thisMatrix, Matrix otherMatrix)
        {
            if (thisMatrix.Rows != otherMatrix.Rows || thisMatrix.Columns != otherMatrix.Columns)
                throw new IndexOutOfRangeException("Matrices of different sizes!");

            var result = new double[thisMatrix.Rows, thisMatrix.Columns];

            for (var i = 0; i < thisMatrix.Rows; i++)
            {
                for (var j = 0; j < thisMatrix.Columns; j++)
                {
                    result[i, j] = thisMatrix[i, j] - otherMatrix[i, j];
                }
            }

            return new Matrix(result);
        }

        public static Matrix operator -(Matrix thisMatrix, int num)
        {
            var result = new double[thisMatrix.Rows, thisMatrix.Columns];

            for (var i = 0; i < thisMatrix.Rows; i++)
            {
                for (var j = 0; j < thisMatrix.Columns; j++)
                {
                    result[i, j] = thisMatrix[i, j] - num;
                }
            }

            return new Matrix(result);
        }

        public static Matrix operator -(Matrix thisMatrix, double num)
        {
            var result = new double[thisMatrix.Rows, thisMatrix.Columns];

            for (var i = 0; i < thisMatrix.Rows; i++)
            {
                for (var j = 0; j < thisMatrix.Columns; j++)
                {
                    result[i, j] = thisMatrix[i, j] - num;
                }
            }

            return new Matrix(result);
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
            var result = new double[thisMatrix.Rows, thisMatrix.Columns];

            for (var i = 0; i < thisMatrix.Rows; i++)
            {
                for (var j = 0; j < thisMatrix.Columns; j++)
                {
                    result[i, j] = thisMatrix[i, j] * num;
                }
            }

            return new Matrix(result);
        }

        public static Matrix operator *(Matrix thisMatrix, double num)
        {
            var result = new double[thisMatrix.Rows, thisMatrix.Columns];

            for (var i = 0; i < thisMatrix.Rows; i++)
            {
                for (var j = 0; j < thisMatrix.Columns; j++)
                {
                    result[i, j] = thisMatrix[i, j] * num;
                }
            }

            return new Matrix(result);
        }

        public static bool operator ==(Matrix thisMatrix, Matrix otherMatrix)
        {
            if (ReferenceEquals(thisMatrix, otherMatrix))
                return true;
            if (ReferenceEquals(thisMatrix, null) || ReferenceEquals(null, otherMatrix))
                return false;

            return thisMatrix.Equals(otherMatrix);
        }

        public static bool operator !=(Matrix thisMatrix, Matrix otherMatrix)
        {
            return !(thisMatrix == otherMatrix);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Matrix);
        }

        private bool Equals(Matrix other)
        {
            if (other == null) return false;

            if (Rows != other.Rows || Columns != other.Columns) return false;

            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Columns; j++)
                {
                    if (this[i, j] - other[i, j] != 0)
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 31;
                hash = hash * 61 + _id.GetHashCode();
                hash = hash * 61 + Rows.GetHashCode();
                hash = hash * 61 + Columns.GetHashCode();

                return hash;
            }
        }
    }
}