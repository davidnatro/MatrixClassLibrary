using System;
using Xunit;

namespace MatrixLib.Tests.Operators
{
    public class BinaryOperatorsTests
    {
        private static readonly Random Random = new Random();

        [Fact]
        public void MatrixAdditionTest()
        {
            int rows = 3;
            int columns = 3;

            var arrayMatrix1 = GetRandomMatrix(rows, columns);
            var arrayMatrix2 = GetRandomMatrix(rows, columns);

            var matrix1 = new Matrix(arrayMatrix1);
            var matrix2 = new Matrix(arrayMatrix2);

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    arrayMatrix1[i, j] += arrayMatrix2[i, j];
                }
            }

            var resultMatrix = matrix1 + matrix2;

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    Assert.Equal(arrayMatrix1[i, j], resultMatrix[i, j]);
                }
            }
        }

        [Fact]
        public void MatrixSubstractTest()
        {
            int rows = 3;
            int columns = 3;
            var arrayMatrix1 = GetRandomMatrix(rows, columns);
            var arrayMatrix2 = GetRandomMatrix(rows, columns);

            var matrix1 = new Matrix(arrayMatrix1);
            var matrix2 = new Matrix(arrayMatrix2);

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    arrayMatrix1[i, j] -= arrayMatrix2[i, j];
                }
            }

            var resultMatrix = matrix1 - matrix2;

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    Assert.Equal(arrayMatrix1[i, j], resultMatrix[i, j]);
                }
            }
        }

        private static int[,] GetRandomMatrix(int rows, int columns)
        {
            var matrix = new int[rows, columns];

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    matrix[i, j] = Random.Next(5, 20);
                }
            }

            return matrix;
        }
    }
}