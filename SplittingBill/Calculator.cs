using System;
using System.Collections.Generic;
using System.Text;

namespace SplittingBill
{
    public class Calculator
    {
        private List<Account> accounts;

        //----------------------------------------------------------------------------
        /// <summary>
        /// Creates a list of accounts in order to split the costs.
        /// </summary>
        /// <param name="numAccounts">Number of accounts to be created</param>
        public Calculator(int numAccounts)
        {
            accounts = new List<Account>();
            for (int i = 0; i < numAccounts; i++)
            {
                accounts.Add(new Account());
            }


        }



        //----------------------------------------------------------------------------
        /// <summary>
        /// Add a value paid by an account. Accounts are accessed through zero-based index.
        /// </summary>
        /// <param name="index">Account index - zero based</param>
        /// <param name="amount">Amount paid - can be negative</param>
        public void AccountPay(int index, decimal amount)
        {
            accounts[index].Pay(amount);
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Sums all expenses from all accounts
        /// </summary>
        /// <returns></returns>
        public decimal GetTotals()
        {
            decimal total = 0.0m;
            foreach (Account ac in accounts)
            {
                total += ac.GetAmountPaid();
            }

            return Math.Round(total, 2);
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Splits the bill into equal parts between accounts
        /// </summary>
        /// <returns></returns>
        public decimal Split()
        {
            int numAcc = accounts.Count;

            decimal split = GetTotals() / numAcc;
            return split;
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Sets to each account the net amount due
        /// </summary>
        private void ShareDue()
        {
            decimal varSplit = Split();

            foreach (Account ac in accounts)
            {
                ac.AmountDue = (decimal)varSplit - (decimal)ac.GetAmountPaid();
            }


        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Returns a string with the net amount due of each account. One account per line.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            ShareDue(); //calculates the share due for each account
            StringBuilder sb = new StringBuilder();
            foreach (Account ac in accounts)
            {

                sb.AppendLine(ac.AmountDue.ToString("$#,##0.00;($#,##0.00)"));

            }

            return sb.ToString();

        }



    }
}
