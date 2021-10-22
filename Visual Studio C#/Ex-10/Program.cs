using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex_10
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> My_dict = new Dictionary<int, string>();

            My_dict.Add(01, "IIM Ahmedabad");
            My_dict.Add(02, "Gujarat Forensic Sciences University");
            My_dict.Add(03, "Gujarat University");
            My_dict.Add(04, "IIT Gandhinagar");
            My_dict.Add(05, "NID Ahmedabad");
            My_dict.Add(06, "GNLU Gandhinagar");
            My_dict.Add(07, "DDU Nadiad");
            My_dict.Add(08, "Pt Ravishankar Shukla University");
            My_dict.Add(09, "NIT Raipur");
            My_dict.Add(10, "Raksha Shakti University");
            
            Console.WriteLine("ID  College");
            foreach (KeyValuePair<int, string> ele in My_dict)
            {
                Console.WriteLine("{0} = {1}",
                            ele.Key, ele.Value);
            }

            Console.WriteLine("Total College {0}", My_dict.Count);


            Console.WriteLine("\n");

          /*  var myLinqQuery = from name in My_dict
                              where name.('a')
                              select name;
            foreach (var name in myLinqQuery)
                Console.Write(name + " ");
*/


            /*if (My_dict.ContainsKey(5) == true)
            {
                Console.WriteLine("Employee Id (5) Is Found");
            }
            else
            {
                Console.WriteLine("Employee Id (5) Add");
            }*/

            if (My_dict.ContainsKey(11) == true)
            {
                Console.WriteLine("Employee Id (50) Is Found");
            }
            else
            {
                My_dict.Add(11, "AIIMS Raipur");
                Console.WriteLine("New College Add");
            }


/*
            for (int i = 7; i < 10; i++)
            {
                My_dict.Remove(i);
            }*/

            foreach (KeyValuePair<int, string> ele in My_dict)
            {
                Console.WriteLine("{0} = {1}", ele.Key, ele.Value);
            }
            Console.WriteLine("Now Total College {0}", My_dict.Count);
            Console.WriteLine("\n");
            Console.WriteLine("Remove 5th college");
            for (int i = 0; i < 5; i++)
            {
                My_dict.Remove(i);
            }
            

            foreach (KeyValuePair<int, string> ele in My_dict)
            {
                Console.WriteLine("{0} = {1}", ele.Key, ele.Value);
            }
            Console.WriteLine("Now Total College {0}", My_dict.Count);
        }
    }
}
