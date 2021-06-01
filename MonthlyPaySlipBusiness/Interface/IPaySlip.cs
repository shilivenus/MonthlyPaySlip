namespace MonthlyPaySlipBusiness.Interface
{
    public interface IPaySlip
    {
        decimal GetMonthlyIncomeTax(decimal annualSalary);
        decimal GetMonthlyGrossPayment(decimal annualSalary);
        decimal GetNetMonthlyPayment(decimal monthlyGrossPayment, decimal monthlyIncomeTax);
    }
}
