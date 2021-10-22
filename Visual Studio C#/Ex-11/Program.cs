using System;
using System.Collections.Generic;

namespace Ex_11
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> My_dict = new Dictionary<int, string>();

            My_dict.Add(01, "Milan");
            My_dict.Add(02, "Kishan");
            My_dict.Add(03, "Rahil");
            My_dict.Add(04, "Dhruv");
            My_dict.Add(05, "Hard");
            My_dict.Add(06, "Rajesh");
            My_dict.Add(07, "Deipesh");
            My_dict.Add(08, "Rikin");
            My_dict.Add(09, "Jayesh");
            My_dict.Add(10, "Paresh");
            My_dict.Add(11, "Sanjay");
            My_dict.Add(12, "Umesh");
            My_dict.Add(13, "Gaurang");
            My_dict.Add(14, "Hiren");
            My_dict.Add(15, "Satish");

            Console.WriteLine("ID  Name");
            foreach (KeyValuePair<int, string> ele in My_dict)
            {
                Console.WriteLine("{0} = {1}",
                            ele.Key, ele.Value);
            }
            
            Console.WriteLine("Total number Employee {0}", My_dict.Count);
            

            Console.WriteLine("\n");

                

             
            if (My_dict.ContainsKey(5) == true)
            {
                Console.WriteLine("Employee Id (5) Is Found");
            }
            else
            {
                Console.WriteLine("Employee Id (5) Add");
            }

            if (My_dict.ContainsKey(50) == true)
            {
                Console.WriteLine("Employee Id (50) Is Found");
            }
            else
            {
                My_dict.Add(50, "Rushita");
                Console.WriteLine("Employee Id (50) Add");
            }



            for (int i = 7; i < 10; i++)
            {
                My_dict.Remove(i);
            }

            foreach (KeyValuePair<int, string> ele in My_dict)
            {
                Console.WriteLine("{0}", ele.Key, ele.Value);
            }
            Console.WriteLine("Now Total number Of Employee {0}", My_dict.Count + "\n");


            string str = "", reverse = "";
            int Length = 0;

            foreach (KeyValuePair<int, string> ele in My_dict)
            {
                Console.WriteLine("{0}", ele.Key, ele.Value);
            }

            str = Console.ReadLine();
           /* Console.WriteLine("Now Total number Of Employee {0}");
            str = Console.ReadLine();*/

            Length = str.Length - 1;
            while (Length >= 0)
            {
                reverse = reverse + str[Length];
                Length--;
            }
            //Displaying the reverse word  
            Console.WriteLine("Reverse word is {0}",  reverse);
            Console.ReadLine();

        }

    }   
}
