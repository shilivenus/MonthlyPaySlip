using MonthlyPaySlip;
using System;
using Xunit;

namespace MonthlyPaySlipTests
{
    public class PaySlipTests
    {
        private readonly PaySlip _paySlip = new PaySlip();

        [Fact]
        public void GetMonthlyIncomeTax_ValidAnnualSalary_ReturnMonthlyIncomeTax()
        {
            //Act
            var result = _paySlip.GetMonthlyIncomeTax(60000);

            //Assert
            Assert.Equal(500, result);
        }

        [Fact]
        public void GetMonthlyIncomeTax_InValidAnnualSalary_ThrowException()
        {
            //Assert
            Assert.Throws<Exception>(() => _paySlip.GetMonthlyIncomeTax(0));
        }

        [Fact]
        public void GetMonthlyGrossPayment_ValidAnnualSalary_ReturnMonthlyGrossPayment()
        {
            //Act
            var result = _paySlip.GetMonthlyGrossPayment(60000);

            //Assert
            Assert.Equal(5000, result);
        }

        [Fact]
        public void GetMonthlyGrossPayment_InValidAnnualSalary_ThrowException()
        {
            //Assert
            Assert.Throws<Exception>(() => _paySlip.GetMonthlyGrossPayment(0));
        }

        [Fact]
        public void GetNetMonthlyPayment_ValidMonthlyGrossPaymentAndMonthlyIncomeTax_ReturnNetMonthlyPayment()
        {
            //Act
            var result = _paySlip.GetNetMonthlyPayment(5000, 500);

            //Assert
            Assert.Equal(4500, result);
        }

        [Fact]
        public void GetNetMonthlyPayment_InValidMonthlyGrossPaymentAndMonthlyIncomeTax_ThrowException()
        {
            //Assert
            Assert.Throws<Exception>(() => _paySlip.GetNetMonthlyPayment(0, 500));
        }
    }
}
