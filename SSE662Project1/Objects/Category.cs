﻿using System.Collections.Generic;
using System;

namespace SSE662Project1.Objects
{
    public class Category
    {
        private static List<List<string>> CategoryKeywords = new List<List<string>>
                { new List<string> { "kayak", "flight" },                                               /* Vacation Keywords   */
                  new List<string> { "amc", "coffee", "groupon", "ski" },                               /* Recreation Keywords */
                  new List<string> { "vons", "ralphs", "trader joe's", "costco", "wal-mart", "pizza" }, /* Groceries Keywords  */
                  new List<string> { "cvs", "walgreen" },                                               /* Medical Keywords    */
                  new List<string> { "smiles", "dent" },                                                /* Dental Keywords     */
                  new List<string> { "edison", "electric" },                                            /* Utilities Keywords  */
                  new List<string> { "target","amzn","amazon" },                                        /* Allowance Keywords  */
                  new List<string> { "firestone", "gas", "exxon"},                                      /* Car Keywords        */
                  new List<string> { "pet", "vet" },                                                    /* Pet Keywords        */
                  new List<string> { "rent", "check" }                                                  /* Rent Keywords       */  };

        public string[] Categories { get; } = { "Vacation", "Recreation", "Groceries", "Medical", "Dental", "Utilities", "Allowance", "Car", "Pet", "Rent", "Other" };

        public string categoryID { get; } // ID is permanent once set; cannot be changed
        
        public Category(string vendor)
        {
            int id = Categories.Length - 1; // Default category is "other"

            if (vendor == null)
                goto found;
            for (int i = 0; i<CategoryKeywords.Count; i++)
                for(int j = 0; j<CategoryKeywords[i].Count; j++)
                {
                    // Once a keyword is found, the loop breaks and the ID is assigned
                    if (vendor.ToLower().Contains(CategoryKeywords[i][j]))
                    {
                        id = i;
                        goto found;
                    }
                }
            found:
            categoryID = Categories[id];
        }

        

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else //As long as the IDs are equal, the objects are equal
            {
                Category c = (Category)obj;
                return string.Equals(categoryID, c.categoryID);
            }
        }

        public override int GetHashCode()
        {
            return categoryID.GetHashCode(); //Equal IDs return the same hash code
        }
    }
}