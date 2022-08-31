using System;

namespace MatrixLib
{
    public partial class Matrix
    {
        public static Matrix Clone(Matrix matrix)
        {
            return new Matrix(matrix);
        }

        public void Transpose()
        {
            var newMatrix = new Matrix(Columns, Rows);

            for (int i = 0; i < newMatrix.Rows; i++)
            {
                for (int j = 0; j < newMatrix.Columns; j++)
                {
                    newMatrix[i, j] = this[j, i];
                }
            }

            _matrix = newMatrix._matrix;
        }

        public Matrix Transposed()
        {
            var transposedMatrix = new Matrix(Columns, Rows);

            for (var i = 0; i < transposedMatrix.Rows; i++)
            {
                for (var j = 0; j < transposedMatrix.Columns; j++)
                {
                    transposedMatrix[i, j] = this[j, i];
                }
            }

            return transposedMatrix;
        }

        public static Matrix Gauss(Matrix matrix)
        {
            var matrixClone = new double[matrix.Rows, matrix.Columns];

            for (var i = 0; i < matrix.Rows; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                    matrixClone[i, j] = matrix[i, j];
            }

            //Прямой ход (Зануление нижнего левого угла)
            for (var k = 0; k < matrix.Rows; k++) //k-номер строки
            {
                for (var i = 0; i < matrix.Rows + 1; i++) //i-номер столбца
                    matrixClone[k, i] /=
                        matrix[k, k]; //Деление k-строки на первый член !=0 для преобразования его в единицу

                for (var i = k + 1; i < matrix.Rows; i++) //i-номер следующей строки после k
                {
                    double K = matrixClone[i, k] / matrixClone[k, k]; //Коэффициент

                    for (var j = 0; j < matrix.Rows + 1; j++) //j-номер столбца следующей строки после k
                        matrixClone[i, j] -=
                            matrixClone[k, j] *
                            K; //Зануление элементов матрицы ниже первого члена, преобразованного в единицу
                }

                for (var i = 0; i < matrix.Rows; i++)
                {
                    for (var j = 0; j < matrix.Rows + 1; j++)
                        matrix[i, j] = matrixClone[i, j];
                }
            }

            //Обратный ход (Зануление верхнего правого угла)
            for (var k = matrix.Rows - 1; k > -1; k--) //k-номер строки
            {
                for (var i = matrix.Rows; i > -1; i--) //i-номер столбца
                    matrixClone[k, i] /= matrix[k, k];
                for (var i = k - 1; i > -1; i--) //i-номер следующей строки после k
                {
                    double K = matrixClone[i, k] / matrixClone[k, k];
                    for (var j = matrix.Rows; j > -1; j--) //j-номер столбца следующей строки после k
                        matrixClone[i, j] -= matrixClone[k, j] * K;
                }
            }

            return new Matrix(matrix);
        }
    }
}