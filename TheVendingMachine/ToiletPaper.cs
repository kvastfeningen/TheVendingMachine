using System;
using System.Collections.Generic;
using System.Text;

namespace TheVendingMachine
{
    public class ToiletPaper : VendingArticle
    {
        public const string Message = "Bra papper, Chief?!";

        public ToiletPaper(string articleName, int price)
             : base(articleName, price, Message)

        {
        }
    }
}
