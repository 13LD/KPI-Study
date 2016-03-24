using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB2
{
    abstract class Goods
    {
        protected string name;
        protected static int count;

        protected static int currPrice = 0;
        
        
        public virtual int Price { get; set; }
        public virtual int shelfLife { get; set; }
        public virtual int Weight { get; set; }
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
        public Goods(string name)
        {
            Name = name;
        }
        static Goods() { }        

        public static void WriteMsg(string m, int n)
        {
            Console.Write(m + " " + n +"% \n"); 
        }
        public int Count
        {
            get
            {
                return count;
            }
                
        }
        public Goods(){ }
        public abstract void Print();
    }
}
