using System;
using Xunit;
using SSE662Project1.Objects;

namespace SSE662Project1Test
{
    public class CategoryTest
    {
        private const string vendorstring = "EXAMPLE VENDOR AMC";
        private Category testcategory = new Category(vendorstring);
        
        private const string vendorstring2 = "EXAMPLE VENDOR2 FLIGHT";
        private Category testcategory2= new Category(vendorstring2);

        [Fact]
        public void CreateCategoryTest()
        {
            var category0 = new Category(null);
            Assert.NotEqual(testcategory.categoryID, category0.categoryID);
            Assert.NotEqual(testcategory.GetHashCode(), category0.GetHashCode());
            Assert.False(testcategory.Equals(category0));
            var category = new Category(vendorstring);
            Assert.Equal(testcategory.categoryID, category.categoryID);
            Assert.Equal(testcategory.GetHashCode(), category.GetHashCode());
            Assert.True(testcategory.Equals(category));
        }

        [Fact]
        public void CategoryEqualsTest()
        {
            var category0 = new Category(null);
            Assert.False(testcategory.Equals(category0));
            var category = new Category("ski");
            Assert.True(testcategory.Equals(category));
        }

        [Fact]
        public void CategoryHashCodeTest()
        {
            var category0 = new Category(null);
            Assert.NotEqual(testcategory.GetHashCode(), category0.GetHashCode());
            var category = new Category("ski");
            Assert.Equal(testcategory.GetHashCode(), category.GetHashCode());
        }
    }
}
