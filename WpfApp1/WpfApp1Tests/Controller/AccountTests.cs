using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp1.Controller;
using System;

namespace WpfApp1Tests.Controller.Tests
{
    [TestClass()]
    public class AccountTests
    {
        private Account obj = new Account();
        [TestMethod]
        [Priority(0)]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAccountStatus_AccountNumberWhiteSpace_ArgumentException_Success()
        {
            obj.IsAccountActive(" ");
        }
        // Exception is thrown if Null is passed as account number  
        [TestMethod]
        [Priority(0)]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAccountStatus_ArgumentException_Success()
        {
            obj.IsAccountActive(null);
        }

        public void TestAccountStatus_Active_Success()
        {
            Assert.IsTrue(obj.IsAccountActive("1234"), "Failed Account is not Active");
        }

        // Test Case#1: Sales Amount is Greater or Equal than 1000: Verification  
        [TestMethod]
        public void OneThousand_G_E()
        {
            
            Assert.AreEqual(950, obj.CalculateDiscount(1000));
        }

        // Test Case#6: Sales Amount is not producing expected Result : Verification  
        [TestMethod]
        public void OneThousand()
        {
            Assert.AreNotEqual(930, obj.CalculateDiscount(1000));
        }

        // Test Case#2: Sales Amount is Greater or Equal than 2000: Verification  
        [TestMethod]
        public void TwoThousand_G_E()
        {
           

            Assert.AreEqual(1800, obj.CalculateDiscount(2000));
        }

        // Test Case#3: Sales Amount is Greater or Equal than 5000: Verification  
        [TestMethod]
        public void FiveThousand_G_E()
        {
           

            Assert.AreEqual(2500, obj.CalculateDiscount(5000));
        }

        // Test Case#4: Sales Amount is 0 : Verification  
        [TestMethod]
        public void ZeroAmount()
        {
           
            try
            {
                obj.CalculateDiscount(0);
            }
            catch (Exception e) { }

        }

        // Test Case#5: Sales Amount is below 1000: Verification  
        [TestMethod]
        public void OneThousand_Below()
        {
           
            Assert.AreEqual(999, obj.CalculateDiscount(999));
        }

        // Test Case#7: Sales Amount is not producing expected Result: Verification  
        [TestMethod]
        public void TwoThousand()
        {
           

            Assert.AreNotEqual(1900, obj.CalculateDiscount(2000));
        }

    }
}