using System;
using Xunit;

namespace Matrix.Tests.Constructors
{
    public class ConstructorsFailsTests
    {
        [Theory]
        [InlineData(2, -3)]
        [InlineData(-2, 3)]
        [InlineData(-2, -3)]
        [InlineData(0, -3)]
        public void RowsColumnsConstructorTest(int rows, int columns)
        {
            Action matrixConstructor = () => new Matrix(rows, columns);

            Assert.Throws<ArgumentOutOfRangeException>(matrixConstructor);
        }
    }
}