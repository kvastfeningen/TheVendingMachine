using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections.ObjectModel;
using TheVendingMachine;
using Xunit;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace TheVendingMachineTests
{
    public class InputTest1
    {

        [Fact]
        public void Test_Article_Count()
        {
            string file = string.Empty;
           
            
            file = "C:\\Users\\Elev\\Source\\Repos\\TheVendingMachine\\bin\\Debug\\netcoreapp3.1\\ArticleFile.csv";
                var lineCounter = 0L;
                using (var reader = new StreamReader(file))

                    while (reader.ReadLine() != null)
                    {
                        lineCounter++;
                    }
            

            Assert.Equal(expected: 9, lineCounter);
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


        [Fact]
        public void TestIfArticlesImportProperly()
        {
            string file = "C:\\Users\\Elev\\Source\\Repos\\TheVendingMachine\\bin\\Debug\\netcoreapp3.1\\ArticleFile.csv";

            string art = string.Empty;

            using (var sr = new StreamReader(file))
                    if (File.Exists(file))
                    {
                        string[] lines = File.ReadAllLines(file);
                        art = lines[0];
                    }

            Assert.Equal(expected: "a1|Fixa, Xtra long|7|ToiletPaper", art);
            
        }

     }
}
