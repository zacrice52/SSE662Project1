using System;
using Xunit;
using Xunit.Abstractions;
using SSE662Project1.Objects;

namespace SSE662Project1Test
{
    public class RecordTest
    {
        private const string recordname = "Sample Record";
        private const string recordname2 = "Sample Record2";
        private const string pricestring = "-30.50";
        private double testprice = -Convert.ToDouble(pricestring);
        private const string vendorstring = "EXAMPLE VENDOR AMC";
        private const string datestring = "01/01/0001";
        private DateTime testdate = DateTime.Parse(datestring);
        private Category testcategory = new Category(vendorstring);
        private Expense testExpense = new Expense(datestring, pricestring, vendorstring);

        private const string pricestring2 = "-30.51";
        private const string vendorstring2 = "EXAMPLE VENDOR2 FLIGHT";
        private const string datestring2 = "01/01/0002";
        private DateTime testdate2 = DateTime.Parse(datestring2);
        private Expense testExpense2 = new Expense(datestring2, pricestring2, vendorstring2);

        private readonly ITestOutputHelper output;

        public RecordTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void RecordEqualsTest()
        {
            var testRecord = new SSE662Project1.Objects.Record(recordname);
            var testRecord2 = new SSE662Project1.Objects.Record(recordname2);
            Assert.False(testRecord.Equals(testRecord2));
            testRecord.AddExpense(testExpense);
            testRecord2.AddExpense(testExpense);
            Assert.False(testRecord.Equals(testRecord2));
            testRecord2.RecordName = recordname;
            Assert.True(testRecord.Equals(testRecord2));
        }

        [Fact]
        public void RecordToStringTest()
        {
            var testRecord = new SSE662Project1.Objects.Record(recordname);
            var testRecord2 = new SSE662Project1.Objects.Record(recordname2);
            Assert.NotEqual(testRecord.ToString(), testRecord2.ToString());
            testRecord.AddExpense(testExpense);
            testRecord2.AddExpense(testExpense);
            Assert.NotEqual(testRecord.ToString(), testRecord2.ToString());
            testRecord2.RecordName = recordname;
            Assert.Equal(testRecord.ToString(), testRecord2.ToString());
        }

        [Fact]
        public void RecordHashCodeTest()
        {
            var testRecord = new SSE662Project1.Objects.Record(recordname);
            var testRecord2 = new SSE662Project1.Objects.Record(recordname2);
            Assert.NotEqual(testRecord.GetHashCode(), testRecord2.GetHashCode());
            testRecord.AddExpense(testExpense);
            testRecord2.AddExpense(testExpense);
            Assert.NotEqual(testRecord.GetHashCode(), testRecord2.GetHashCode());
            testRecord2.RecordName = recordname;
            Assert.Equal(testRecord.GetHashCode(), testRecord2.GetHashCode());
        }

        [Fact]
        public void CreateRecordTest()
        {
            var testRecordNULL = new SSE662Project1.Objects.Record(null);
            Assert.NotEqual(testRecordNULL.RecordName, recordname);
            Assert.Empty(testRecordNULL.Expenses);
            var testRecord = new SSE662Project1.Objects.Record(recordname);
            Assert.Equal(testRecord.RecordName, recordname);
            Assert.Empty(testRecord.Expenses);
        }

        [Fact]
        public void EditRecordTest()
        {
            var testRecord = new SSE662Project1.Objects.Record(null);
            Assert.NotEqual(testRecord.RecordName, recordname);
            testRecord.RecordName = recordname;
            Assert.Equal(testRecord.RecordName, recordname);
        }

        [Fact]
        public void AddExpenseTest()
        {
            var testRecord = new SSE662Project1.Objects.Record(recordname);
            Assert.Equal(testRecord.RecordName, recordname);
            Assert.Empty(testRecord.Expenses);
            testRecord.AddExpense(testExpense);
            Assert.Equal(testRecord.RecordName, recordname);
            Assert.NotEmpty(testRecord.Expenses);
            Assert.Equal(testdate, testRecord.Expenses[0].ExpenseDate);
            Assert.Equal(testprice, testRecord.Expenses[0].ExpensePrice);
            Assert.Equal(vendorstring, testRecord.Expenses[0].ExpenseVendor);
            Assert.True(testcategory.Equals(testRecord.Expenses[0].ExpenseCategory));
        }

        [Fact]
        public void CategoryTotalsTest()
        {
            var testRecord = new SSE662Project1.Objects.Record(recordname);
            Assert.NotEqual(testcategory.categoryID + " total: " + testprice.ToString(), 
                            testRecord.CategoryTotals()[1]);
            testRecord.AddExpense(testExpense);
            Assert.Equal(testcategory.categoryID + " total: " + testprice.ToString(), 
                         testRecord.CategoryTotals()[1]);
        }

        [Fact]
        public void DateRangeTest()
        {
            var testRecord = new SSE662Project1.Objects.Record(recordname);
            testRecord.AddExpense(testExpense);
            DateTime[] testrange = { testdate, testdate2 };
            Assert.NotEqual(testRecord.DateRange(), testrange);
            testRecord.AddExpense(testExpense2);
            Assert.Equal(testRecord.DateRange(), testrange);
        }
    }
}
