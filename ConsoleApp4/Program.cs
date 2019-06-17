using System;
using System.IO;
namespace Task2
{
    class Program
    {
        public static int size;
        static char[,] path;
        static int[,] lens;
        public static void SetLens()
        {
            int i, j;
            for (i = 0; i < size; i++)
            {
                for (j = 0; j < size; j++)
                {
                    if (j > 0 && i == 0)
                    {
                        lens[i, j] = lens[i, j - 1] + vals[i, j];
                    }
                    if (i > 0 && j == 0)
                    {
                        lens[i, j] = lens[i - 1, j] + vals[i, j];
                    }
                    if (i > 0 && j > 0)
                    {
                        if (lens[i, j - 1] + vals[i, j] > lens[i - 1, j] + vals[i, j])
                            lens[i, j] = lens[i - 1, j] + vals[i, j];
                        else
                            lens[i, j] = lens[i, j - 1] + vals[i, j];
                    }
                }
            }
        }
        public static void BuildPath()
        {
            int x = size - 1, y = size - 1;
            while (x > 0 || y > 0)
            {
                path[x, y] = '#';
                if (x == 0)
                    --y;
                else if (y == 0)
                    --x;
                else
                if (lens[x, y] == lens[x - 1, y] + vals[x, y])
                    --x;
                else
                    --y;
            }
            path[x, y] = '#';
        }
        public static int[,] vals;
        public static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            StreamWriter sw = new StreamWriter("output.txt");
            int n = Convert.ToInt32(sr.ReadLine());
            vals = new int[n, n];
            path = new char[n, n];
            lens = new int[n, n];
            int i, j;
            string line;
            i = 0;
            size = n;
            lens[0, 0] = vals[0, 0];
            for (i = 0; i < n; i++)                                      // Read Input
            {
                line = sr.ReadLine();
                for (j = 0; j < n; j++)
                {
                    vals[i, j] = Convert.ToInt32(line[j].ToString());
                    path[i, j] = '.';
                    lens[i, j] = 0;
                }

            }
            SetLens();                                                  // Calculate short path
            BuildPath();                                                // Write path
            for (i = 0; i < n; i++)                                     // Write output
            {
                for (j = 0; j < n; j++)
                    sw.Write(path[i, j]);
                sw.WriteLine();
            }
            sr.Close();
            sw.Close();
        }

    }
}