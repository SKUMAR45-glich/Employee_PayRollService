using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayRollService
{
    class EmployeeModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public decimal salary { get; set; }
        public DateTime start { get; set; }
        public char gender { get; set; }
        public double Deduction { get; set; }

        public double taxable_pay { get; set; }
        public double income_tax { get; set; }
        public double net_pay { get; set; }


        public string address { get; set; }

        public string Department { get; set; }

        public void Display()
        {
            Console.WriteLine(id + " " + name + " " + salary + " " + phone + " " + address + " " +
                Department + " " + gender + " " + Deduction + " " + taxable_pay + " " + taxable_pay + " " + net_pay);
            Console.WriteLine();
        }

    }
}
