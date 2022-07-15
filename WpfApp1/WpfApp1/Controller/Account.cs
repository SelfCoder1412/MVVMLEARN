using System;

namespace WpfApp1.Controller
{
    public class Account
    {
        private double accountBalance = 0.00;
        private bool accountStatus = false;

        private enum Roles
        {
            Customer,
            Manager
        }

        public bool IsAccountActive(string accNumber)
        {

            if (accNumber == null)
            {
                accountStatus = false;
            }
            else if (string.IsNullOrWhiteSpace(accNumber))
            {
                throw new ArgumentException("Account number Can't be Null or have White Spaces");  
            }
            else
            {
                accountStatus = true;
            }

            return accountStatus;
        }

        public double CalculateDiscount(double SalesAmnt)
        {
            double discountPrice = 0.0;

            if (SalesAmnt == 0 || SalesAmnt < 0)
            {
                throw new ArgumentException(" Sales Amount should not be 'Zero/Negative'");
            }
            else if (SalesAmnt >= 1000 && SalesAmnt < 2000)
            {
                // 5% Discount  
                discountPrice = SalesAmnt - (SalesAmnt * 0.05);
            }
            else if (SalesAmnt >= 2000 && SalesAmnt < 5000)
            {
                // 10% Discount  
                discountPrice = SalesAmnt - (SalesAmnt * 0.1);
            }

            else if (SalesAmnt >= 5000 && SalesAmnt < 20000)
            {
                // 50% Discount  
                discountPrice = SalesAmnt - (SalesAmnt * 0.5);
            }
            else
            {
                // No Discount  
                discountPrice = SalesAmnt - 0.0;
            }

            return discountPrice;
        }

        public double Balance(string accNumber)
        {
            return accountBalance;
        }

        public double Deposit(string accNumber, double amount)
        {
            return accountBalance = accountBalance + amount;
        }

        public double Withdrawal(string accNumber, double amount)
        {
            return accountBalance = accountBalance - amount;
        }

        private bool ActivateAccount(string accNumber, Roles userRole)
        {
            accountStatus = true;
            return accountStatus;
        }
    }
}
