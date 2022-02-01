using System;

namespace EmployeePayrollService
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Employee Payroll Service Using ADO.Net!");

            EmployeeRepo repo = new EmployeeRepo();
            repo.ConnectionString();
        }
    }
}