using System;
using Xunit;

namespace MatrixLib.Tests.Constructors
{
    public class ConstructorsTests
    {
        private static readonly Random Random = new Random();

        [Fact]
        public void DefaultConstructorTest()
        {
            var matrix = new Matrix();

            Assert.Equal(0, matrix.Rows);
            Assert.Equal(0, matrix.Columns);
        }


        [Theory]
        [InlineData(3, 0)]
        [InlineData(5, 9)]
        [InlineData(0, 4)]
        [InlineData(34, 12)]
        public void RowsColumnsConstructorTests(int rows, int columns)
        {
            var matrix = new Matrix(rows, columns);

            Assert.Equal(rows, matrix.Rows);
            Assert.Equal(columns, matrix.Columns);
        }

        [Fact]
        public void ArrayConstructorTest()
        {
            var parameterMatrix = GetRandomMatrixAsArray();

            var matrix = new Matrix(parameterMatrix);

            Assert.Equal(parameterMatrix.GetLength(0), matrix.Rows);
            Assert.Equal(parameterMatrix.GetLength(1), matrix.Columns);
            
            for (var i = 0; i < matrix.Rows; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                {
                    Assert.Equal(parameterMatrix[i, j], matrix[i, j]);
                }
            }
        }

        [Fact]
        public void ArrayIntMatrixConstructorTest()
        {
            var parameterMatrix = GetRandomMatrixAsArray();

            var matrix = new Matrix(parameterMatrix);

            Assert.Equal(parameterMatrix.GetLength(0), matrix.Rows);
            Assert.Equal(parameterMatrix.GetLength(1), matrix.Columns);

            for (var i = 0; i < matrix.Rows; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                {
                    Assert.Equal(parameterMatrix[i, j], matrix[i, j]);
                }
            }
        }

        [Fact]
        public void ArrayDoubleMatrixConstructorTest()
        {
            var parameterMatrix = GetDoubleMatrixAsArray();

            var matrix = new Matrix(parameterMatrix);

            Assert.Equal(parameterMatrix.GetLength(0), matrix.Rows);
            Assert.Equal(parameterMatrix.GetLength(1), matrix.Columns);

            for (var i = 0; i < matrix.Rows; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                {
                    Assert.Equal(parameterMatrix[i, j], matrix[i, j]);
                }
            }
        }

        private static double[,] GetDoubleMatrixAsArray()
        {
            return new double[,]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };
        }

        private static int[,] GetRandomMatrixAsArray()
        {
            int rows = Random.Next(5, 20);
            int columns = Random.Next(5, 20);

            var matrix = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = Random.Next(5, 20);
                }
            }

            return matrix;
        }
    }
}