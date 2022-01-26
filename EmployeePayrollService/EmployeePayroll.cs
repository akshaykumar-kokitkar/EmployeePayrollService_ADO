
namespace EmployeePayrollService
{
    public class EmployeePayroll
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string Department { get; set; }
        public string Gender { get; set; }
        public decimal basic_pay { get; set; }
        public double deductions { get; set; }
        public double taxable_pay { get; set; }
        public double income_tax { get; set; }
        public double net_pay { get; set; }
        public DateTime StartDate { get; set; }

    }
}
