using System;

namespace Milan4
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            for ( i=0; i<50; i = i+1)
            {
                if (i == 20)
                {
                    continue;
                }
                Console.WriteLine(i);
            }
        }
    }
}
