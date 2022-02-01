
using System.Data.SqlClient;


namespace EmployeePayrollService
{
    public class EmployeeRepo
    {
        public static string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=payroll_service;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        //EmployeePayroll employeePayroll = new EmployeePayroll();

        public void ConnectionString()
        {
            try
            {
                EmployeePayroll employeePayroll = new EmployeePayroll();
                using (this.connection)
                {
                    string query = @"SELECT id, name, address, department, gender, basic_pay, deductions, taxable_pay, income_tax, net_pay
                                    From employee_payroll";
                    //sqlcommand instance
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    //check if there are records
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeePayroll.id = dr.GetInt32(0);
                            employeePayroll.name = dr.GetString(1);
                            employeePayroll.address = dr.GetString(2);
                            employeePayroll.Department = dr.GetString(3);
                            employeePayroll.Gender = dr.GetString(4);
                            employeePayroll.basic_pay = dr.GetDecimal(5);
                            employeePayroll.deductions = dr.GetDouble(6);
                            employeePayroll.taxable_pay = dr.GetDouble(7);
                            employeePayroll.income_tax = dr.GetDouble(8);
                            employeePayroll.net_pay = dr.GetDouble(9);

                            //Display the record
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", employeePayroll.id, employeePayroll.name, employeePayroll.address, employeePayroll.Department, employeePayroll.Gender, employeePayroll.basic_pay, employeePayroll.deductions, employeePayroll.taxable_pay, employeePayroll.income_tax, employeePayroll.net_pay);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    //close data reader
                    dr.Close();
                    this.connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
       
    }
}