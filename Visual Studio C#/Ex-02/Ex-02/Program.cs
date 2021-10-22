using System;
namespace Demo {
   public class MyApplication {
      public static void Main(string[] args) {
         int[] list = {45, 88, 85, 99, 55, 37, 57, 84};   
         Console.WriteLine("Original  List");
         foreach (int i in list) {
            Console.Write(i + " ");
         }
         MyApplication m = new MyApplication();
         m.Func(list);
      }
      public void Func(int[] arr) {
         int temp = 0; 
         Console.WriteLine("\n \nSorted List");
         for(int i=0; i< arr.Length; i++) {
            for(int j=i+1; j<arr.Length; j++) {
               if(arr[i]<=arr[j]) {   
                  temp=arr[j];
                  arr[j]=arr[i];
                  arr[i]=temp;
               }                    
            }
            Console.Write(arr[i] + " ");
         }
      }
   }
}