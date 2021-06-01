using System;

namespace MonthlyPaySlip
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();
            Console.WriteLine("please Type in Employee name.");
            employee.Name = Console.ReadLine();

            Console.WriteLine("please Type in annual salary.");
            employee.AnnualSarary = decimal.Parse(Console.ReadLine());

            PaySlip paySlip = new PaySlip();
            var monthlyGrossPayment = paySlip.GetMonthlyGrossPayment(employee.AnnualSarary);
            var monthlyIncomeTax = paySlip.GetMonthlyIncomeTax(employee.AnnualSarary);
            var monthlyNetPayment = paySlip.GetNetMonthlyPayment(monthlyGrossPayment, monthlyIncomeTax);

            Console.WriteLine($"Monthly Payslip for: {employee.Name}");
            Console.WriteLine($"Gross Monthly Income: ${monthlyGrossPayment}");
            Console.WriteLine($"Monthly Income Tax: ${monthlyIncomeTax}");
            Console.WriteLine($"Net Monthly Income: ${monthlyNetPayment}");

            Console.ReadLine();
        }
    }
}
