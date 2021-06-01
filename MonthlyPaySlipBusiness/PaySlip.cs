using MonthlyPaySlipBusiness.Interface;
using System;
using System.Collections.Generic;

namespace MonthlyPaySlipBusiness
{
    public class PaySlip : IPaySlip
    {
        private List<decimal> _taxRateRageList = new List<decimal> { 20000, 40000, 80000, 180000 };
        private readonly List<decimal> _taxRateList = new List<decimal> { 0, 0.1m, 0.2m, 0.3m, 0.4m };

        /// <summary>
        /// Get monthly income tax
        /// </summary>
        /// <param name="annualSalary">annual salary</param>
        /// <returns>Monthly income tax</returns>
        public decimal GetMonthlyIncomeTax(decimal annualSalary)
        {
            if (annualSalary <= 0)
                throw new Exception($"Annuel salary {annualSalary} is less than 0.");

            _taxRateRageList.Add(annualSalary);
            _taxRateRageList.Sort();

            decimal Sumtax = 0;

            for(int i = 0; i < _taxRateList.Count; i++)
            {
                if(_taxRateRageList[i] == annualSalary && i == 0)
                {
                    break;
                }

                if(_taxRateRageList[i] == annualSalary && i != 0)
                {
                    Sumtax += ((annualSalary - _taxRateRageList[i - 1]) * _taxRateList[i]);
                    break;
                }

                if(i >= 1)
                {
                    Sumtax += ((_taxRateRageList[i] - _taxRateRageList[i - 1]) * _taxRateList[i]);
                }                
            }

            return Math.Round(Sumtax/12, 3);
        }

        /// <summary>
        /// Get monthly gross payment
        /// </summary>
        /// <param name="annualSalary">annual salary</param>
        /// <returns>monthly gross payment</returns>
        public decimal GetMonthlyGrossPayment(decimal annualSalary)
        {
            if (annualSalary <= 0)
                throw new Exception($"Annuel salary {annualSalary} is less than 0.");

            return Math.Round(annualSalary/12, 3);
        }

        /// <summary>
        /// Get net monthly payment
        /// </summary>
        /// <param name="monthlyGrossPayment">monthly gorss payment</param>
        /// <param name="monthlyIncomeTax">monthly income tax</param>
        /// <returns>monthly net payment</returns>
        public decimal GetNetMonthlyPayment(decimal monthlyGrossPayment, decimal monthlyIncomeTax)
        {
            if (monthlyGrossPayment <= 0)
                throw new Exception($"Invalid monthly gross payment {monthlyGrossPayment}.");

            return monthlyGrossPayment - monthlyIncomeTax;
        }
    }
}
