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

            EmployeePayroll employee = new EmployeePayroll();
            //employee.id = 5;
            employee.name = "Akshay";
            employee.basic_pay = 10000.00M;
            employee.StartDate = Convert.ToDateTime("2021-11-06");
            employee.Gender = "M";
            employee.phone = "9868511791";
            employee.address = "pune";
            employee.Department = "Mechanical";
            employee.deductions = 1500.00;
            employee.taxable_pay = 1500.00;
            employee.income_tax = 1000.00;
            employee.net_pay = 1400.00;
            
            if (repo.AddEmployee(employee))
                Console.WriteLine("Records added successfully");
            repo.AddEmployee(employee);
        }
    }
}