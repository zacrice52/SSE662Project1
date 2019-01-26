using System;
using System.IO;
using System.Collections.Generic;

namespace SSE662Project1.Objects
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            string name = "Zac's record";
            Record ZacRecord = new Record(name);
            string file1 = @"C:\Users\Maggie\Desktop\School Stuff\Masters\Spring 2019\Chase.CSV";
            //string file2 = @"C:\Users\Maggie\Desktop\School Stuff\Masters\Spring 2019\WellsFargo.csv";
            FileReader f = new FileReader();
            f.ReadFromFile(file1, ZacRecord);
            //ReadFromFile(file2, ZacRecord);

            List<string> categoryTotals = ZacRecord.CategoryTotals();
            for(int i = 0; i<categoryTotals.Count; i++)
                Console.WriteLine(categoryTotals[i]);
            Console.WriteLine("Start date: " + ZacRecord.DateRange()[0]);
            Console.WriteLine("End date: " + ZacRecord.DateRange()[1]);
            Console.ReadLine();
        }
    }
}
