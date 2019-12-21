using Microsoft.VisualStudio.TestTools.UnitTesting;
using SplittingBill;

namespace SplittingBillTests
{
    [TestClass]
    public class AccountTest
    {
        //------------------------------------------------------------
        [TestMethod]
        public void TestPay_ValueZero()
        {
            Account account = new Account();
            decimal expected = 0m;
            decimal result = account.GetAmountPaid();
            Assert.AreEqual(expected, result);
        }

        //------------------------------------------------------------
        [TestMethod]
        public void TestPay_PositiveValue()
        {
            Account account = new Account();
            decimal expected = 5.59m;
            account.Pay(10m);
            account.Pay(11.01m);
            account.Pay(12.02m);
            account.Pay(-27.44m);

            decimal result = account.GetAmountPaid();
            Assert.AreEqual(expected, result);

        }

        //------------------------------------------------------------
        [TestMethod]
        public void TestPay_NegativeValue()
        {
            Account account = new Account();
            decimal expected = -7.41m;
            account.Pay(10m);
            account.Pay(11.01m);
            account.Pay(12.02m);
            account.Pay(-40.44m);

            decimal result = account.GetAmountPaid();
            Assert.AreEqual(expected, result);

        }

        //------------------------------------------------------------
        [TestMethod]
        public void TestAmountDue_ValueZero()
        {
            Account account = new Account();
            decimal expected = 0m;
            decimal result = account.AmountDue;
            Assert.AreEqual(expected, result);

        }

        //------------------------------------------------------------
        [TestMethod]
        public void TestAmountDue_ValuePositive()
        {
            Account account = new Account();
            decimal expected = 23.03m;

            account.AmountDue = 11.01m + 12.02m;

            decimal result = account.AmountDue;
            Assert.AreEqual(expected, result);

        }

        //------------------------------------------------------------
        [TestMethod]
        public void TestAmountDue_ValueNegative()
        {
            Account account = new Account();
            decimal expected = -28.42m;

            account.AmountDue = 12.02m + (-40.44m);

            decimal result = account.AmountDue;
            Assert.AreEqual(expected, result);



        }



    }
}
