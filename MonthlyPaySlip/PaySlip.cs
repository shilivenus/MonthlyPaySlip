using MonthlyPaySlip.Interface;
using System;
using System.Collections.Generic;

namespace MonthlyPaySlip
{
    public class PaySlip : IPaySlip
    {
        private List<decimal> TaxRateRageList = new List<decimal> { 20000, 40000, 80000, 180000 };

        public decimal GetMonthlyIncomeTax(decimal annualSalary)
        {
            if (annualSalary <= 0)
                throw new Exception("Annuel salary is less than 0.");

            TaxRateRageList.Add(annualSalary);
            TaxRateRageList.Sort();

            decimal Sumtax = 0;

            for(int i = 0; i <= 5; i++)
            {
                if(TaxRateRageList[i] == annualSalary && i == 0)
                {
                    return Sumtax;
                }

                if(TaxRateRageList[i] == annualSalary && i != 0)
                {
                    Sumtax = Sumtax + ((annualSalary - TaxRateRageList[i - 1]) * i / 10);

                    return Sumtax/12;
                }

                if(i >= 1)
                {
                    Sumtax = Sumtax + ((TaxRateRageList[i] - TaxRateRageList[i - 1]) * i / 10);
                }                
            }

            return -1;
        }

        public decimal GetMonthlyGrossPayment(decimal annualSalary)
        {
            if (annualSalary <= 0)
                throw new Exception("Annuel salary is less than 0.");

            return annualSalary / 12;
        }

        public decimal GetNetMonthlyPayment(decimal monthlyGrossPayment, decimal monthlyIncomeTax)
        {
            if (monthlyGrossPayment <= 0)
                throw new Exception($"Invalid monthly gross payment {monthlyGrossPayment}.");

            return monthlyGrossPayment - monthlyIncomeTax;
        }
    }
}
