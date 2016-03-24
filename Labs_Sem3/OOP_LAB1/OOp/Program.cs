using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOp
{
    class MainClass
    {
        static FileReader r;
        public static void calculate()
        {
            Logger.WriteMsg("Calculations started");
            Vector MainRes = new Vector(0);
            MainRes = ((r.A * r.B - r.C) * (r.X + 4d * r.Y));
            Console.Write("(AB - C)(X + 4Y) = ");
            MainRes.Show();
            Console.WriteLine();
            Console.WriteLine("Norm Euqlid = " + MainRes.Euqlid().ToString());
            Console.WriteLine("Norm Sum = " + MainRes.NormS().ToString());
            Console.WriteLine("Norm MaxAbs = " + MainRes.NormM().ToString());
            Logger.WriteMsg("Calculations finished");
        }
        public static void Main(string[] args)
        {
            Logger.Init();
            try
            {
                r = new FileReader();
                Console.Write("X = ");
                r.X.Show();
                Console.WriteLine();

                Console.Write("Y = ");
                r.Y.Show();
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("A = ");
                r.A.Show();
                Console.WriteLine();

                Console.WriteLine("B = ");
                r.B.Show();
                Console.WriteLine();

                Console.WriteLine("C = ");
                r.C.Show();

                MainClass.calculate();

                Logger.Final();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught in main program");
                Console.Write(e);
                Console.ReadKey();
                Logger.Final();
                System.Environment.Exit(-1);
            }

            Console.ReadKey();

        }
    }

}
