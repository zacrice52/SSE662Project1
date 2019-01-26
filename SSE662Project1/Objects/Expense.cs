using System;

namespace SSE662Project1.Objects
{
    public class Expense
    {
        public Expense(string datestring, string pricestring, string vendorstring)
        {
            if (datestring != null)
                ExpenseDate = DateTime.Parse(datestring);
            else
                ExpenseDate = DateTime.Parse("12/25/0001");

            if (pricestring != null)
                ExpensePrice = -Convert.ToDouble(pricestring);
            else
                ExpensePrice = 0.0;
            
            ExpenseVendor = vendorstring;
            privatevendor = vendorstring;

            ExpenseCategory = new Category(vendorstring);
        }

        public DateTime ExpenseDate { get; set; }
        public double ExpensePrice { get; set; }
        private string privatevendor;
        public string ExpenseVendor
        {
            get
            {
                return privatevendor;
            }
            set
            {
                privatevendor = value;
                ExpenseCategory = new Category(value);
            }
        }
        public Category ExpenseCategory;

        /*public string GetCategory()
        {
            return ExpenseCategory.categoryID;
        }*/

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Expense e = (Expense)obj;
                return (ExpenseDate == e.ExpenseDate)&&(ExpensePrice == e.ExpensePrice)&&(string.Equals(ExpenseVendor,e.ExpenseVendor));
            }
        }

        public override int GetHashCode()
        {
            if(ExpenseVendor != null)
                return ExpenseVendor.GetHashCode()+Convert.ToInt32(ExpensePrice)+ ExpenseDate.ToString().GetHashCode();
            else
                return Convert.ToInt32(ExpensePrice) + ExpenseDate.ToString().GetHashCode();
        }

        public override string ToString()
        {
            return ExpenseDate + "\t" + ExpensePrice + "\t" + ExpenseVendor + "\t\t" + ExpenseCategory.categoryID;
        }
    }   
}
