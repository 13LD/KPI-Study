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
            Random n = new Random();
            Random i = new Random();
            Random k = new Random();
            Random j = new Random();
            Random Rtxt = new Random();
            Random Rp = new Random();
            Random _Rp = new Random();
            string name, point, _point;

            for (int ctr = 1; ctr <= 20; ctr++)
            {
                if (Rtxt.Next(1, 3) == 1)
                    name = "Russian";
                else if (Rtxt.Next(1, 3) == 2)
                    name = "Chedr";
                else
                    name = "Parmezzan";

                if (Rp.Next(1, 3) == 1)
                    point = "Well";
                else
                    point = "Spoiled";

                if (_Rp.Next(1, 3) == 1)
                    _point = "Good";
                else
                    _point = "Bad";

                Console.ForegroundColor = ConsoleColor.Cyan;
                Cheese b = new Cheese(name, i.Next(100, 200), k.Next(230, 400), j.Next(400, 4000));
                CheeseCreator c = new CheeseCreator(point, _point, n.Next(1, 6));

                //event
                Handler Handler1 = new Handler();
                c.MarkAnswer += Handler1.Message;
                c.PrintPoint();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Personal view of 1 customer : {0} point", c.getView());
                Console.ForegroundColor = ConsoleColor.Red;
                b.Print();
            }
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

