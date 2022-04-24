using System;
using System.Collections.Generic;
using System.Text;

namespace TheVendingMachine
{
    public class Menu
    {
        public void Show()
        {
            VendingMachine vm = new VendingMachine();

            Console.WriteLine(" Välkommen till en speciell varuautomat!");
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Huvudmeny");
                Console.WriteLine("1] Visa artiklar");
                Console.WriteLine("2] Köp");
                Console.WriteLine("s] Avsluta");

                Console.Write("Vad väljer du att göra? ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine("Laddar artiklar");
                    vm.ShowAll();
                }
                else if (input == "2")
                {
                    SubMenu subMenu = new SubMenu(vm);
                    subMenu.Show();
                }
                else if (input == "s")
                {
                    Console.WriteLine("Quitting");
                    break;
                }
                else
                {
                    Console.WriteLine("Please try again");
                }

                Console.ReadLine();
                Console.Clear();
            }
        }


    }
}
