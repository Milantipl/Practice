using System;

public class Program
{
    public static void Main()
    {
        IFile file1 = new FileInfo();
//        FileInfo file2 = new FileInfo();
        FileInfo file2 = new FileInfo();

        file1.ReadFile();
        file1.WriteFile("content");
        file2.search("content");


        
    }
}

interface IFile
{
    void ReadFile();
    void WriteFile(string text);

  //  void search(string text);
    
}

class FileInfo : IFile
{
    public void ReadFile()
    {
        Console.WriteLine("Reading File");
    }
    public void WriteFile(string text)
    {
        Console.WriteLine("Writing to file");
    }
    public void search(string text)
    {
        Console.WriteLine("vi");
    }
}

