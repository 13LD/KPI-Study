using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace OOP_LAB2
{
    [Serializable]
    class Cheese : MilkProduct, ICloneable, IDisposable
    {
        public int weight;
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
        ~Cheese()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            count++;
            Console.WriteLine("{0}. Distructor", count);
        }
        static Cheese()
        {
            count = 0;
        }
        public Cheese() {
            
        }

        private void CurrPrice(double price)
        {
            Console.WriteLine((currPrice - currPrice * m * 0.01) + "$");
        }

        public static void Serialize(string file, object obj)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
                Console.WriteLine("Object serialized");
            }
        }

        public static Object Deserialize(string file)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            object newCheese;
            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
            {
                newCheese = formatter.Deserialize(fs);

                Console.WriteLine("Object deserialized");
            }

            return newCheese;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public void Dispose()
        {
            Console.WriteLine("{0} - In Dispose method!", this.Name);
            GC.SuppressFinalize(this);
        }
        public void testGC()
        {
            Object[] array = new Object[500000];

            for (int z = 0; z < 500000; z++)
                array[z] = new Object();
            WeakReference reference = new WeakReference(array);
            Console.WriteLine("Obj Is alive : " + reference.IsAlive.ToString());
            Console.WriteLine("{0}", GC.GetGeneration(array));
            array = null;


            GC.Collect(2, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();


            Console.WriteLine("Obj Is alive : " + reference.IsAlive.ToString());
        }

        public override void Print()
        {
            Console.WriteLine("Milkproduct - Cheese  Name - '{0}' Price '{1}$' Saving time -'{2}h' Weight -'{3}g' ", Name, Price, shelfLife, Weight);
            Console.ForegroundColor = ConsoleColor.Green;
            WriteMsg("discount ", m);
            Console.ForegroundColor = ConsoleColor.Cyan;
            //Console.Write("Current price is ");
            //CurrPrice(currPrice);
            Console.Write("\n\n");
        }

    }
}
