using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections.ObjectModel;

namespace TheVendingMachine
{
    public class VendingMachine : IVending
    {
        private Logger Log = new Logger();
        public Dictionary<string, VendingArticle> VendingMachineArticles = new Dictionary<string, VendingArticle>();
        FileHandler HandleFiles = new FileHandler();
       
        public ChangeHandler ch;
       public MoneyHandler MoneyHandler { get; }
        public string NotEnoughMoneyError = "För lite pengar!";
        public string MessageToUser;
        public readonly object FileHandler;

        public VendingMachine()
        {
            VendingMachineArticles = HandleFiles.GetVendingArticles();
            MoneyHandler = new MoneyHandler(Log);
            
        }

       
        public decimal MoneyInserted
        {
            get
            {
                return this.MoneyHandler.MoneyInserted;
            }
        }

        public void InsertMoney()
        {
             decimal[] okAmounts = new decimal[8] { 1, 5, 10, 20, 50, 100, 500, 1000 };
             ReadOnlyCollection<decimal> readOnlyOkAmounts = Array.AsReadOnly(okAmounts);


            Console.WriteLine("Hur mycket pengar vill du sätta in?");

            while (true)
            {
                foreach (int element in okAmounts)
                {
                    Console.Write($"{element}  ");
                }
                Console.Write("?");
                
                string moneyInput = Console.ReadLine();
                if (moneyInput == "1"
                    || moneyInput == "5"
                    || moneyInput == "10"
                    || moneyInput == "20"
                    || moneyInput == "50"
                    || moneyInput == "100"
                    || moneyInput == "500"
                    || moneyInput == "1000")
                {

                    if (!this.MoneyHandler.AddMoney(moneyInput))
                    {
                        Console.WriteLine("Insert a valid amount.");
                    }
                    else
                    {
                        Console.WriteLine($"Pengar i Maskinen: {this.MoneyHandler.MoneyInserted.ToString("C")}");
                        break;
                    }



                }
            }


        }

        public bool ArticleExists(string articleNumber)
        {
            return this.VendingMachineArticles.ContainsKey(articleNumber);
        }

        public bool Purchase(string articleNumber)
        {
        

            if (this.ArticleExists(articleNumber)
                && this.MoneyHandler.MoneyInserted >= this.VendingMachineArticles[articleNumber].Price)
            
            {
                
                string message = $"{this.VendingMachineArticles[articleNumber].articleName.ToUpper()} {articleNumber}";

                
                decimal before = this.MoneyHandler.MoneyInserted;

               
                this.MoneyHandler.RemoveMoney(this.VendingMachineArticles[articleNumber].Price);

                
                decimal after = this.MoneyHandler.MoneyInserted;

                // Log the log
                 this.Log.Log(message, before, after);

                return true;
            }
            else
            {
                return false;
            }
        }

        public void ShowAll()
        {
           
            Console.WriteLine($"\n\n{"#".PadRight(5)} { "Artikel".PadRight(37) } { "Pris".PadLeft(7)}");
            foreach (KeyValuePair<string, VendingArticle> kvp in VendingMachineArticles)
            {

                string articleNumber = kvp.Key.PadRight(5);
                string productName = kvp.Value.articleName.PadRight(40);
                string price = kvp.Value.Price.ToString("C").PadLeft(7);
                Console.WriteLine($"{articleNumber} {productName} {price}");
            }

        }

        public void EndTransaction()
        {
            Console.WriteLine("Finishing Transaction");

            ChangeHandler c = new ChangeHandler(this.MoneyInserted);
            c.MakeChange();
            
            this.MoneyHandler.RemoveMoney(this.MoneyInserted);
            Console.WriteLine($"Pengar i Maskinen: {this.MoneyInserted.ToString("C")}");

        }
 
    }
}
