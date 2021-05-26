using System.Net.Mime;

namespace Math
{
    public class Matrix<T> : I
    {
        private T[,] _dataMatrix;
        
        public Matrix(int rows, int columns)
        {
            _dataMatrix = new T[rows, columns];
        }
        
        public Matrix(T[,] data)
        {
            int rows = data.GetLength(0);
            int columns = data.GetLength(1);
            _dataMatrix = new T[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    _dataMatrix[i, j] = data[i, j];
                }
            }
        }

        public static Matrix<T> DeepCopy(Matrix<T> original)
        {
            T[,] originalMatrix = original.GetTwoDimensionalArray();
            int rows = originalMatrix.GetLength(0);
            int columns = originalMatrix.GetLength(1);
            T[,]matrix = new T[rows, columns];
            int numberOfElements = rows * columns;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = originalMatrix[i, j];
                }
            }

            return new Matrix<T>(matrix);
        }

        public T[,] GetTwoDimensionalArray()
        {
            return _dataMatrix;
        }

        public static U[,] DeepCopyOfArray<U>(U[,] original)
        {
            int rows = original.GetLength(0);
            int columns = original.GetLength(1);
            U[,]matrix = new U[rows, columns];
            int numberOfElements = rows * columns;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = original[i, j];
                }
            }

            return matrix;
        }
    }
}