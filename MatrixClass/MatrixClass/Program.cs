using System;

namespace MatrixClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix a = new Matrix(10, 10, 10);
            Matrix b = new Matrix(10, 10, 10);

           Console.WriteLine(a);
         
           Console.WriteLine();

           Console.WriteLine(b);
          
           Console.WriteLine();
           Console.WriteLine(a==b);
           Console.WriteLine(a!=b);
           Console.WriteLine(a>b);
           Console.WriteLine(a<b);

           Console.WriteLine();

           Matrix c = a + b;

           Console.WriteLine(c);
       
           Console.ReadLine();
        }
    }
}
