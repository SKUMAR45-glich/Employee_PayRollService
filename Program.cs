﻿using System;

namespace EmployeePayRollService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Employee PayRoll Service!");

            EmployeeRepo repo = new EmployeeRepo();                                    //Declare Object for EmployeeRepo Class
            repo.GetAllEmployee();                                                    //Get Details for Employee

            EmployeeModel employee = new EmployeeModel();                           //Declare Object for EmployeeModel Class
            employee.EmployeeName = "XYZ";
            employee.Department = "Management";
            employee.PhoneNumber = "6302907917";
            employee.Address = "12-AAAAAAA";
            employee.Gender = 'M';
            employee.BasicPay = 11000.00M;
            employee.Deductions = 1600.00;
            employee.TaxablePay = 2600.00;
            employee.Tax = 1900.00;
            employee.NetPay = 1500.00;
            employee.StartDate = Convert.ToDateTime("2020-11-08");

            if (repo.AddEmployee(employee))                                                        
                Console.WriteLine("Records added successfully");                                 //Adding Data to Table


            int count = repo.GetInsertionsinEmployeeTable(employee);

            if(count>2)
            {
                employee.EmployeeName = Console.ReadLine();
                employee.Department = Console.ReadLine();
                employee.PhoneNumber = Console.ReadLine();
                employee.Address = Console.ReadLine();
                employee.Gender = Convert.ToChar(Console.ReadLine());
                employee.BasicPay = (System.Data.SqlTypes.SqlMoney)Convert.ToDouble(Console.ReadLine());
                employee.Deductions = Convert.ToDouble(Console.ReadLine());
                employee.TaxablePay = Convert.ToDouble(Console.ReadLine());
                employee.Tax = Convert.ToDouble(Console.ReadLine());
                employee.NetPay = Convert.ToDouble(Console.ReadLine());
                employee.StartDate = Convert.ToDateTime(Console.ReadLine());

                if (repo.AddEmployee(employee))
                    Console.WriteLine("Records added successfully");                               //Adding Data to Table
            }



            ///   UC9_JustForImplication

            Salary salary = new Salary();                                                        // Salary Model

            SalaryUpdateModel salaryUpdateModel = new SalaryUpdateModel { SalaryId = 1, EmployeeSalary = 3000000 };               //Update Salary

            bool updatedSalary = salary.UpdateEmployeeSalary(salaryUpdateModel);

            if(updatedSalary==true)
            {
                if(employee.EmployeeID == salaryUpdateModel.SalaryId)
                {
                    employee.BasicPay = salaryUpdateModel.EmployeeSalary;
                    repo.AddEmployee(employee);
                }
                
            }


            //Console.WriteLine(updatedSalary);

            /*DateTime startDate = Convert.ToDateTime("01/01/2018");                                    //Get Data in the Range of Data
            DateTime endDate = Convert.ToDateTime("01/01/2019");

            repo.GetAllEmployeeInGivenDateRange(startDate, endDate);
        */
            //repo.GetCountAvgMinMaxinEmployee(employee);                                             //Get Females Count with Max Min Data


            repo.RemoveEmployeeDetails("Indal", 8);
        }
    }
}
