using System;
using System.Collections.Generic;

namespace SSE662Project1.Objects
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            // Create variables
            Record ZacRecord = new Record("Zac's record");
            string file1 = @"C:\Users\Maggie\Desktop\School Stuff\Masters\Spring 2019\Chase.CSV";
            FileReader f = new FileReader();
            List<string> categoryTotals;

            f.ReadFromFile(file1, ZacRecord); // Populate ZacRecord from file1
            Console.WriteLine(ZacRecord); // Print ZacRecord

            // Populate categoryTotals from ZacRecord and print them out
            categoryTotals = ZacRecord.CategoryTotals(); 
            for(int i = 0; i<categoryTotals.Count; i++)
                Console.WriteLine(categoryTotals[i]); 

            // Print out range of dates from ZacRecord
            Console.WriteLine("Start date: " + ZacRecord.DateRange()[0]);
            Console.WriteLine("End date: " + ZacRecord.DateRange()[1]);
            Console.ReadLine();
        }
    }
}
