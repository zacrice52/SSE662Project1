
using Xunit;
using SSE662Project1.Objects;

namespace SSE662Project1Test
{
    public class CategoryTest
    {
        private const string vendorstring1 = "EXAMPLE VENDOR KAYAK";
        private Category testcategory1 = new Category(vendorstring1);
        private const string expectedcategory1 = "Vacation";
        private const string vendorstring1alt = "EXAMPLE VENDOR FLIGHT";

        private const string vendorstring2 = "EXAMPLE VENDOR AMC";
        private Category testcategory2 = new Category(vendorstring2);
        private const string expectedcategory2 = "Recreation";

        private const string vendorstring3 = "EXAMPLE VENDOR VONS";
        private Category testcategory3 = new Category(vendorstring3);
        private const string expectedcategory3 = "Groceries";

        private const string vendorstring4 = "EXAMPLE VENDOR CVS";
        private Category testcategory4 = new Category(vendorstring4);
        private const string expectedcategory4 = "Medical";

        private const string vendorstring5 = "EXAMPLE VENDOR DENTAL";
        private Category testcategory5 = new Category(vendorstring5);
        private const string expectedcategory5 = "Dental";

        private const string vendorstring6 = "EXAMPLE VENDOR EDISON";
        private Category testcategory6 = new Category(vendorstring6);
        private const string expectedcategory6 = "Utilities";

        private const string vendorstring7 = "EXAMPLE VENDOR TARGET";
        private Category testcategory7 = new Category(vendorstring7);
        private const string expectedcategory7 = "Allowance";

        private const string vendorstring8 = "EXAMPLE VENDOR GAS";
        private Category testcategory8 = new Category(vendorstring8);
        private const string expectedcategory8 = "Car";

        private const string vendorstring9 = "EXAMPLE VENDOR VETERANARIAN";
        private Category testcategory9 = new Category(vendorstring9);
        private const string expectedcategory9 = "Pet";

        private const string vendorstring10 = "EXAMPLE VENDOR RENT";
        private Category testcategory10 = new Category(vendorstring10);
        private const string expectedcategory10 = "Rent";

        private const string vendorstring11 = "EXAMPLE VENDOR";
        private Category testcategory11 = new Category(vendorstring11);
        private const string expectedcategory11 = "Other";


        [Fact]
        public void CategoryEqualsTest()
        {
            // Should be able to handle the null case, verifies the not equal case
            var category0 = new Category(null);
            Assert.False(testcategory1.Equals(category0));

            // Now that the categories are the same (i.e. both "Recreation"), they should be equal
            var category = new Category(vendorstring1alt);
            Assert.True(testcategory1.Equals(category));
        }

        [Fact]
        public void CategoryHashCodeTest()
        {
            // Should be able to handle the null case, verifies the not equal case
            var category0 = new Category(null);
            Assert.NotEqual(testcategory1.GetHashCode(), category0.GetHashCode());

            // Now that the categories are the same (i.e. both "Vacation"), they should be equal
            var category = new Category(vendorstring1alt);
            Assert.Equal(testcategory1.GetHashCode(), category.GetHashCode());
        }

        [Fact]
        public void CreateCategoryTest()
        {
            // Should be able to handle the null case, should be categorized as "Other"; tests the not equal case
            var category0 = new Category(null);
            Assert.NotEqual(testcategory1.categoryID, category0.categoryID);
            Assert.NotEqual(expectedcategory1, category0.categoryID);
            Assert.NotEqual(testcategory1.GetHashCode(), category0.GetHashCode());
            Assert.False(testcategory1.Equals(category0));

            // Example case to be categorized based on vendor information as "Vacation"
            var category1 = new Category(vendorstring1);
            Assert.Equal(testcategory1.categoryID, category1.categoryID);
            Assert.Equal(expectedcategory1, category1.categoryID);
            Assert.Equal(testcategory1.GetHashCode(), category1.GetHashCode());
            Assert.True(testcategory1.Equals(category1));

            // Example case to be categorized based on vendor information as "Recreation"
            var category2 = new Category(vendorstring2);
            Assert.Equal(testcategory2.categoryID, category2.categoryID);
            Assert.Equal(expectedcategory2, category2.categoryID);
            Assert.Equal(testcategory2.GetHashCode(), category2.GetHashCode());
            Assert.True(testcategory2.Equals(category2));

            // Example case to be categorized based on vendor information as "Groceries"
            var category3 = new Category(vendorstring3);
            Assert.Equal(testcategory3.categoryID, category3.categoryID);
            Assert.Equal(expectedcategory3, category3.categoryID);
            Assert.Equal(testcategory3.GetHashCode(), category3.GetHashCode());
            Assert.True(testcategory3.Equals(category3));

            // Example case to be categorized based on vendor information as "Medical"
            var category4 = new Category(vendorstring4);
            Assert.Equal(testcategory4.categoryID, category4.categoryID);
            Assert.Equal(expectedcategory4, category4.categoryID);
            Assert.Equal(testcategory4.GetHashCode(), category4.GetHashCode());
            Assert.True(testcategory4.Equals(category4));

            // Example case to be categorized based on vendor information as "Dental"
            var category5 = new Category(vendorstring5);
            Assert.Equal(testcategory5.categoryID, category5.categoryID);
            Assert.Equal(expectedcategory5, category5.categoryID);
            Assert.Equal(testcategory5.GetHashCode(), category5.GetHashCode());
            Assert.True(testcategory5.Equals(category5));

            // Example case to be categorized based on vendor information as "Utilities"
            var category6 = new Category(vendorstring6);
            Assert.Equal(testcategory6.categoryID, category6.categoryID);
            Assert.Equal(expectedcategory6, category6.categoryID);
            Assert.Equal(testcategory6.GetHashCode(), category6.GetHashCode());
            Assert.True(testcategory6.Equals(category6));

            // Example case to be categorized based on vendor information as "Allowance"
            var category7 = new Category(vendorstring7);
            Assert.Equal(testcategory7.categoryID, category7.categoryID);
            Assert.Equal(expectedcategory7, category7.categoryID);
            Assert.Equal(testcategory7.GetHashCode(), category7.GetHashCode());
            Assert.True(testcategory7.Equals(category7));

            // Example case to be categorized based on vendor information as "Car"
            var category8 = new Category(vendorstring8);
            Assert.Equal(testcategory8.categoryID, category8.categoryID);
            Assert.Equal(expectedcategory8, category8.categoryID);
            Assert.Equal(testcategory8.GetHashCode(), category8.GetHashCode());
            Assert.True(testcategory8.Equals(category8));

            // Example case to be categorized based on vendor information as "Pet"
            var category9 = new Category(vendorstring9);
            Assert.Equal(testcategory9.categoryID, category9.categoryID);
            Assert.Equal(expectedcategory9, category9.categoryID);
            Assert.Equal(testcategory9.GetHashCode(), category9.GetHashCode());
            Assert.True(testcategory9.Equals(category9));

            // Example case to be categorized based on vendor information as "Rent"
            var category10 = new Category(vendorstring10);
            Assert.Equal(testcategory10.categoryID, category10.categoryID);
            Assert.Equal(expectedcategory10, category10.categoryID);
            Assert.Equal(testcategory10.GetHashCode(), category10.GetHashCode());
            Assert.True(testcategory10.Equals(category10));

            // Example case to be categorized based on vendor information as "Other"
            var category11 = new Category(vendorstring11);
            Assert.Equal(testcategory11.categoryID, category11.categoryID);
            Assert.Equal(expectedcategory11, category11.categoryID);
            Assert.Equal(testcategory11.GetHashCode(), category11.GetHashCode());
            Assert.True(testcategory11.Equals(category11));
        }

        
    }
}
