using System;

class Program
{
    static void Main()
    {
        int[] n = new int[10];
        
        for (int i = 0; i < 10; i++)
        {
            n[i] = i + 1;
            
        }
        Console.WriteLine("Original Array...");

        foreach (int j in n)
        {
            int i = j - 1;
            Console.WriteLine("My Array {1}", i, j);
    
        }

        int[] arrTarget = new int[n.Length];
        int k = 0;

       for (int p = 0; p < n.Length; p++)
        {
            arrTarget[p] = k ;
           k += 0;
        }
       

        Array.Copy(n , arrTarget, n.Length);
        Console.WriteLine("\nCopy Array ...");

        foreach (int value in arrTarget)
        {
            Console.WriteLine(value + " ");
        }
    }
}