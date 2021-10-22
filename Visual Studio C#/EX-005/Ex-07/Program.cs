using System;

class Student
{
    public int rollNumber;
    public string result;


    public String toString()
    {
        return rollNumber + " " + result;
    }

}
class Result
{
    static void Main(string[] args)
    {
        Student s =  new Student();
        s.rollNumber = 1;
        s.result = "First Class";

        Console.WriteLine(s.rollNumber);
        Console.WriteLine(s.result);
    }
}