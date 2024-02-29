using System;

namespace MatrixCalculator
{
    interface Comparable
    { 
        int  CompareTo(Comparable other); 
    }

    class SquareMatrix
    {
        private int[,] matrix;
        private int size;

        public SquareMatrix(int size)
        {
            this.size = size;
            matrix = new int[size, size];
        }

        public SquareMatrix(int[,] matrix)
        {
            size = matrix.GetLength(0);
            this.matrix = new int[size, size];
            Array.Copy(matrix, this.matrix, size * size);
        }

        public SquareMatrix(int size, bool random)
        {
            this.size = size;
            matrix = new int[size, size];
            if (random)
            {
                Random rnd = new Random();
                for (int RowIndex = 0; RowIndex < size; ++RowIndex)
                {
                    for (int ColumnIndex = 0; ColumnIndex < size; ++ColumnIndex)
                    {
                        matrix[RowIndex, ColumnIndex] = rnd.Next(10);
                    }
                }
            }
        }

        public int Size
        {
            get { return size; }
        }

        public int this[int RowIndex, int ColumnIndex]
        {
            get
            {
                if (RowIndex >= 0 && RowIndex < size && ColumnIndex >= 0 && ColumnIndex < size)
                {
                    return matrix[RowIndex, ColumnIndex];
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                if (RowIndex >= 0 && RowIndex < size && ColumnIndex >= 0 && ColumnIndex < size)
                {
                    matrix[RowIndex, ColumnIndex] = value;
                }
            }
        }

        public static SquareMatrix operator +(SquareMatrix matrix1, SquareMatrix matrix2)
        {
            if (matrix1.Size != matrix2.Size)
            {
                throw new ArgumentException("Матрицы должны иметь одинаковый размер.");
            }

            SquareMatrix result = new SquareMatrix(matrix1.Size);

            for (int RowIndex = 0; RowIndex < matrix1.Size; ++RowIndex)
            {
                for (int ColumnIndex = 0; ColumnIndex < matrix1.Size; ++ColumnIndex)
                {
                    result[RowIndex, ColumnIndex] = matrix1[RowIndex, ColumnIndex] + matrix2[RowIndex, ColumnIndex];
                }
            }

            return result;
        }

        public static SquareMatrix operator *(SquareMatrix matrix1, SquareMatrix matrix2)
        {
            if (matrix1.Size != matrix2.Size)
            {
                throw new ArgumentException("Матрицы должны иметь одинаковый размер.");
            }

            SquareMatrix result = new SquareMatrix(matrix1.Size);

            for (int RowIndex = 0; RowIndex < matrix1.Size; ++RowIndex)
            {
                for (int ColumnIndex = 0; ColumnIndex < matrix1.Size; ++ColumnIndex)
                {
                    for (int thirdIndex = 0; thirdIndex < matrix1.Size; ++thirdIndex)
                    {
                        result[RowIndex, ColumnIndex] += matrix1[RowIndex, thirdIndex] * matrix2[thirdIndex, ColumnIndex];
                    }
                }
            }

            return result;
        }

        public static bool operator >(SquareMatrix matrix1, SquareMatrix matrix2)
        {
            if (matrix1.Size != matrix2.Size)
            {
                throw new ArgumentException("Матрицы должны иметь одинаковый размер.");
            }

            int sum1 = 0;
            int sum2 = 0;

            for (int RowIndex = 0; RowIndex < matrix1.Size; ++RowIndex)
            {
                for (int ColumnIndex = 0; ColumnIndex < matrix1.Size; ++ColumnIndex)
                {
                    sum1 += matrix1[RowIndex, ColumnIndex];
                    sum2 += matrix2[RowIndex, ColumnIndex];
                }
            }

            return sum1 > sum2;
        }

        public static bool operator <(SquareMatrix matrix1, SquareMatrix matrix2)
        {
            if (matrix1.Size != matrix2.Size)
            {
                throw new ArgumentException("Матрицы должны иметь одинаковый размер.");
            }

            int sum1 = 0;
            int sum2 = 0;

            for (int RowIndex = 0; RowIndex < matrix1.Size; ++RowIndex)
            {
                for (int ColumnIndex = 0; ColumnIndex < matrix1.Size; ++ColumnIndex)
                {
                    sum1 += matrix1[RowIndex, ColumnIndex];
                    sum2 += matrix2[RowIndex, ColumnIndex];
                }
            }

            return sum1 < sum2;
        }

        public static bool operator >=(SquareMatrix matrix1, SquareMatrix matrix2)
        {
            if (matrix1.Size != matrix2.Size)
            {
                throw new ArgumentException("Матрицы должны иметь одинаковый размер.");
            }

            int sum1 = 0;
            int sum2 = 0;

            for (int RowIndex = 0; RowIndex < matrix1.Size; ++RowIndex)
            {
                for (int ColumnIndex = 0; ColumnIndex < matrix1.Size; ++ColumnIndex)
                {
                    sum1 += matrix1[RowIndex, ColumnIndex];
                    sum2 += matrix2[RowIndex, ColumnIndex];
                }
            }

            return sum1 >= sum2;
        }

        public static bool operator <=(SquareMatrix matrix1, SquareMatrix matrix2)
        {
            if (matrix1.Size != matrix2.Size)
            {
                throw new ArgumentException("Матрицы должны иметь одинаковый размер.");
            }

            int sum1 = 0;
            int sum2 = 0;

            for (int RowIndex = 0; RowIndex < matrix1.Size; ++RowIndex)
            {
                for (int ColumnIndex = 0; ColumnIndex < matrix1.Size; ++ColumnIndex)
                {
                    sum1 += matrix1[RowIndex, ColumnIndex];
                    sum2 += matrix2[RowIndex, ColumnIndex];
                }
            }

            return sum1 <= sum2;
        }

        public static bool operator == (SquareMatrix matrix1, SquareMatrix matrix2)
        {
            if (matrix1 is null || matrix2 is null)
            {
                return matrix1 is null && matrix2 is null;
            }

            if (matrix1.Size != matrix2.Size)
            {
                throw new ArgumentException("Матрицы должны иметь одинаковый размер.");
            }

            bool equals = true;

            for (int RowIndex = 0; RowIndex < matrix1.Size; ++RowIndex)
            {
                for (int ColumnIndex = 0; ColumnIndex < matrix1.Size; ++ColumnIndex)
                {
                    if (matrix1[RowIndex, ColumnIndex] != matrix2[RowIndex, ColumnIndex])
                    {
                        equals = false;
                        break;
                    }
                }
            }

            return equals;
        }

        public static bool operator !=(SquareMatrix matrix1, SquareMatrix matrix2)
        {
            return !(matrix1 == matrix2);
        }

        public static implicit operator SquareMatrix(int[,] matrix)
        {
            return new SquareMatrix(matrix);
        }

        public static explicit operator int[,](SquareMatrix matrix)
        {
            int[,] result = new int[matrix.Size, matrix.Size];
            for (int RowIndex = 0; RowIndex < matrix.Size; ++RowIndex)
            {
                for (int ColumnIndex = 0; ColumnIndex < matrix.Size; ++ColumnIndex)
                {
                    result[RowIndex, ColumnIndex] = matrix[RowIndex, ColumnIndex];
                }
            }
            return result;
        }

        public override string ToString()
        {
            string result = "";
            for (int RowIndex = 0; RowIndex < size; ++RowIndex)
            {
                for (int ColumnIndex = 0; ColumnIndex < size; ++ColumnIndex)
                {
                    result += matrix[RowIndex, ColumnIndex].ToString() + " ";
                }
                result += "\n";
            }
            return result;
        }

        public int CompareTo(SquareMatrix other)
        {
            if (this == other)
            {
                return 0;
            }
            else if (this > other)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is SquareMatrix))
            {
                return false;
            }

            return this == (SquareMatrix)obj;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            for (int RowIndex = 0; RowIndex < size; ++RowIndex)
            {
                for (int ColumnIndex = 0; ColumnIndex < size; ++ColumnIndex)
                {
                    hash = hash * 23 + matrix[RowIndex, ColumnIndex].GetHashCode();
                }
            }
            return hash;
        }

        public double Determinant()
        {
            double determinant = 0;
            if (size == 1)
            {
                determinant = matrix[0, 0];
            }
            else if (size == 2)
            {
                determinant = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            else
            {
                for (int RowIndex = 0; RowIndex < size; ++RowIndex)
                {
                    int[,] subMatrix = new int[size - 1, size - 1];
                    for (int ColumnIndex = 1; ColumnIndex < size; ++ColumnIndex)
                    {
                        int thirdIndex = 0;
                        for (int fourthIndex = 0; fourthIndex < size; ++fourthIndex)
                        {
                            if (fourthIndex == RowIndex)
                            {
                                continue;
                            }
                            subMatrix[ColumnIndex - 1, thirdIndex] = matrix[ColumnIndex, fourthIndex];
                            ++thirdIndex;
                        }
                    }
                    determinant += Math.Pow(-1, RowIndex) * matrix[0, RowIndex] * new SquareMatrix(subMatrix).Determinant();
                }
            }
            return determinant;
        }

        public SquareMatrix Inverse()
        {
            double determinant = Determinant();
            if (determinant == 0)
            {
                throw new InvalidOperationException("Матрица не обратима.");
            }

            double[,] inverseMatrix = new double[size, size];

            for (int RowIndex = 0; RowIndex < size; ++RowIndex)
            {
                for (int ColumnIndex = 0; ColumnIndex < size; ++ColumnIndex)
                {
                    int[,] subMatrix = new int[size - 1, size - 1];
                    int fifeth = 0;
                    for (int thirdIndex = 0; thirdIndex < size; ++thirdIndex)
                    {
                        int sixth = 0;
                        if (thirdIndex == RowIndex)
                        {
                            continue;
                        }
                        for (int fourthIndex = 0; fourthIndex < size; ++fourthIndex)
                        {
                            if (fourthIndex == ColumnIndex)
                            {
                                continue;
                            }
                            subMatrix[fifeth, sixth] = matrix[thirdIndex, fourthIndex];
                            ++sixth;
                        }
                        ++fifeth;
                    }
                    inverseMatrix[ColumnIndex, RowIndex] = Math.Pow(-1, RowIndex + ColumnIndex) * new SquareMatrix(subMatrix).Determinant();
                }
            }

            SquareMatrix inverse = new SquareMatrix(size);
            for (int RowIndex = 0; RowIndex < size; ++RowIndex)
            {
                for (int ColumnIndex = 0; ColumnIndex < size; ++ColumnIndex)
                {
                    inverse[RowIndex, ColumnIndex] = (int)(inverseMatrix[RowIndex, ColumnIndex] / determinant);
                }
            }

            return inverse;
        }

        public SquareMatrix DeepClone()
        {
            return (SquareMatrix)this.MemberwiseClone();
        }
    }

    class MatrixCalculator
    {
        static void Main(string[] args)
        {
            SquareMatrix matrix1 = new SquareMatrix(3, random: true);
            SquareMatrix matrix2 = (SquareMatrix)matrix1.DeepClone();

            Console.WriteLine("Матрица 1:");
            Console.WriteLine(matrix1.ToString());

            Console.WriteLine("Матрица 2:");
            Console.WriteLine(matrix2.ToString());

            SquareMatrix sum = matrix1 + matrix2;
            Console.WriteLine("Сумма:");
            Console.WriteLine(sum.ToString());

            SquareMatrix product = matrix1 * matrix2;
            Console.WriteLine("Произведение:");
            Console.WriteLine(product.ToString());

            bool greaterThan = matrix1 > matrix2;
            Console.WriteLine("Матрица 1 > Матрица 2: " + greaterThan);

            bool lessThan = matrix1 < matrix2;
            Console.WriteLine("Матрица 1 < Матрица 2: " + lessThan);

            bool greaterOrEqual = matrix1 >= matrix2;
            Console.WriteLine("Матрица 1 >= Матрица 2: " + greaterOrEqual);

            bool lessOrEqual = matrix1 <= matrix2;
            Console.WriteLine("Матрица 1 <= Матрица 2: " + lessOrEqual);

            bool equal = matrix1 == matrix2;
            Console.WriteLine("Матрица 1 == Матрица 2: " + equal);

            bool notEqual = matrix1 != matrix2;
            Console.WriteLine("Матрица 1 != Матрица 2: " + notEqual);

            int[,] matrixArray = (int[,])matrix1;
            Console.WriteLine("Матрица 1 в виде массива:");
            for (int RowIndex = 0; RowIndex < matrixArray.GetLength(0); ++RowIndex)
            {
                for (int ColumnIndex = 0; ColumnIndex < matrixArray.GetLength(1); ++ColumnIndex)
                {
                    Console.Write(matrixArray[RowIndex, ColumnIndex] + " ");
                }
                Console.WriteLine();
            }

            SquareMatrix matrix3 = (SquareMatrix)matrixArray;
            Console.WriteLine("Матрица 3:");
            Console.WriteLine(matrix3.ToString());

            Console.WriteLine("Matrix 1 CompareTo Matrix 2: " + matrix1.CompareTo(matrix2));

            bool equals = matrix1.Equals(matrix2);
            Console.WriteLine("Matrix 1 Equals Matrix 2: " + equals);

            int hashCode = matrix1.GetHashCode();
            Console.WriteLine("Matrix 1 HashCode: " + hashCode);

            double determinant = matrix1.Determinant();
            Console.WriteLine("Matrix 1 Determinant: " + determinant);

            SquareMatrix inverse = matrix1.Inverse();
            Console.WriteLine("Matrix 1 Inverse:");
            Console.WriteLine(inverse.ToString());

            SquareMatrix deepClone = matrix1.DeepClone();
            Console.WriteLine("Matrix 1 DeepClone:");
            Console.WriteLine(deepClone.ToString());

            Console.ReadKey();
        }
    }
}
