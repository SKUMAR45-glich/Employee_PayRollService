﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace EmployeePayRollService
{
    public class Salary
    {
        private static SqlConnection ConnectionSetup()
        {
            return new SqlConnection(@"Data Source=DESKTOP-SC0MR56\SQLEXPRESS;Initial Catalog=EmployeePayRoll_Service;Integrated Security=True");
        }

        public bool UpdateEmployeeSalary(SalaryUpdateModel salaryUpdateModel)
        {
            SqlConnection SalaryConnection = ConnectionSetup();
            int salary = 0;
            bool update = false;
            try
            {
                using (SalaryConnection)
                {
                    SalaryDetailModel displayModel = new SalaryDetailModel();
                    SqlCommand command = new SqlCommand("spUpdateEmployeeSalary_", SalaryConnection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    var cmd = new SqlCommand("Select Id from Employee where EmployeeName='Terissa'", SalaryConnection);
                    SalaryConnection.Open();

                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                        salaryUpdateModel.SalaryId = Convert.ToInt32(reader.GetInt32(0));
                    reader.Close();
                    command.Parameters.AddWithValue("@id", salaryUpdateModel.SalaryId);
                    command.Parameters.AddWithValue("@salary", salaryUpdateModel.EmployeeSalary);
                    command.Parameters.AddWithValue("@EmpID", salaryUpdateModel.EmployeeId);
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            displayModel.EmployeeId = Convert.ToInt32(dr["Id"]);
                            displayModel.EmployeeName = dr["Name"].ToString();
                            displayModel.EmployeeSalary = Convert.ToInt32(dr["Salary"]);
                            Console.WriteLine(displayModel.EmployeeId + " " + displayModel.EmployeeName + " " + displayModel.EmployeeSalary);
                            Console.WriteLine("\n");
                            salary = displayModel.EmployeeSalary;
                            update = displayModel.IsUpdated;
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                SalaryConnection.Close();
            }
            //return salary;
            return update;
        }
    }
}
