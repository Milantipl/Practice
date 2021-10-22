using System;

class GFG
{

    // function to print circle pattern
    static void printPattern(int radius)
    {

        // dist represents distance to the center
        double dist;

        // for horizontal movement
        for (int i = 0; i <= 2 * radius; i++)
        {

            // for vertical movement
            for (int j = 0; j <= 2 * radius; j++)
            {
                dist = Math.Sqrt((i - radius) *
                        (i - radius) + (j - radius)
                                    * (j - radius));

                // dist should be in the range
                // (radius - 0.5) and (radius + 0.5)
                // to print stars(*)
                if (dist > radius - 0.5 &&
                               dist < radius + 0.5)
                    Console.Write("-");
                else
                    Console.Write(" ");
            }

            Console.WriteLine("");
        }
    }

    // Driver code
    public static void Main()
    {
        int radius = 3;

        printPattern(radius);
    }
}