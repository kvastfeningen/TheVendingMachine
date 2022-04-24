using System;
using System.Collections.Generic;
using System.Text;

namespace TheVendingMachine
{
    public interface IVending
    {
        bool Purchase(string articleName);
        void ShowAll();
        void InsertMoney();
        void EndTransaction();
    }
}
