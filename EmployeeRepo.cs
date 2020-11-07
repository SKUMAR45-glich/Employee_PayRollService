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
                using (this.connection)
                {
                    string query = @"Select * from employee_payroll;";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeeModel.id = dr.GetInt32(0);
                            employeeModel.name = dr.GetString(1);
                            employeeModel.salary = dr.GetDecimal(2);
                            //employeeModel.start = dr.GetDateTime(3);
                            employeeModel.gender = Convert.ToChar(dr.GetString(4));
                            //employeeModel.phone = dr.GetString(5);
                            //employeeModel.address = dr.GetString(7);
                            //employeeModel.Department = dr.GetString(6);
                            //employeeModel.Deduction = dr.GetDouble(8);
                            //employeeModel.income_tax = dr.GetDouble(10);
                            //employeeModel.taxable_pay = dr.GetDouble(9);
                            //employeeModel.NetPay = dr.GetDouble(10);
                            System.Console.WriteLine(employeeModel.id + " " + employeeModel.name + " " + employeeModel.salary + " " + employeeModel.gender); // + " " + employeeModel.start); // + */" " + employeeModel.gender + " " + employeeModel.phone);// + " " + employeeModel.address + " " + employeeModel.Deduction + " " + employeeModel.taxable_pay + " " + employeeModel.income_tax);
                            System.Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        public bool AddEmployee(EmployeeModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("SpAddEmployeeDetails", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeName", model.name);
                    command.Parameters.AddWithValue("@PhoneNumber", model.phone);
                    command.Parameters.AddWithValue("@Address", model.address);
                    command.Parameters.AddWithValue("@Department", model.Department);
                    command.Parameters.AddWithValue("@Gender", model.gender);
                    command.Parameters.AddWithValue("@BasicPay", model.salary);

                    command.Parameters.AddWithValue("@Deductions", model.Deduction);
                    command.Parameters.AddWithValue("@TaxablePay", model.taxable_pay);
                    command.Parameters.AddWithValue("@Tax", model.income_tax);
                    command.Parameters.AddWithValue("@NetPay", model.net_pay);
                    command.Parameters.AddWithValue("@StartDate", DateTime.Now);
                    //command.Parameters.AddWithValue("@City", model.City);
                    //command.Parameters.AddWithValue("@Country", model.Country);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
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
    }
}
