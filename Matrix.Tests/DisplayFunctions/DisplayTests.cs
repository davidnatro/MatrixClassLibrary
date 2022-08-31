using System;
using System.Text;
using Xunit;

namespace MatrixLib.Tests.DisplayFunctions
{
    public class DisplayTests
    {
        private static readonly Random Random = new Random();

        [Fact]
        public void ToStringTest()
        {
            var arrayMatrix = GetRandomMatrix();

            var matrix = new Matrix(arrayMatrix);

            Assert.Equal(PrintMatrix(arrayMatrix), matrix.ToString());
        }

        private static string PrintMatrix(int[,] matrix)
        {
            var result = new StringBuilder();

            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for (var i = 0; i < rows; i++, result.Append('\n'))
            {
                for (var j = 0; j < columns; j++)
                {
                    result.Append(matrix[i, j]);
                    result.Append('\t');
                }
            }

            return result.ToString();
        }

        private static int[,] GetRandomMatrix()
        {
            int rows = Random.Next(5, 20);
            int columns = Random.Next(5, 20);
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