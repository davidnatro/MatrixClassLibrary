using System;
using System.Text;

namespace Matrix
{
    public class Matrix : IComparable<Matrix>
    {
        #region Fields

        private double[,] _matrix;

        #endregion

        #region Properties

        public int Rows => _matrix.GetLength(0);
        public int Columns => _matrix.GetLength(1);

        #endregion

        #region Constructors

        public Matrix() : this(0, 0)
        {
        }

        public Matrix(int rows, int columns)
        {
            if (rows < 0 || columns < 0)
                throw new ArgumentOutOfRangeException(nameof(_matrix.Length),
                    "Number of Rows or Columns cannot be < 0!");

            _matrix = new double[rows, columns];
        }

        public Matrix(double[,] arrayMatrix)
        {
            _matrix = new double[arrayMatrix.GetLength(0), arrayMatrix.GetLength(1)];

            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Columns; j++)
                {
                    this[i, j] = arrayMatrix[i, j];
                }
            }
        }

        public Matrix(int[,] arrayMatrix)
        {
            _matrix = new double[arrayMatrix.GetLength(0), arrayMatrix.GetLength(1)];

            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Columns; j++)
                {
                    this[i, j] = arrayMatrix[i, j];
                }
            }
        }

        public Matrix(Matrix otherMatrix) : this(otherMatrix._matrix)
        {
        }

        #endregion

        public double this[int i, int j]
        {
            get
            {
                if (i >= Rows || j >= Columns || i < 0 || j < 0)
                    throw new IndexOutOfRangeException();

                return _matrix[i, j];
            }
            set
            {
                if (i >= Rows || j >= Columns || i < 0 || j < 0)
                    throw new IndexOutOfRangeException();

                _matrix[i, j] = value;
            }
        }

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

        public override string ToString()
        {
            var result = new StringBuilder();

            for (var i = 0; i < Rows; i++, result.Append('\n'))
            {
                for (var j = 0; j < Columns; j++)
                {
                    result.Append(this[i, j]);
                    result.Append('\t');
                }
            }

            return result.ToString();
        }

        public int CompareTo(Matrix other)
        {
            if (Rows * Columns > other.Rows * other.Columns)
                return 1;
            if (Rows * Columns < other.Rows * other.Columns)
                return -1;
            return 0;
        }
    }
}