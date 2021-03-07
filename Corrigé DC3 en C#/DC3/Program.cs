using System;

namespace DC3
{
    class Program
    {
        static int N = default;
        static int k = -1;
        static Sequence[] V = new Sequence[5];
        static int[] T = new int[20];


        static int Saisie(int x)
        {
            bool canParse;

            do
            {
                do
                {
                    Console.WriteLine("Donner la taille du tableau: ");
                    canParse = int.TryParse(Console.ReadLine(), out x);
                } while (!canParse);
            } while ((x < 2) || (x > 20));
            return x;
        }

        static void RempT(int[] T, int N)
        {
            bool canParse;
            for (var i = 0; i < N; i++)
            {
                do
                {
                    Console.WriteLine("Donner T[{0}]: ", i);
                    canParse = int.TryParse(Console.ReadLine(), out T[i]);
                } while (!canParse);
            }
        }
        static void RempV(Sequence[] V, int[] T, int k, int N)
        {
            int i = -1;
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
                    k += 1;
                    V[k].IndD = i;
                    V[k].IndF = j - 1;
                    V[k].Nbr = j - i;
                    for (var c = i; c == j - 1; c++)
                    {
                        ch1 = T[c].ToString();
                        ch += ch1 + "|";
                    }
                    V[k].Seq = ch.Remove(ch.Length);
                    i = j - 1;
                }

            } while (i != N);
        }
        static void Main(string[] args)
        {

            N = Saisie(N);
            RempT(T, N);
            RempV(V, T, k, N);
            for (var i = 0; i < k; i++)
            {
                Console.WriteLine(V[k].Seq);
            }
        }
    }
}