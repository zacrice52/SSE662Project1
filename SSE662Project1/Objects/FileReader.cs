using System;
using System.IO;
using System.Collections.Generic;

namespace SSE662Project1.Objects
{
    public class FileReader
    {
        public void ReadFromFile(string filename, Record record)
        {
            using (var reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    //Console.WriteLine(values[2]);
                    // Note: values = [date, price, vendor]
                    Expense expense = new Expense(values[0], values[1], values[2]);
                    record.AddExpense(expense);
                }
            }
        }
    }
}
