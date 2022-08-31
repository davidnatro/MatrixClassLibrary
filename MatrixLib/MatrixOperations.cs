namespace MatrixLib
{
    public partial class Matrix
    {
        public static Matrix Gauss(Matrix matrix)
        {
            double[,] matrixClone = new double[matrix.Rows, matrix.Rows + 1];

            for (var i = 0; i < matrix.Rows; i++)
            {
                for (var j = 0; j < matrix.Rows + 1; j++)
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
                        matrixClone[i, j] -= matrixClone[k, j] * K; //Зануление элементов матрицы ниже первого члена, преобразованного в единицу
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

            return new Matrix(matrixClone);
        }
    }
}