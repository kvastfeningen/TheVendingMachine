using System;
using System.Collections.Generic;
using TheVendingMachine;
using Xunit;


namespace TheVendingMachineTests
{
    public class InputTest1
    {
        [Fact]
        public void TestIfArticlesImportProperly()
        {
            FileHandler HandleFiles = new FileHandler();

            Dictionary<string, VendingArticle> articles = HandleFiles.GetVendingArticles();
            VendingArticle article = new ToiletPaper("Fixa, Xtra long", 7);

            Assert.Equal(article, articles["a1"]);
        }


        [Fact]
        public void TestsIfNotEnoughMoneyEnteredToPurchaseArticle()
        {
            VendingMachine vm = new VendingMachine();
            vm.Purchase("A1");
            string result = vm.NotEnoughMoneyError;
            Assert.Equal("För lite pengar!", result);
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
