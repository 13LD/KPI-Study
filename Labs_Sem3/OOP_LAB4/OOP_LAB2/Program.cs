using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dispose
            Cheese a = new Cheese("test", 1, 2, 3);
            a.Dispose();
            Cheese[] cheese = new Cheese[2];
            for (int ctr = 0; ctr < 2; ctr++)
            {
                cheese[ctr] = new Cheese("Cheese" + (ctr + 1).ToString(), 1000,ctr + 200, ctr + 333);
            }

            //Serialization
            CheeseShop<Cheese> chsh = new CheeseShop<Cheese>();
            chsh.AddNewCheese(cheese[0]);
            chsh.AddNewCheese(cheese[1]);


            CheeseShop<Cheese> chsh2 = new CheeseShop<Cheese>();
            chsh2.AddNewCheese(cheese[1]);
            chsh2.AddNewCheese(cheese[0]);

            foreach (Cheese chc in chsh2)
                chc.Print();

            Cheese.Serialize("cheese.dat", chsh2);
            CheeseShop<Cheese> chsh3 = (CheeseShop<Cheese>)Cheese.Deserialize("cheese.dat");
            Console.WriteLine("Name: {0}, Count : {1}", chsh3.Name, chsh3.Count);

            Console.WriteLine(chsh2.CompareTo(chsh));

            foreach (Cheese CH in chsh)
                CH.Print();
            
            
            //GC test
            Console.WriteLine("GC test");
            Cheese cheesee = cheese[0];
            cheesee.testGC();


            Console.WriteLine("Test for Exceptions");
            //exception
            try
            {
                SourCream d = new SourCream("", 4, 3, 4);
                d.Print();
            }
            catch (MyException e)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
         }
    }
}

