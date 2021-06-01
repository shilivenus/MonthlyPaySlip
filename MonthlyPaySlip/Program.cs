using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MonthlyPaySlipBusiness;
using MonthlyPaySlipBusiness.Interface;
using MonthlyPaySlipBusiness.Model;

namespace MonthlyPaySlip
{
    public class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder()
               .ConfigureServices((context, services) =>
               {
                   services.AddTransient<IPaySlip, PaySlip>();
               })
               .Build();

            var paySlip = host.Services.GetService<IPaySlip>();
            var logger = host.Services.GetRequiredService<ILogger<Program>>();

            try
            {
                Employee employee = new Employee();
                Console.WriteLine("please Type in Employee name.");
                employee.Name = Console.ReadLine();

                Console.WriteLine("please Type in annual salary.");
                employee.AnnualSarary = decimal.Parse(Console.ReadLine());

                var monthlyGrossPayment = paySlip.GetMonthlyGrossPayment(employee.AnnualSarary);
                var monthlyIncomeTax = paySlip.GetMonthlyIncomeTax(employee.AnnualSarary);
                var monthlyNetPayment = paySlip.GetNetMonthlyPayment(monthlyGrossPayment, monthlyIncomeTax);

                Console.WriteLine($"Monthly Payslip for: {employee.Name}");
                Console.WriteLine($"Gross Monthly Income: ${monthlyGrossPayment}");
                Console.WriteLine($"Monthly Income Tax: ${monthlyIncomeTax}");
                Console.WriteLine($"Net Monthly Income: ${monthlyNetPayment}");

                Console.ReadLine();
            }
            catch(Exception e)
            {
                logger.LogError(e, e.Message);
            }
        }
    }
}
