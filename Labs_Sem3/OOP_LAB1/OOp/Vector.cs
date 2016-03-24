using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOp
{
    public class Vector
    {
        public double[] coordinates;

        public Vector(params double[] crd)
        {
            coordinates = new double[crd.GetLength(0)];

            for (int i = 0; i < crd.GetLength(0); i++)
            {
                coordinates[i] = crd[i];
            }
        }

        public Vector(Vector prev)
        {
            coordinates = new double[prev.coordinates.GetLength(0)];

            for (int i = 0; i < coordinates.GetLength(0); i++)
            {
                coordinates[i] = prev.coordinates[i];
            }
        }

        public double Euqlid()
        {
            double result = 0;
            for (int i = 0; i < coordinates.GetLength(0); i++)
            {
                result += coordinates[i] * coordinates[i];
            }

            result = Math.Sqrt(result);

            return result;
        }
        public double NormS()
        {
            double result = 0;
            for (int i = 0; i < coordinates.GetLength(0); i++)
            {
                result += Math.Abs(coordinates[i]);
            }
            return result;
        }
        public double NormM()
        {
            double result = 0;
            for (int i = 0; i < coordinates.GetLength(0); i++)
            {
                if (result < coordinates[i])
                    result = coordinates[i];
            }
            return result;
        }

        public void Show()
        {
            for (int i = 0; i < coordinates.GetLength(0); i++)
                Console.Write(coordinates[i] + " ");
        }

        public static Vector operator *(Vector vec, double val)
        {
            Vector vect = new Vector(vec);

            for (int i = 0; i < vect.coordinates.GetLength(0); i++)
            {
                vect.coordinates[i] *= val;
            }
            Logger.WriteMsg("Oper * suc");
            return vect;
        }
        public static Vector operator *(double val, Vector vec)
        {
            Vector vect = new Vector(vec);

            for (int i = 0; i < vect.coordinates.GetLength(0); i++)
            {
                vect.coordinates[i] *= val;
            }
            Logger.WriteMsg("Oper * suc");
            return vect;
        }
        public static double operator *(Vector left, Vector right)
        {
            double result = 0;
            if (left.coordinates.GetLength(0) != right.coordinates.GetLength(0))
                return -1;

            for (int i = 0; i < left.coordinates.GetLength(0); i++)
            {
                result += left.coordinates[i] * right.coordinates[i];
            }
            result = Math.Sqrt(result);
            Logger.WriteMsg("Oper * suc");
            return result;
        }
        public static Vector operator +(Vector left, Vector right)
        {
            Vector result = new Vector(left);

            for (int i = 0; i < result.coordinates.GetLength(0); i++)
            {
                result.coordinates[i] += right.coordinates[i];
            }
            Logger.WriteMsg("Oper + suc");
            return result;
        }
        public static Vector operator -(Vector left, Vector right)
        {
            Vector result = new Vector(left);
            for (int i = 0; i < result.coordinates.GetLength(0); i++)
            {
                result.coordinates[i] -= right.coordinates[i];
            }
            return result;
        }
    }

}
