using System;

namespace MyApplication
{
    class Program
    {
        enum Months
        {
            January,    // 0
            February,   // 1
            March ,    // 6
            April = 25,      // 7
            May,        // 8
            June ,       // 9
            July ,       // 10
        }
        static void Main(string[] args)
        {
            int myNum = (int)Months.June;
            Console.WriteLine(myNum);
        }
    }
}