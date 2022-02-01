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

            EmployeePayroll employeePayroll = new EmployeePayroll();
            //employee.id = 5;
            employeePayroll.name = "Akshay";
            employeePayroll.basic_pay = 10000.00M;
            employeePayroll.StartDate = Convert.ToDateTime("2021-11-06");
            employeePayroll.Gender = "M";
            employeePayroll.phone = "9868511791";
            employeePayroll.address = "pune";
            employeePayroll.Department = "Mechanical";
            employeePayroll.deductions = 1500.00;
            employeePayroll.taxable_pay = 1500.00;
            employeePayroll.income_tax = 1000.00;
            employeePayroll.net_pay = 1400.00;
            
            if (repo.AddEmployee(employeePayroll))
                Console.WriteLine("Records added successfully");
            repo.AddEmployee(employeePayroll);

        }
    }
}