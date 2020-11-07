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
            employee.name = "Indal";
            employee.Department = "Tech";
            employee.phone = "6302907918";
            employee.address = "02-Khajauli";
            employee.gender = 'M';
            employee.salary = 10000.00M;
            employee.Deduction = 1500.00;
            employee.taxable_pay = 2500.00;
            employee.income_tax = 1800.00;
            employee.net_pay = 1200.00;
            employee.start = employee.start = Convert.ToDateTime("2020-11-03");

            if (repo.AddEmployee(employee))
                Console.WriteLine("Records added successfully");



            Salary salary = new Salary();

            SalaryUpdateModel salaryUpdateModel = new SalaryUpdateModel { SalaryId = 1, EmployeeSalary = 3000000 };

            var updatedSalary = salary.UpdateEmployeeSalary(salaryUpdateModel);

            Console.WriteLine(updatedSalary);

            DateTime startDate = Convert.ToDateTime("01/01/2018");
            DateTime endDate = Convert.ToDateTime("01/01/2019");

            EmployeeRepo.GetAllEmployeeInGivenDateRange(startDate, endDate);
        }
    }
}
