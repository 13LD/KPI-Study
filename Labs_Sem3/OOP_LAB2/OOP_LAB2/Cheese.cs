using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB2
{
    class Cheese : MilkProduct
    {
        int weight;
        int m = 0;
        public override int Weight
        {
            get
            {   
                return weight;
            }

            set
            {
                if (weight > -1)
                    weight = value;
            }
        }
        public Cheese(string name, int price, int sTime, int weight) : base(name, price, sTime)
        {        
            this.Weight = weight;
            if (weight > 3000)
                m += 20;

            else if (weight > 500)
                m += 10;

            if (price > 300)
                m += 5;

             else if (price > 100)
                m += 3;
            
        }
        static Cheese()
        {
            count = 0;
        }
        public Cheese() {
            count++;
        }

        private void CurrPrice(double price)
        {
            Console.WriteLine((currPrice - currPrice * m * 0.01) + "$");
        }


        public override void Print()
        {
            Console.WriteLine("Milkproduct - Cheese  Name - '{0}' Price '{1}$' Saving time -'{2}h' Weight -'{3}g' ", Name, Price, shelfLife, Weight);
            Console.ForegroundColor = ConsoleColor.Green;
            WriteMsg("discount ", m);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Current price is ");
            CurrPrice(currPrice);
            Console.Write("\n\n");
        }

    }




    class SourCream 
    {
        int weight, sTime, price;
        string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }

        public int Weight
        {
            get
            {
                return weight;
            }

            set
            {
                if (weight > -1)
                    weight = value;
            }
        }
        public int shelfLife
        {
            get
            {
                return sTime;
            }

            set
            {
                sTime = value;
            }
        }
        public SourCream()
        {

        }
        public SourCream (string name, int price, int sTime, int weight)
        {
            if (name == "")
                throw new MyException(new EArgs("ERROR: Empty name of SourCream", new Exception("Empty name of Sourcream")));
            if (price <= 0)
                throw new MyException(new EArgs("ERROR: Impossible price of SourCream", new Exception("Impossible price of Sourcream")));
            Name = name;
            Price = price;
            sTime = shelfLife;
            Weight = weight;
        }
        public void Print()
        {
            Console.WriteLine("Milkproduct - SourCream '{0}' Price '{1}$' Saving time -'{2}h' Weight -'{3}g' \n", this.Name, this.Price, this.shelfLife, this.Weight);
        }

    }
}
