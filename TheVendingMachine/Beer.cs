using System;
using System.Collections.Generic;
using System.Text;

namespace TheVendingMachine
{
    public class Beer : VendingArticle
    {
        public const string Message = "Beer is good, beer is good, beer is good";

        public Beer (string articleName, int price)
             : base (articleName, price, Message)
                   
            {
            }
    }
}
