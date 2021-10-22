using System;

public class Program
{
	public static void Main()
	{
		Employee emp;

		emp.EmpId = 1;
		emp.Surname = "Naliyapara";
		emp.Firstname = "Milan";
		emp.Lastname = "M";
		emp.Mobile_Number = 9913741286;
		Console.Write(emp.EmpId+"\n"+emp.Surname+"\n"+emp.Firstname + "\n" + emp.Lastname + "\n" + emp.Mobile_Number);
		
	}
}
struct Employee
{
	public int EmpId;
	public string Surname;
	public string Firstname;
	public string Lastname;
	public double Mobile_Number;

}
