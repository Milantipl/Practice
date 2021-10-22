using System;
public class Exercise3
{
    public static void Main()
    {
        int[] a = new int[100];
        int i, n, sum = 0;


        Console.Write("\n\nEnter The Value\n");
        n = Convert.ToInt32(Console.ReadLine());

        Console.Write("Input {0} elements in the array :\n", n);
        for (i = 0; i < n; i++)
        {
            Console.Write("Value - {0} : ", i);
            a[i] = Convert.ToInt32(Console.ReadLine());
        }

        for (i = 0; i < n; i++)
        {
            sum += a[i];
        }
        Console.Write("Sum of Value : {0}\n\n", sum);
    }
}