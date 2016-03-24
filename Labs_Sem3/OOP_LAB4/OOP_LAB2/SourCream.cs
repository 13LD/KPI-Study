using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB2
{

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
        public SourCream(string name, int price, int sTime, int weight)
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
