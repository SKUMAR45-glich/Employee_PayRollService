using System;

namespace EmployeePayRollService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Employee PayRoll Service!");

            EmployeeRepo repo = new EmployeeRepo();
            repo.GetAllEmployee();

            EmployeeModel employee = new EmployeeModel();
            employee.EmployeeName = "Indal";
            employee.Department = "Tech";
            employee.PhoneNumber = "6302907918";
            employee.Address = "02-Khajauli";
            employee.Gender = 'M';
            employee.BasicPay = 10000.00M;
            employee.Deductions = 1500.00;
            employee.TaxablePay = 2500.00;
            employee.Tax = 1800.00;
            employee.NetPay = 1200.00;
            employee.StartDate = Convert.ToDateTime("2020-11-03");

            if (repo.AddEmployee(employee))
                Console.WriteLine("Records added successfully");



            //Salary salary = new Salary();

            //SalaryUpdateModel salaryUpdateModel = new SalaryUpdateModel { SalaryId = 1, EmployeeSalary = 3000000 };

            //var updatedSalary = salary.UpdateEmployeeSalary(salaryUpdateModel);

            //Console.WriteLine(updatedSalary);

            /*DateTime startDate = Convert.ToDateTime("01/01/2018");
            DateTime endDate = Convert.ToDateTime("01/01/2019");

            repo.GetAllEmployeeInGivenDateRange(startDate, endDate);
        */}
    }
}
