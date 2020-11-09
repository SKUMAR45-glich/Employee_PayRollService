using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeePayRollService;

namespace SalaryDetailTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenSalaryDataAbleToUpdateSalaryDetails()
        {
            Salary salary = new Salary();
            SalaryUpdateModel updateModel = new SalaryUpdateModel()
            {
                SalaryId = 2,
                EmployeeSalary = 1300,
                EmployeeId = 5
            };
            int EmpSalary = salary.UpdateEmployeeSalary(updateModel);

            Assert.AreEqual(updateModel.EmployeeSalary, EmpSalary);
        }
    }
}
