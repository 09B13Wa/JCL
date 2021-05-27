using System;
using System.Net.Mime;
using GeneralTools;

namespace Math
{
    public enum InvertibleStatus
    {
        INVERTIBLE = 1,
        NON_INVERTIBLE = 2,
        UNKNOWN = 0
    }
    public class Matrix<T> : ICopiable<Matrix<T>>, IZeroable<Matrix<T>>, IIdentityable<Matrix<T>> where T: IZeroable<T>, IIdentityable<T>
    {
        private T[,] _dataMatrix;
        private int _numberOfRows;
        private int _numberOfColumns;
        private InvertibleStatus _invertibleStatus;

        public Matrix(int rows, int columns)
        {
            _numberOfRows = rows;
            _numberOfColumns = columns;
            _dataMatrix = new T[rows, columns];
            UpdateInvertibleStatus();
        }
        
        public Matrix(T[,] data)
        {
            int rows = data.GetLength(0);
            int columns = data.GetLength(1);
            _numberOfRows = rows;
            _numberOfColumns = columns;
            _dataMatrix = new T[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    _dataMatrix[i, j] = data[i, j];
                }
            }
            UpdateInvertibleStatus();
        }
        
        private Matrix(T[,] data, InvertibleStatus invertibleStatus)
        {
            int rows = data.GetLength(0);
            int columns = data.GetLength(1);
            _numberOfRows = rows;
            _numberOfColumns = columns;
            _dataMatrix = new T[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    _dataMatrix[i, j] = data[i, j];
                }
            }
            UpdateInvertibleStatus();
        }

        public static Matrix<T> DeepCopy(Matrix<T> original)
        {
            return original.SimpleDeepCopy();
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

        public int NumberOfRows => _numberOfRows;
        public int NumberOfColumns => _numberOfColumns;
        public int RowSize => _numberOfColumns;
        public int ColumnSize => _numberOfRows;
        public bool Invertible => IsInvertible();
        
        private InvertibleStatus InvertibleStatus
        {
            get => _invertibleStatus;
            set => _invertibleStatus = value;
        }
        

        public Matrix<T> ShallowCopy()
        {
            return this;
        }

        public Matrix<T> SimpleDeepCopy()
        {
            T[,]matrix = new T[_numberOfRows, _numberOfColumns];
            for (int i = 0; i < _numberOfRows; i++)
            {
                for (int j = 0; j < _numberOfColumns; j++)
                {
                    matrix[i, j] = _dataMatrix[i, j];
                }
            }

            if (InvertibleStatus == InvertibleStatus.UNKNOWN)
                UpdateInvertibleStatus();
            return new Matrix<T>(matrix, InvertibleStatus);
        }

        public bool IsInvertible()
        {
            throw new NotImplementedException();
        }

        private void UpdateInvertibleStatus()
        {
            if (IsInvertible())
                _invertibleStatus = InvertibleStatus.INVERTIBLE;
            else
                _invertibleStatus = InvertibleStatus.NON_INVERTIBLE;
        }

        public static Matrix<T> Inverse(Matrix<T> original)
        {
            
        }

        public Matrix<T> GetZero()
        {
            throw new NotImplementedException();
        }

        public bool IsZero()
        {
            throw new NotImplementedException();
        }

        public Matrix<T> GetIdentity()
        {
            throw new NotImplementedException();
        }

        public bool IsIdentity()
        {
            throw new NotImplementedException();
        }

        public Matrix<T> GetIdentityFactor()
        {
            throw new NotImplementedException();
        }
    }
}