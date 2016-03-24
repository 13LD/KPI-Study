using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB2
{
    class MilkProduct : Product
    {
        int sTime;
        public override int shelfLife
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
        public MilkProduct(string name, int price, int shelflife) : base(name, price)
        {
            this.shelfLife = shelflife;
        }
        public MilkProduct(){
        }
        public override void Print()
        {
            Console.WriteLine("This Milkproduct has name - {0} price - {1} saving time - {2}", this.Name, this.Price, this.shelfLife);
        }
    }
}
