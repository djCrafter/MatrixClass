using System;
using System.Threading;
using System.Text;


namespace MatrixClass
{    
    class Matrix
    {
        private int[,] arr;
        private int col;
        private int row;
    
        public Matrix(int col, int row)
        {
            this.col = col;
            this.row = row;
            arr = new int[col,row];         
        }

        public Matrix(int col, int row, int maxVal) : this(col, row)
        {
            Init(maxVal);
        }

        public Matrix(int col, int row, int minVal, int maxVal) : this(col, row)
        {
            Init(minVal, maxVal);
        }
            
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < col; ++i)
            {
                for (int j = 0; j < row; ++j)
                {
                    sb.Append(arr[i, j]);
                    sb.Append(' ');
                }

                if(i != col - 1)
                sb.Append('\n');
            }
            return sb.ToString();
        }

        public void Init(int maxVal)
        {
            Random rand = new Random();
            for (int i = 0; i < col; i++)
                for (int j = 0; j < row; j++)
                    arr[i,j] = rand.Next(maxVal);

            Thread.Sleep(20);
        }

        public void Init(int minVal, int maxVal)
        {
            Random rand = new Random();
            for (int i = 0; i < col; i++)
            for (int j = 0; j < row; j++)
                arr[i, j] = rand.Next(minVal, maxVal);

            Thread.Sleep(20);
        }

        public static bool SizeEquals(Matrix a, Matrix b)
        {
            return a.col == b.col && a.row == b.row;
        }

        public int this[int col, int row]
        {
            get
            {
                return arr[col, row];
            }
            set
            {
                arr[col, row] = value;
            }
        }

        private static Matrix BinariOp(Matrix a, Matrix b, char op)
        {
            if (SizeEquals(a, b))
            {
                Matrix temp = new Matrix(a.col, a.row);

                for (int i = 0; i < a.col; i++)
                for (int j = 0; j < a.row; j++)
                {
                    switch (op)
                    {
                        case '+':
                            temp[i, j] = a[i, j] + b[i, j];
                            break;

                        case '-':
                            temp[i, j] = a[i, j] - b[i, j];
                            break;

                        case '*':
                            temp[i, j] = a[i, j] * b[i, j];
                            break;

                        case '/':
                            temp[i, j] = a[i, j] / b[i, j];
                            break;
                    }
                }
                return temp;
            }
            else throw new Exception();
        }

        public static int MatrixSum(Matrix a)
        {
            int sum = 0;

            for (int i = 0; i < a.col; i++)
            for (int j = 0; j < a.row; j++)
                sum += a[i, j];

            return sum;
        }


        public static Matrix UnariOperation(Matrix a, char op)
        {
            Matrix temp = new Matrix(a.col, a.row);

            for (int i = 0; i < a.col; i++)
            for (int j = 0; j < a.row; j++)
            {
                switch (op)
                {
                    case '+':
                        temp[i, j]++;
                        break;

                    case '-':
                        temp[i, j]--;
                        break;         
                }
            }
            return temp;
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            return BinariOp(a, b, '+');
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            return BinariOp(a, b, '-');
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            return BinariOp(a, b, '*');
        }

        public static Matrix operator /(Matrix a, Matrix b)
        {
            return BinariOp(a, b, '/');
        }

        public static Matrix operator ++(Matrix a)
        {
            return UnariOperation(a, '+');
        }

        public static Matrix operator --(Matrix a)
        {
            return UnariOperation(a, '-');
        }

        public static bool operator ==(Matrix a, Matrix b)
        {              
            for (int i = 0; i < a.col; i++)
            for (int j = 0; j < a.row; j++)
                if (a[i, j] != b[i, j])
                    return false;
            return true;
        }

        public static bool operator !=(Matrix a, Matrix b)
        {
            for (int i = 0; i < a.col; i++)
            for (int j = 0; j < a.row; j++)
                if (a[i, j] != b[i, j])
                    return true;
            return false;
        }

        public static bool operator >(Matrix a, Matrix b)
        {
            return MatrixSum(a) > MatrixSum(b);
        }

        public static bool operator <(Matrix a, Matrix b)
        {
            return MatrixSum(a) < MatrixSum(b);
        }
    }
}
