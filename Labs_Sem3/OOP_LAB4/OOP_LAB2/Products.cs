using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB2
{
    [Serializable]
    class Product : Goods
    {
        public int price;
        public override int Price
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
        public Product(string name, int price) : base(name)
        {
            this.Price = price;
            currPrice = price;
        }
        public Product() {
            
        }
        public override void Print()
        {
            Console.WriteLine("this Product has name - {0} price - {1}", this.Name, this.Price);
        }
    }
}
