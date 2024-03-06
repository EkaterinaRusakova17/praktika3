using System;

namespace MatrixCalculator
{
    interface IComparable
    {
        int CompareTo(object obj);
    }

    class SquareMatrix : IComparable
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
                for (int index = 0; index < size; ++index)
                {
                    for (int secondIndex = 0; secondIndex < size; ++secondIndex)
                    {
                        matrix[index, secondIndex] = rnd.Next(10);
                    }
                }
            }
        }

        public int Size
        {
            get { return size; }
        }

        public int this[int index, int secondIndex]
        {
            get
            {
                if (index >= 0 && index < size && secondIndex >= 0 && secondIndex < size)
                {
                    return matrix[index, secondIndex];
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                if (index >= 0 && index < size && secondIndex >= 0 && secondIndex < size)
                {
                    matrix[index, secondIndex] = value;
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

            for (int index = 0; index < matrix1.Size; ++index)
            {
                for (int secondIndex = 0; secondIndex < matrix1.Size; ++secondIndex)
                {
                    result[index, secondIndex] = matrix1[index, secondIndex] + matrix2[index, secondIndex];
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

            for (int index = 0; index < matrix1.Size; ++index)
            {
                for (int secondIndex = 0; secondIndex < matrix1.Size; ++secondIndex)
                {
                    for (int thirdIndex = 0; thirdIndex < matrix1.Size; ++thirdIndex)
                    {
                        result[index, secondIndex] += matrix1[index, thirdIndex] * matrix2[thirdIndex, secondIndex];
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

            for (int index = 0; index < matrix1.Size; ++index)
            {
                for (int secondIndex = 0; secondIndex < matrix1.Size; ++secondIndex)
                {
                    sum1 += matrix1[index, secondIndex];
                    sum2 += matrix2[index, secondIndex];
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

            for (int index = 0; index < matrix1.Size; ++index)
            {
                for (int secondIndex = 0; secondIndex < matrix1.Size; ++secondIndex)
                {
                    sum1 += matrix1[index, secondIndex];
                    sum2 += matrix2[index, secondIndex];
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

            for (int index = 0; index < matrix1.Size; ++index)
            {
                for (int secondIndex = 0; secondIndex < matrix1.Size; ++secondIndex)
                {
                    sum1 += matrix1[index, secondIndex];
                    sum2 += matrix2[index, secondIndex];
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

            for (int index = 0; index < matrix1.Size; ++index)
            {
                for (int secondIndex = 0; secondIndex < matrix1.Size; ++secondIndex)
                {
                    sum1 += matrix1[index, secondIndex];
                    sum2 += matrix2[index, secondIndex];
                }
            }

            return sum1 <= sum2;
        }

        public static bool operator ==(SquareMatrix matrix1, SquareMatrix matrix2)
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

            for (int index = 0; index < matrix1.Size; ++index)
            {
                for (int secondIndex = 0; secondIndex < matrix1.Size; ++secondIndex)
                {
                    if (matrix1[index, secondIndex] != matrix2[index, secondIndex])
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
            for (int index = 0; index < matrix.Size; ++index)
            {
                for (int secondIndex = 0; secondIndex < matrix.Size; ++secondIndex)
                {
                    result[index, secondIndex] = matrix[index, secondIndex];
                }
            }
            return result;
        }

        public override string ToString()
        {
            string result = "";
            for (int index = 0; index < size; ++index)
            {
                for (int secondIndex = 0; secondIndex < size; ++secondIndex)
                {
                    result += matrix[index, secondIndex].ToString() + " ";
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
            for (int index = 0; index < size; ++index)
            {
                for (int secondIndex = 0; secondIndex < size; ++secondIndex)
                {
                    hash = hash * 23 + matrix[index, secondIndex].GetHashCode();
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
                for (int index = 0; index < size; ++index)
                {
                    int[,] subMatrix = new int[size - 1, size - 1];
                    for (int secondIndex = 1; secondIndex < size; ++secondIndex)
                    {
                        int thirdIndex = 0;
                        for (int fourthIndex = 0; fourthIndex < size; ++fourthIndex)
                        {
                            if (fourthIndex == index)
                            {
                                continue;
                            }
                            subMatrix[secondIndex - 1, thirdIndex] = matrix[secondIndex, fourthIndex];
                            ++thirdIndex;
                        }
                    }
                    determinant += Math.Pow(-1, index) * matrix[0, index] * new SquareMatrix(subMatrix).Determinant();
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

            for (int index = 0; index < size; ++index)
            {
                for (int secondIndex = 0; secondIndex < size; ++secondIndex)
                {
                    int[,] subMatrix = new int[size - 1, size - 1];
                    int fifeth = 0;
                    for (int thirdIndex = 0; thirdIndex < size; ++thirdIndex)
                    {
                        int sixth = 0;
                        if (thirdIndex == index)
                        {
                            continue;
                        }
                        for (int fourthIndex = 0; fourthIndex < size; ++fourthIndex)
                        {
                            if (fourthIndex == secondIndex)
                            {
                                continue;
                            }
                            subMatrix[fifeth, sixth] = matrix[thirdIndex, fourthIndex];
                            ++sixth;
                        }
                        ++fifeth;
                    }
                    inverseMatrix[secondIndex, index] = Math.Pow(-1, index + secondIndex) * new SquareMatrix(subMatrix).Determinant();
                }
            }

            SquareMatrix inverse = new SquareMatrix(size);
            for (int index = 0; index < size; ++index)
            {
                for (int secondIndex = 0; secondIndex < size; ++secondIndex)
                {
                    inverse[index, secondIndex] = (int)(inverseMatrix[index, secondIndex] / determinant);
                }
            }

            return inverse;
        }

        public SquareMatrix DeepClone()
        {
            SquareMatrix clonedMatrix = new SquareMatrix(size);

            for (int index = 0; index < size; index++)
            {
                for (int secondIndex = 0; secondIndex < size; secondIndex++)
                {
                    clonedMatrix[index, secondIndex] = this[index, secondIndex];
                }
            }

            return clonedMatrix;
        }

        class MatrixCalculator
        {
            static void Main(string[] args)
            {
                //Если не указать параметр, то матрица будет заполнена нулями
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
                for (int index = 0; index < matrixArray.GetLength(0); ++index)
                {
                    for (int secondIndex = 0; secondIndex < matrixArray.GetLength(1); ++secondIndex)
                    {
                        Console.Write(matrixArray[index, secondIndex] + " ");
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
}
