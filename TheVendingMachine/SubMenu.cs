using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.IO;


namespace TheVendingMachine
{
    public class SubMenu
    {
        public VendingMachine vm;

        public SubMenu(VendingMachine vm)
        {
            this.vm = vm;
        }

        public void Show()
        {
          while (true)
          {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Välj ett alternativ");
            Console.WriteLine();
            Console.WriteLine("1) Sätt in pengar");
            Console.WriteLine("2) Välj en produkt");
            Console.WriteLine("3) Avsluta köpet");
            Console.WriteLine("s) Tillbaka till huvudmenyn");
            Console.WriteLine($"Money in Machine: {this.vm.MoneyHandler.MoneyInserted.ToString("C")}");
            Console.WriteLine("Gör ett val!");
            string input = Console.ReadLine();

            if (input == "1")
                {
                    vm.InsertMoney();
               
                }
                else if (input == "2")
                {
                    while (true)
                    {
                        this.vm.ShowAll();
                        Console.Write(">>> Vad vill du köpa? ");
                        string choice = Console.ReadLine();

                        if (this.vm.ArticleExists(choice) && vm.Purchase(choice))
                        {
                            Console.WriteLine($"Njut av {vm.VendingMachineArticles[choice].ArticleName}\n{this.vm.VendingMachineArticles[choice].BuyerMessage}");
                            break;
                        }
                        else if (!this.vm.ArticleExists(choice))
                        {
                            Console.Clear();
                            Console.WriteLine("**FELAKTIG ARTIKEL**");
                        }
                      
                        else if (this.vm.MoneyHandler.MoneyInserted < vm.VendingMachineArticles[choice].Price)
                        {
                            Console.WriteLine(this.vm.NotEnoughMoneyError);
                            break;
                        }
                    }
                }
            else if(input == "3")
                {
                    vm.EndTransaction();
                }
            else if(input == "s")
                {
                    Console.WriteLine("Avslutar...");
                    break;
                }
            else
                {
                    Console.WriteLine("Prova igen!");

                }

                Console.ReadLine();

          }
        }

    }
}
