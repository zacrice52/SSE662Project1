using System;
using Xunit;
using Xunit.Abstractions;
using SSE662Project1.Objects;

namespace SSE662Project1Test
{
    public class FileReaderTest
    {
        private const string filename = @"C:\Users\Maggie\Desktop\School Stuff\Masters\Spring 2019\sample.csv";
        private const string recordname = "Sample Record";
        private const string pricestring = "-30.50";
        private const string vendorstring = "EXAMPLE VENDOR AMC";
        private const string datestring = "01/01/0001";
        private Expense testExpense = new Expense(datestring, pricestring, vendorstring);

        private const string pricestring2 = "-30.51";
        private const string vendorstring2 = "EXAMPLE VENDOR2 FLIGHT";
        private const string datestring2 = "01/01/0002";
        private Expense testExpense2 = new Expense(datestring2, pricestring2, vendorstring2);

        private readonly ITestOutputHelper output;

        public FileReaderTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void ReadFromFileTest()
        {
            var f = new FileReader();
            var testRecord = new SSE662Project1.Objects.Record(recordname);
            var testRecord2 = new SSE662Project1.Objects.Record(recordname);
            testRecord.AddExpense(testExpense);
            testRecord.AddExpense(testExpense2);
            Assert.False(testRecord.Equals(testRecord2));
            f.ReadFromFile(filename, testRecord2);
            output.WriteLine(testRecord.ToString());
            output.WriteLine(testRecord2.ToString());
            Assert.True(testRecord.Equals(testRecord2));
        }
    }
}
