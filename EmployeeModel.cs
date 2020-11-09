using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace EmployeePayRollService
{
    class EmployeeModel
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string PhoneNumber { get; set; }
        public SqlMoney BasicPay { get; set; }
        public DateTime StartDate { get; set; }
        public char Gender { get; set; }
        public double Deductions { get; set; }

        public double TaxablePay { get; set; }
        public double Tax { get; set; }
        public double NetPay { get; set; }


        public string Address { get; set; }

        public string Department { get; set; }

        public void Display()
        {
            Console.WriteLine(EmployeeID + " " + EmployeeName + " " + BasicPay + " " + PhoneNumber + " " + Address + " " +
                Department + " " + Gender + " " + Deductions + " " + TaxablePay + " " + Tax + " " + NetPay);
            Console.WriteLine();
        }

    }
}
