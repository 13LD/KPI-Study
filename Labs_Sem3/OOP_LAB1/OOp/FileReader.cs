using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OOp
{
    public class FileReader
    {
        int dim;

        public Vector X, Y;
        public Matrix A, B, C;

        FileStream file;
        StreamReader read;


        public FileReader()
        {
            Logger.WriteMsg("FileReader Started");
            file = new FileStream("F:\\Films\\OOP_LAB1\\read.txt", FileMode.Open, FileAccess.Read);
            read = new StreamReader(file);

            ReadDim();
            ReadVectors();
            ReadMatrixs();
            Logger.WriteMsg("FileReader finished");
        }

        public int ReadDim()
        {
            Logger.WriteMsg("Reading dimension");
            try
            {
                string input = read.ReadLine();
                string pattern = "([0-9]+)";
                Match m = Regex.Match(input, pattern);
                Int32.TryParse(m.Value, out dim);

                return dim;
            }
            catch (Exception e)
            {
                Logger.WriteMsg("Failed to read dimension");
                Logger.Final();
                Console.WriteLine("Exception caught in reading dimension");
                Console.WriteLine(e);
                Console.ReadKey();
                Environment.Exit(0);
                return -1;
            }
        }

        public Vector ReadVec(Vector vec)
        {
            Logger.WriteMsg("Reading single vector");
            string input = read.ReadLine();
            string pattern = @"-?\d+[,]?";
            int cnt = 0;
            try
            {
                double[] arr = new double[dim];
                
                foreach (Match m in Regex.Matches(input, pattern))
                {
                    arr[cnt++] = double.Parse(m.Value);
                }

                if (cnt != dim)
                    throw new Exception();

                vec = new Vector(arr);

                return vec;
            }
            catch (Exception e)
            {
                Logger.WriteMsg("Failed to read vector");
                if (dim * dim != cnt)
                    Logger.WriteMsg("Wrong dims or wrong parametr of vector");
                Logger.Final();
                Console.WriteLine("Exception caught in reading vector");
                Console.WriteLine(e);
                Console.ReadKey();
                Environment.Exit(0);
                return null;
            }
        }
        public Matrix ReadMatr(Matrix matr)
        {
            Logger.WriteMsg("Reading single matrix");
            string input = read.ReadLine();
            string pattern = @"-?\d+[,]?";
            int cnt = 0;
            try
            {
                double[] arr = new double[dim * dim];
                
                foreach (Match m in Regex.Matches(input, pattern))
                {
                    arr[cnt++] = double.Parse(m.Value);
                }

                if (cnt != dim * dim)
                    throw new Exception();


                matr = new Matrix(dim, arr);
                return matr;
            }
            catch (Exception e)
            {
                Logger.WriteMsg("Failed to read matrix");
                if (dim * dim != cnt)
                    Logger.WriteMsg("Wrong dims or wrong parametr or vector");
                Logger.Final();
                Console.WriteLine("Exception caught in reading matrix");
                Console.WriteLine(e);
                Console.ReadKey();
                Environment.Exit(0);
                return null;
            }
        }
        public void ReadVectors()
        {
            X = ReadVec(X);
            Y = ReadVec(Y);
            Logger.WriteMsg("Vectors reading finished");
        }
        public void ReadMatrixs()
        {
            A = ReadMatr(A);
            B = ReadMatr(B);
            C = ReadMatr(C);
            Logger.WriteMsg("Matrixs reading finished");
        }
    }

}
