using SplittingBill;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using Microsoft.VisualStudio.TestPlatform;

namespace SplittingBillTests
{
    [TestClass]
    public class CalculatorTests
    {



        [TestMethod]
        public void TestCalculator_GetTotals_ValueZero()
        {
            Calculator calc = new Calculator(2);
            decimal expected = 0m;
            decimal result = calc.GetTotals();

            Assert.AreEqual(expected, result);

        }


        [TestMethod]
        public void TestCalculator_GetTotals_ValuePositive()
        {
            Calculator calc = new Calculator(2);
            decimal expected = 32.05m;

            calc.AccountPay(0, 3.69m);
            calc.AccountPay(0, 7.15m);

            calc.AccountPay(1, 11.22m);
            calc.AccountPay(1, 9.99m);


            decimal result = calc.GetTotals();

            Assert.AreEqual(expected, result);
        }



        [TestMethod]
        public void TestCalculator_GetTotals_ValueNegative()
        {
            Calculator calc = new Calculator(2);
            decimal expected = -7.22m;

            calc.AccountPay(0, 8.00m);
            calc.AccountPay(0, -14.41m);

            calc.AccountPay(1, 9.20m);
            calc.AccountPay(1, -10.01m);


            decimal result = calc.GetTotals();

            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void TestCalculator_Split_ValueZero()
        {
            Calculator calc = new Calculator(2);
            decimal expected = 0m;
            decimal result = calc.Split();

            Assert.AreEqual(expected, result);

        }


        [TestMethod]
        public void TestCalculator_Split_ValuePositive()
        {
            Calculator calc = new Calculator(2);
            decimal expected = 16.025m;

            calc.AccountPay(0, 3.69m);
            calc.AccountPay(0, 7.15m);

            calc.AccountPay(1, 11.22m);
            calc.AccountPay(1, 9.99m);


            decimal result = calc.Split();

            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void TestCalculator_Split_ValueNegative()
        {
            Calculator calc = new Calculator(2);
            decimal expected = -3.61m;

            calc.AccountPay(0, 8.00m);
            calc.AccountPay(0, -14.41m);

            calc.AccountPay(1, 9.20m);
            calc.AccountPay(1, -10.01m);


            decimal result = calc.Split();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestCalculator_ToString_ValueZero()
        {
            Calculator calc = new Calculator(2);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("$0.00");
            sb.AppendLine("$0.00");
            string expected = sb.ToString();

            string result = calc.ToString();

            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void TestCalculator_ToString_ValuePositive()
        {
            Calculator calc = new Calculator(2);
            calc.AccountPay(0, 3.69m);
            calc.AccountPay(0, 7.15m);

            calc.AccountPay(1, 11.22m);
            calc.AccountPay(1, 9.99m);



            StringBuilder sb = new StringBuilder();
            sb.AppendLine("$5.19");
            sb.AppendLine("($5.19)");
            string expected = sb.ToString();


            string result = calc.ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestCalculator_ToString_ValueNegative()
        {
            Calculator calc = new Calculator(2);
            calc.AccountPay(0, 8.00m);
            calc.AccountPay(0, -14.41m);

            calc.AccountPay(1, 9.20m);
            calc.AccountPay(1, -10.01m);



            StringBuilder sb = new StringBuilder();
            sb.AppendLine("$2.80");
            sb.AppendLine("($2.80)");
            string expected = sb.ToString();


            string result = calc.ToString();

            Assert.AreEqual(expected, result);

        }

    }
}
