using System;
using System.Collections.Generic;
using System.Text;

namespace SplittingBill
{
    
    public class Account
    {
        decimal amountPaid = 0.0m;
        private decimal amountDue = 0.0m;

        /// <summary>
        /// The net value due. Can return negative values.
        /// </summary>
        public decimal AmountDue {
            get
            {
                return amountDue;
            }
            set
            {
                amountDue = value;
            }
        }




        /// <summary>
        /// Adds the amount paid by an account.
        /// </summary>
        /// <param name="_amountPaid"></param>
        public void Pay(decimal _amountPaid)
        {
            amountPaid += _amountPaid;
        }

        /// <summary>
        /// Returns the full amount paid by an account.
        /// </summary>
        /// <returns></returns>

        public decimal GetAmountPaid()
        {
            return amountPaid;
        }




    }
}
