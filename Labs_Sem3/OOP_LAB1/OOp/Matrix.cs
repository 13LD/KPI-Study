using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOp
{
    public class Matrix
    {
        public double[,] coordinates;
        public Matrix(int dim, params double[] coord)
        {
            if (dim != Math.Sqrt(coord.Length)) {
                Console.WriteLine("SUKA\n"); 
                Logger.WriteMsg("Fails Dimensions or input");
                throw new Exception("wrong input");
            }

                coordinates = new double[dim, dim];

            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)
                {
                    coordinates[i, j] = coord[i * dim + j];
                }
            }
        }
        public Matrix(Matrix prev)
        {
            int dim = prev.coordinates.GetLength(0);
            coordinates = new double[dim, dim];
            coordinates = (double[,])prev.coordinates.Clone();
        }

        public Matrix Transponate(Matrix m)
        {
            Matrix result = new Matrix(m);
            int dim = m.coordinates.GetLength(0);
            for (int i = 0; i < dim; i++)
                for (int j = 0; j < dim; j++)
                    result.coordinates[i, j] = m.coordinates[j, i];
            return result;
        }


        public static Matrix operator +(Matrix l, Matrix r)
        {

            if (l.coordinates.GetLength(0) != r.coordinates.GetLength(0))
            {
                Logger.WriteMsg("Wrong dims");
                throw new Exception("Wrong dims");
            }

            int dim = l.coordinates.GetLength(0);
            Matrix res = new Matrix(l);

            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)
                {
                    res.coordinates[i, j] += r.coordinates[i, j];
                }
            }
            Logger.WriteMsg("Oper + suc");

            return res;
        }

        public static Matrix operator -(Matrix l, Matrix r)
        {

            if (l.coordinates.GetLength(0) != r.coordinates.GetLength(0))
            {
                Logger.WriteMsg("Wrong dims");
                throw new Exception("Wrong dims");
            }
               

            int dim = l.coordinates.GetLength(0);
            Matrix res = new Matrix(l);

            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)
                {
                    res.coordinates[i, j] -= r.coordinates[i, j];
                }
            }
            Logger.WriteMsg("Oper - suc");

            return res;
        }
        public static Matrix operator *(Matrix l, double val)
        {
            int dim = l.coordinates.GetLength(0);
            Matrix res = new Matrix(l);

            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)
                {
                    res.coordinates[i, j] *= val;
                }
            }
            Logger.WriteMsg("Oper * suc");

            return res;
        }
        public static Matrix operator *(Matrix l, Matrix r)
        {
            if (l.coordinates.GetLength(0) != r.coordinates.GetLength(0))
            {
                Logger.WriteMsg("Wrong dims");
                throw new Exception("Wrong dims");
            }
                

            int dim = l.coordinates.GetLength(0);
            Matrix result = new Matrix(l);

            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)
                {
                    result.coordinates[i, j] = 0;
                    for (int k = 0; k < dim; k++)
                    {
                        result.coordinates[i, j] += l.coordinates[i, k] * r.coordinates[k, j];
                    }
                }
            }
            Logger.WriteMsg("Oper * suc");

            return result;
        }
        public static Vector operator *(Matrix M, Vector V)
        {
            if (M.coordinates.GetLength(0) != V.coordinates.GetLength(0))
            {
                Logger.WriteMsg("Wrong dims");
                throw new Exception("Wrong dims");
            }
                

            int dim = M.coordinates.GetLength(0);
            Vector Result = new Vector(V);

            for (int i = 0; i < dim; i++)
            {
                Result.coordinates[i] = 0;
                for (int j = 0; j < dim; j++)
                {
                    Result.coordinates[i] += M.coordinates[i, j] * V.coordinates[j];
                }
            }
            Logger.WriteMsg("Oper * suc");

            return Result;
        }
        public void Show()
        {
            int dim = coordinates.GetLength(0);

            for (int i = 0; i < dim; i++, Console.WriteLine())
            {
                for (int j = 0; j < dim; j++)
                    Console.Write(coordinates[i, j] + " ");

            }
        }
    }

}
