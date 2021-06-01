using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyPaySlip.Interface
{
    public interface IPaySlip
    {
        decimal GetMonthlyIncomeTax(decimal annualSalary);
        decimal GetMonthlyGrossPayment(decimal annualSalary);
        decimal GetNetMonthlyPayment(decimal monthlyGrossPayment, decimal monthlyIncomeTax);
    }
}
