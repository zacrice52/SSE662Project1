using System;
using System.Collections.Generic;

namespace SSE662Project1.Objects
{
    public class Record
    {
        public List<Expense> Expenses; // Contains expenses

        public Record(string accountName)
        {
            RecordName = accountName;
            Expenses = new List<Expense>();
        }

        public string RecordName { get; set; }

        public void AddExpense(Expense expense)
        {
            if (!(expense.ExpenseVendor.ToLower().Contains("payment"))) // Don't want to add payments to the credit card to the budget
            {
                Expenses.Add(expense);
            }
        }

        // Totals up the expenses in each category
        public List<string> CategoryTotals()
        {
            Category dummy = new Category(null);
            string[] Categories = dummy.Categories;//{ "Vacation", "Recreation", "Groceries", "Medical", "Dental", "Utilities", "Allowance", "Car", "Pet", "Rent", "Other" };
            
            List<string> results = new List<string>();
            List<double> totals = new List<double>();
            for (int i = 0; i < Categories.Length; i++)
            {
                double CategoryTotal = 0;
                for (int j = 0; j < Expenses.Count; j++)
                {
                    if (string.Equals(Expenses[j].ExpenseCategory.categoryID, Categories[i]))
                    {
                        CategoryTotal += Expenses[j].ExpensePrice;
                    }
                }
                results.Add(Categories[i] + " total: " + CategoryTotal.ToString());
            }            
            return results;
        }

        // Finds the earliest and latest expenses in the record
        public DateTime[] DateRange()
        {
            DateTime min = Expenses[0].ExpenseDate;
            DateTime max = Expenses[0].ExpenseDate;
            for(int i = 0; i<Expenses.Count; i++)
            {
                if (Expenses[i].ExpenseDate < min)
                    min = Expenses[i].ExpenseDate;
                if (Expenses[i].ExpenseDate > max)
                    max = Expenses[i].ExpenseDate;
            }
            DateTime[] range = { min, max };
            return range;
        }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                bool result = true;
                Record r = (Record)obj;
                if ((Expenses.Count != r.Expenses.Count) || (RecordName != r.RecordName))
                    return false;
                else
                    for (int i = 0; i < Expenses.Count; i++)
                        result = result && Expenses[i].Equals(r.Expenses[i]);
                    return result;
            }
        }

        public override int GetHashCode()
        {
            int hc = RecordName.GetHashCode();
            for (int i = 0; i < Expenses.Count; i++)
                hc += Expenses[i].GetHashCode();
            return hc;
        }

        public override string ToString()
        {
            string s = RecordName + "\n";
            for (int i = 0; i < Expenses.Count; i++)
                s += Expenses[i].ToString() + "\n";
            return s;
        }
    }
}
