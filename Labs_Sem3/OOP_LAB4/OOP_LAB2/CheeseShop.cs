using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB2
{
    [Serializable]
    class CheeseShop<T> : IEnumerable, IComparable
    {
        private List<T> chShop;

        public string Name { get; set; }

        public CheeseShop() : this("My Cheese Shop") {
        }

        public CheeseShop(string name)
        {
            Name = name;
            chShop = new List<T>();
        }

        public int Count
        {
            get
            {
                return chShop.Count;
            }
        }

        public T this[int i]
        {
            get
            {
                try
                {
                    return chShop[i];
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0}", e.Message);
                    throw e;
                }
            }

            set
            {
                try
                {
                    chShop[i] = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0}", e.Message);
                    throw e;
                }
            }
        }

        public void AddNewCheese(T product)
        {
            chShop.Add(product);
        }

        public bool RemoveCheese(T product)
        {
            if (chShop.Contains(product))
            {
                chShop.Remove(product);
                return true;
            }
            else
                return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return chShop.GetEnumerator();
        }

        public int CompareTo(object obj)
        {
            CheeseShop<T> another = obj as CheeseShop<T>;
            if (another == null)
                throw new Exception("Not comparable objects");
            if (Count < another.Count) return -1;
            if (Count > another.Count) return 1;

            return 0;
        }
    }
}

