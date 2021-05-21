using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProblemaRendez_Vous
{
    class Program
    {
        static int[] V = new int[1000];
        static int[] W = new int[1000];
        static int min = int.MaxValue;
        static double media = 0;

        static SemaphoreSlim sem1 = new SemaphoreSlim(0);
        static SemaphoreSlim sem2 = new SemaphoreSlim(0);

        static void Main(string[] args)
        {
            Thread t1 = new Thread(() => Metodo1());
            t1.Start();
            Thread t2 = new Thread(() => Metodo2());
            t2.Start();

            while (t1.IsAlive) { }
            while (t2.IsAlive) { }

            Console.WriteLine($"minimo: {min}");
            Console.WriteLine($"media: {media}");

            Console.ReadLine();
        }

        private static void Metodo1()
        {
            Random r = new Random();

            for (int i = 0; i < V.Length; i++)
            {
                V[i] = r.Next(0, 1000);
                if (V[i] < min)
                    min = V[i];
            }
            sem2.Release();

            sem1.Wait();
            for (int i = 0; i < W.Length; i++)
            {
                if (W[i] < min)
                    min = W[i];
            }
        }

        private static void Metodo2()
        {
            Random r = new Random();

            for (int i = 0; i < W.Length; i++)
            {
                W[i] = r.Next(0, 1000);
                media += W[i];
            }
            sem1.Release();

            sem2.Wait();
            for (int i = 0; i < V.Length; i++)
                media += V[i];
            media = media / 2000;
        }
    }
}
