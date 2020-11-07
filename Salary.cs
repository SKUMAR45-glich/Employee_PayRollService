using System;
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

        public int UpdateEmployeeSalary(SalaryUpdateModel salaryUpdateModel)
        {
            SqlConnection SalaryConnection = ConnectionSetup();
            int salary = 0;

            try
            {
                using (SalaryConnection)
                {
                    SalaryDetailModel displayModel = new SalaryDetailModel();
                    SqlCommand command = new SqlCommand("spUpdateEmployeeSalary", SalaryConnection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", salaryUpdateModel.SalaryId);
                    command.Parameters.AddWithValue("@month", salaryUpdateModel.Month);
                    command.Parameters.AddWithValue("@salary", salaryUpdateModel.EmployeeSalary);
                    command.Parameters.AddWithValue("@EmpId", salaryUpdateModel.EmployeeId);
                    SalaryConnection.Open();
                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            displayModel.SalaryId = Convert.ToInt32(dr["SALARYId"]);
                            //displayModel.JobDescription = dr["jOB"].ToString();
                            displayModel.Month = dr["SAL_MONTH"].ToString();
                            displayModel.EmployeeSalary = Convert.ToInt32(dr["EMPSAL"]);
                            displayModel.EmployeeId = Convert.ToInt32(dr["EmpId"]);

                            //displayModel.EmployeeName = dr["ENAME"].ToString();

                            Console.WriteLine(displayModel.EmployeeName + " " + displayModel.EmployeeSalary + " " + displayModel.EmployeeId);
                            Console.WriteLine("\n");
                            salary = displayModel.EmployeeSalary;

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
            return salary;
        }
    }
}
