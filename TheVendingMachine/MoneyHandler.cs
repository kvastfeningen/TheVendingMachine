using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.IO;

namespace TheVendingMachine
{
    public class MoneyHandler
    {
       
        
        private Logger log;

            public MoneyHandler(Logger log)
            {
                this.MoneyInserted = 0M;
                this.log = log;
            }
       
            public decimal MoneyInserted { get; private set; }

        
        public bool AddMoney(string amount)
        { 
            if (!decimal.TryParse(amount, out decimal amountInserted))
            {
                amountInserted = 0M;
                return false;
            }
           
            string message = $"Sätt in pengar: ";

            decimal before = this.MoneyInserted;

            this.MoneyInserted += amountInserted;
            
           decimal after = this.MoneyInserted;

            return true;
        }

        public bool RemoveMoney(decimal amountToRemove)
        {
            if (this.MoneyInserted <= 0)
            {
                return false;
            }

            this.MoneyInserted -= amountToRemove;
            return true;
        }

       

    }
}
