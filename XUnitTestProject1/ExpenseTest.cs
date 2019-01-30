using System;
using Xunit;
using SSE662Project1.Objects;

namespace SSE662Project1Test
{
    public class ExpenseTest
    {
        private const string pricestring = "-30.50";
        private double testprice = -Convert.ToDouble(pricestring);
        private const string vendorstring = "EXAMPLE VENDOR AMC";
        private const string datestring = "01/01/0001";
        private DateTime testdate = DateTime.Parse(datestring);
        private Category testcategory = new Category(vendorstring);

        private const string pricestring2 = "-30.51";
        private double testprice2 = -Convert.ToDouble(pricestring2);
        private const string vendorstring2 = "EXAMPLE VENDOR2 FLIGHT";
        private const string datestring2 = "01/01/0002";
        private DateTime testdate2 = DateTime.Parse(datestring2);
        private Category testcategory2 = new Category(vendorstring2);

        [Fact]
        public void ExpenseEqualsTest()
        {
            // Test the not equal case
            var testExpenseNULL = new Expense(null, null, null);
            var testExpense = new Expense(datestring, pricestring, vendorstring);
            Assert.False(testExpenseNULL.Equals(testExpense));

            // Test the equal case
            var testExpense0 = new Expense(datestring, pricestring, vendorstring);
            Assert.True(testExpense0.Equals(testExpense));
        }

        [Fact]
        public void CreateExpenseTest()
        {
            // Test the not equal case (using a null Expense)
            var testExpense0 = new Expense(null, null, null);
            Assert.NotEqual(testdate, testExpense0.ExpenseDate);
            Assert.NotEqual(testprice, testExpense0.ExpensePrice);
            Assert.NotEqual(vendorstring, testExpense0.ExpenseVendor);
            Assert.False(testcategory.Equals(testExpense0.ExpenseCategory));

            // Test the equal case
            var testExpense = new Expense(datestring, pricestring, vendorstring);
            Assert.Equal(testdate, testExpense.ExpenseDate);
            Assert.Equal(testprice, testExpense.ExpensePrice);
            Assert.Equal(vendorstring, testExpense.ExpenseVendor);
            Assert.True(testcategory.Equals(testExpense.ExpenseCategory));
        }

        [Fact]
        public void EditExpenseTest()
        {
            var testExpense = new Expense(datestring, pricestring, vendorstring);
            
            // Test to show that it was created successfully
            Assert.Equal(testdate, testExpense.ExpenseDate);
            Assert.Equal(testprice, testExpense.ExpensePrice);
            Assert.Equal(vendorstring, testExpense.ExpenseVendor);
            Assert.True(testcategory.Equals(testExpense.ExpenseCategory));

            // Show that it is not equal to what it will be changed to 
            Assert.NotEqual(testdate2, testExpense.ExpenseDate);
            Assert.NotEqual(testprice2, testExpense.ExpensePrice);
            Assert.NotEqual(vendorstring2, testExpense.ExpenseVendor);
            Assert.False(testcategory2.Equals(testExpense.ExpenseCategory));

            // Change it
            testExpense.ExpenseDate = testdate2;
            testExpense.ExpensePrice = testprice2;
            testExpense.ExpenseVendor = vendorstring2;

            // Show that it is now equal to what was changed to 
            Assert.Equal(testdate2, testExpense.ExpenseDate);
            Assert.Equal(testprice2, testExpense.ExpensePrice);
            Assert.Equal(vendorstring2, testExpense.ExpenseVendor);
            Assert.True(testcategory2.Equals(testExpense.ExpenseCategory));
        }

        [Fact]
        public void ExpenseHashCodeTest()
        {
            var testExpenseNULL = new Expense(null, null, null);
            var testExpense = new Expense(datestring, pricestring, vendorstring);
            Assert.NotEqual(testExpenseNULL.GetHashCode(), testExpense.GetHashCode());
            var testExpense0 = new Expense(datestring, pricestring, vendorstring);
            Assert.Equal(testExpense0.GetHashCode(), testExpense.GetHashCode());
        }

        [Fact]
        public void ExpenseToStringTest()
        {
            var testExpenseNULL = new Expense(null, null, null);
            var testExpense = new Expense(datestring, pricestring, vendorstring);
            Assert.NotEqual(testExpenseNULL.ToString(), testExpense.ToString());
            var testExpense0 = new Expense(datestring, pricestring, vendorstring);
            Assert.Equal(testExpense0.ToString(), testExpense.ToString());
        }
    }
}
