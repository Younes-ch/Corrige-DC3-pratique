using System;
using System.Collections.Generic;

namespace DC3
{
    class Program
    {
        static int N = default;
        static int k = -1;
        static Sequence[][] V = new Sequence[5][];
        static int[] T = new int[20];
  
        static void Main(string[] args)
        {
            bool canParse;

            do
            {
                do
                {
                    Console.WriteLine("Donner la taille du tableau: ");
                    canParse = int.TryParse(Console.ReadLine(), out N);
                } while (!canParse);
            } while ((N < 2) || (N > 20));

            for (var h = 0; h < N; h++)
            {
                do
                {
                    Console.WriteLine("Donner T[{0}]: ", h);
                    canParse = int.TryParse(Console.ReadLine(), out T[h]);
                } while (!canParse);
            }

            int i = -1;
            int a = 0;
            string ch = "", ch1;
            do
            {
                i += 1;
                int j = i;
                while ((T[j] % 2 == 0) && (j <= N))
                {
                    j = j + 1;
                }

                if (j - i >= 2)
                {
                    k++;
                    V[a][k].IndD = i;
                    V[a][k].IndF = j - 1;
                    V[a][k].Nbr = j - i;
                    a++;
                    for (var c = i; c == j - 1; c++)
                    {
                        ch1 = T[c].ToString();
                        ch += ch1 + "|";
                    }
                    V[a][k].Seq = ch.Remove(ch.Length);
                    i = j - 1;
                }
            } while (i != N);

            for(var o = 0; o < k; o++)
            {
                Console.WriteLine(V[o][k].Seq);
            }
        }
    }
}
