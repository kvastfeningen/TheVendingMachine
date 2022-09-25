using System;
using System.Collections.Generic;
using TheVendingMachine;
using Xunit;


namespace TheVendingMachineTests
{
    public class InputTest1
    {
        

        
[Fact]
public void Test_Article_Count()
{

VendingMachine vm = new VendingMachine();


            int result = vm.VendingMachineArticles.Count;
            
            Assert.Equal(expected: 9, result);
}

        /*
                [Fact]
                public void testVMShowAll()
                {
                    //string name = "test";
                    //User user = new User(name);
                    VendingMachine vm = new VendingMachine();
                    Dictionary<string, VendingArticle> articles = new Dictionary<string, VendingArticle>();
                    //VendingMachineArticles[articleNumber]
                   List<VendingArticles> articles = vm.VendingMachineArticles[0, 1, 2];
                    Assert.Equal("Fixa, Xtra long", articleName);
                    Assert.Equal("Bambi, Xtra soft", articles[1].articleName);
                    Assert.Equal("No Name Paper", articles[2].articleName);
                }
        */
        
                //[Theory]
              //  [InlineData("Fixa, Xtra long", "Fixa, Xtra long")]
               // [InlineData("Bambi, Xtra soft", "Bambi, Xtra soft")]
               // [InlineData("No Name Paper", "No Name Paper")]
                [Fact]
                public void TestsArticles()
                {
                    VendingMachine vm = new VendingMachine();
            List<Product> products = vm.ShowAll();
            Assert.Equal("Gucci T-shirt", products[0].Name);
            Assert.Equal("Gucci Pants", products[1].Name);
            Assert.Equal("Gucci Hat", products[2].Name);
            //var articles = vm.VendingMachineArticles;
            //articles.Add(new VendingArticle(a1 | Fixa, Xtra long | 7 | ToiletPaper));
            //HandleFiles.GetVendingArticles
            //var expected = "Fixa, Xtra long";
            bool expected = true;
            string articleNumber = "a1";
            var result = vm.VendingMachineArticles.ContainsKey(articleNumber);
            //var result = articles[0];

                    Assert.Equal(expected, result);
                }
        
        
        
        [Fact]
        public void TestIfArticlesImportProperly()
        {
            FileHandler HandleFiles = new FileHandler();
          
            VendingMachine vm = new VendingMachine();
            //string line = sr.ReadLine(0);
            // List<VendingArticle> products = vm.ShowAll();
            //List<VendingArticle> articles = vm.VendingMachineArticles;
            // VendingMachineArticles[articleNumber]
            //VendingArticle article = new ToiletPaper("Fixa, Xtra long", 7);
            var articleNumber = "a1";
            string expected = "Fixa, Xtra long";
            string a = vm.VendingMachineArticles[articleNumber];

            Assert.Equal(expected, a.articleName);
        }
        
        /*
        [Fact]
        public void GetList_ReturnsSameCount()
        {
            var products = new List<Product>();
            products.Add(new Product(1, "Tea", 1.30m, 10));
            products.Add(new Product(2, "Espresso", 1.80m, 20));
            products.Add(new Product(3, "Juice", 1.80m, 20));
            products.Add(new Product(4, "Chicken soup", 1.80m, 15));

            _productsService = GetService(products);
            IEnumerable<Product> list = _productsService.GetList();

            Assert.AreEqual(expected: products.Count, list.Count());
        }

        */

        [Fact]
        public void TestsIfNotEnoughMoneyEnteredToPurchaseArticle()
        {
            VendingMachine vm = new VendingMachine();
            
            string result = vm.NotEnoughMoneyError;
            Assert.Equal("För lite pengar!", result);
        }

        [Theory]
        [InlineData("0,5", 1)]
        [InlineData("4", 5)]
        [InlineData("19", 10)]
        [InlineData("300", 500)]
        [InlineData("9000", 1000)]
        public void TestsWrongCashInput(string input, int expected)
        {
            VendingMachine vm = new VendingMachine();
            vm.MoneyHandler.AddMoney(input);
            decimal result = vm.MoneyHandler.MoneyInserted;

            Assert.NotEqual(expected, result);
            
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("5", 5)]
        [InlineData("10", 10)]
        [InlineData("20", 20)]
        [InlineData("50", 50)]
        [InlineData("100", 100)]
        [InlineData("500", 500)]
        [InlineData("1000", 1000)]
        public void TestsCashInput(string input, int expected)
        {
            VendingMachine vm = new VendingMachine();
            vm.MoneyHandler.AddMoney(input);
            decimal result = vm.MoneyHandler.MoneyInserted;

            Assert.Equal((decimal)expected, result);
        }
    }
}
