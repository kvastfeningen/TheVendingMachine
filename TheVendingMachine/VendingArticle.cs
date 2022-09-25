using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections.ObjectModel;

namespace TheVendingMachine
{
    public abstract class VendingArticle
    {
        public string articleName { get; set; }

        public int Price { get; set; }

        public string BuyerMessage { get; set; }

        VendingArticle()
        {

        }

        public VendingArticle(string articleName, int price, string Message)
        {
            this.articleName = articleName;
            this.Price = price;
            this.BuyerMessage = Message;
        }

        public static implicit operator string(VendingArticle v)
        {
            throw new NotImplementedException();
        }
    }
}
