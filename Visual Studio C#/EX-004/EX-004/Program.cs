using System;
public class Exercise1
{
    public static void Main()
    {
        Console.WriteLine("Enter The Length Of Array - ");
        int num = Convert.ToInt32(Console.ReadLine());
        int[] arr = new int[num];
        int i;
        Console.Write("Input Array");
        
        Console.Write("elements of the array :\n");
        for (i = 0; i < arr.Length; i++)
        {
            Console.Write("element - {0} : ", i);
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }

        Console.Write("\nElements in array are: ");
        for (i = 0; i < arr.Length; i++)
        {
            Console.Write("{0}  ", arr[i]);
        }
        Console.Write("\n");
        for (int k = 0; k < arr.Length; k++)
        {
            int count = 0;
            for (int j = 0; j < arr.Length; j++)
            {
                if (arr[k] == arr[j])
                    count = count + 1;
            }
            Console.WriteLine( + arr[k] + " occurs " + count + " times");
        }
        Console.ReadKey();
    }
}
