using System;

namespace EX_005
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter The Length Of Array - ");
            int num = Convert.ToInt32(Console.ReadLine());
        
            int[] arr = new int[num];

            for (int i = 0; i < num; i++)
            {
                arr[i] = i + 1;

            }
            Console.WriteLine("Original Array...");

            foreach (int j in arr)
            {
                int i = j - 1;
                Console.WriteLine("My Array {1}", i, j);
            }

            Console.Write("\n");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {

                 Console.Write(arr.Length + j+i);
                }
                Console.WriteLine(); 
            }
        }
    }
}
