
using System.Data.SqlClient;


namespace EmployeePayrollService
{
    public class EmployeeRepo
    {
        public static string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=payroll_service;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        

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
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", employeePayroll.id, employeePayroll.name, employeePayroll.address, employeePayroll.Department, employeePayroll.Gender, employeePayroll.basic_pay, employeePayroll.deductions, employeePayroll.taxable_pay, employeePayroll.income_tax, employeePayroll.net_pay );
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
        public bool AddEmployee(EmployeePayroll employeePayroll)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("dbo.spemployeedetails", connection);

                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@name", employeePayroll.name);
                    command.Parameters.AddWithValue("@basic_pay", employeePayroll.basic_pay);
                    command.Parameters.AddWithValue("@StartDate", DateTime.Now);
                    command.Parameters.AddWithValue("@Gender", employeePayroll.Gender);
                    command.Parameters.AddWithValue("@phone", employeePayroll.phone);
                    command.Parameters.AddWithValue("@address", employeePayroll.address);
                    command.Parameters.AddWithValue("@Department", employeePayroll.Department);
                    command.Parameters.AddWithValue("@deductions", employeePayroll.deductions);
                    command.Parameters.AddWithValue("@taxable_pay", employeePayroll.taxable_pay);
                    command.Parameters.AddWithValue("@income_tax", employeePayroll.income_tax);
                    command.Parameters.AddWithValue("@net_pay", employeePayroll.net_pay);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                        return true;
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
            return false;
        }

        public bool UpdateBasicPay(string EmployeeName, double BasicPay)
        {
            try
            {
                using (connection)
                {
                    connection.Open();
                    string query = @"update dbo.employee_payroll set BasicPay=@inputBasicPay where EmployeeName=@inputEmployeeName";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@inputBasicPay", BasicPay); 
                    command.Parameters.AddWithValue("@inputEmployeeName", EmployeeName);
                    var result = command.ExecuteNonQuery(); 
                    Console.WriteLine("Record Update Successfully");
                    connection.Close();
                    ConnectionString(); //display method
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
    }
}
