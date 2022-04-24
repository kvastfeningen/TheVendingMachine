using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections.ObjectModel;

namespace TheVendingMachine
{
    public abstract class VendingArticle
    {
        public string ArticleName { get; set; }

        public int Price { get; set; }

        public string BuyerMessage { get; set; }

        VendingArticle()
        {

        }

        public VendingArticle(string articleName, int price, string Message)
        {
            this.ArticleName = articleName;
            this.Price = price;
            this.BuyerMessage = Message;
        }

    }
}
