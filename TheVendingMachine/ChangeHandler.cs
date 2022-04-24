using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheVendingMachine
{
    public class ChangeHandler
    {
        public MoneyHandler MoneyHandler { get; }
        private decimal MoneyInserted;

        private int numThousands = 0;
        public int NumThousands
        {
            get { return this.numThousands; }
        }

        private int numFiveHundreds;
        public int NumFiveHundreds
        {
            get { return this.numFiveHundreds; }
        }

        private int numHundreds;
        public int NumHundreds
        {
            get { return this.numHundreds; }
        }

        private int numFifties;
        public int NumFifties
        {
            get { return this.numFifties; }
        }

        private int numTwenties;
        public int NumTwenties
        {
            get { return this.numTwenties; }
        }

        private int numTens;
        public int NumTens
        {
            get { return this.numTens; }
        }

        private int numFives;
        public int NumFives
        {
            get { return this.numFives; }
        }

        private int numCrowns;
        public int NumCrowns
        {
            get { return this.numCrowns; }
        }
        public ChangeHandler(decimal MoneyInserted)
        {
            this.MoneyInserted = MoneyInserted;
        }

        public List<int> MakeChange()
        {
            decimal temp2 = MoneyInserted;
            List<int> changeCount = new List<int>();
            Console.WriteLine("Your change is: " + MoneyInserted + " kr");
            while (MoneyInserted > 0)
            {

                int temp = (int)(MoneyInserted);
                numThousands = (int)temp / 1000;
                temp = temp % 1000;
                numFiveHundreds = (int)temp / 500;
                temp = temp % 500;
                numHundreds = (int)temp / 100;
                temp = temp % 100;
                numFifties = (int)temp / 50;
                temp = temp % 50;
                numTwenties = (int)temp / 20;
                temp = temp % 20;
                numTens = (int)temp / 10;
                temp = temp % 10;
                numFives = (int)temp / 5;
                temp = temp % 5;
                numCrowns = (int)temp / 1;
                temp = temp % 1;
                MoneyInserted = (int)temp;

                if (temp > 0)
                {
                    Console.WriteLine("ChangeHandler is broken");
                    break;
                }
                
            }
            this.MoneyInserted = 0;
            changeCount.AddRange(new List<int> { numThousands, numFiveHundreds, numHundreds,
            NumFifties, numTwenties, numTens, numFives, numCrowns});
            Console.WriteLine("Betalar ut...");
            Console.WriteLine(numThousands + " Tusingar");
            Console.WriteLine(numFiveHundreds + " Femhundringar");
            Console.WriteLine(numHundreds + " Hundringar");
            Console.WriteLine(NumFifties + " Femtior");
            Console.WriteLine(numTwenties + " Tjugor");
            Console.WriteLine(numTens + " Tior");
            Console.WriteLine(numFives + " Femmor");
            Console.WriteLine(numCrowns + " Kronor");
            
            return changeCount;


        }

    }
}
