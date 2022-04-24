using System;
using System.Collections.Generic;
using System.Text;

namespace TheVendingMachine
{
    public class Book : VendingArticle
    {
        public const string Message = "Jävla bra bok det här!";

        public Book(string articleName, int price)
             : base(articleName, price, Message)

        {
        }
    }
}
