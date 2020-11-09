using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayRollService
{
    class EmployeeRepo
    {
        public static string connectionString = @"Data Source=DESKTOP-SC0MR56\SQLEXPRESS;Initial Catalog=EmployeePayRoll_Service;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        public void GetAllEmployee()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                string query = @"Select * from employee_payroll;";
                SqlCommand cmd = new SqlCommand(query, this.connection);
                this.connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Console.WriteLine("\tID\tNAME\t\tSALARY\t\tSTART DATE");
                    Console.WriteLine("\t--\t----\t\t------\t\t----------");
                    while (dr.Read())
                    {
                        employeeModel.EmployeeID = dr.GetInt32(0);
                        employeeModel.EmployeeName = dr.GetString(1);
                        employeeModel.BasicPay = dr.GetSqlMoney(2);
                        employeeModel.StartDate = dr.GetDateTime(3);

                        Console.WriteLine("\t" + employeeModel.EmployeeID + "\t" + employeeModel.EmployeeName + "\t\t" + employeeModel.BasicPay + "\t" + employeeModel.StartDate);
                        Console.WriteLine("\t------------------------------------------------------------");
                    }
                }
                else
                {
                    System.Console.WriteLine("No data found");
                }

            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public bool AddEmployee(EmployeeModel model)
        {
            SqlCommand command = new SqlCommand("SpAddEmployeeDetails", this.connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@EmployeeName", model.EmployeeName);
            command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
            command.Parameters.AddWithValue("@Address", model.Address);
            command.Parameters.AddWithValue("@Department", model.Department);
            command.Parameters.AddWithValue("@Gender", model.Gender);
            command.Parameters.AddWithValue("@BasicPay", model.BasicPay);
            command.Parameters.AddWithValue("@Deductions", model.Deductions);
            command.Parameters.AddWithValue("@TaxablePay", model.TaxablePay);
            command.Parameters.AddWithValue("@Tax", model.Tax);
            command.Parameters.AddWithValue("@NetPay", model.NetPay);
            command.Parameters.AddWithValue("@StartDate", DateTime.Now);
            try
            {
                this.connection.Open();
                var result = command.ExecuteNonQuery();
                if (result != 0)
                {
                    return true;
                }
                return false;
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

        public void GetCountAvgMinMaxinEmployee(EmployeeModel employeeModel)
        {
            try
            {
                //EmployeeModel employeeModel = new EmployeeModel();
                var query = @"SELECT  COUNT(*) AS number_of_females,
		                            AVG(salary) AS avg_salary,
		                            MIN(salary) AS min_salary,
		                            MAX(salary) AS max_salary
                                    FROM employee_payroll
                                    WHERE gender = 'F' 
                                    GROUP BY gender";
                
                var sqlCommand = new SqlCommand(query, connection);
                
                connection.Open();
                var reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("Number of Females : {0}", reader.GetInt32(0));
                        Console.WriteLine("Average Salary : {0}", reader.GetInt32(1));
                        Console.WriteLine("Minimum Salary : {0}", reader.GetInt32(2));
                        Console.WriteLine("Maximum Salary : {0}", reader.GetInt32(3));

                    }
                }

                else
                    Console.WriteLine("Data Not Found");
                connection.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
