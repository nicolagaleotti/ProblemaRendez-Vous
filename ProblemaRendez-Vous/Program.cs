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
        int[] V = new int[1000];
        int[] W = new int[1000];
        int min = int.MaxValue;
        double media = 0;

        static SemaphoreSlim sem1 = new SemaphoreSlim(1);
        static SemaphoreSlim sem2 = new SemaphoreSlim(1);

        static void Main(string[] args)
        {
        }

        Random r = new Random();

        private void Metodo1()
        {
            for (int i = 0; i < V.Length; i++)
            {
                V[i] = r.Next(0, 1000);
                if (V[i] < min)
                    min = V[i];
            }
            for (int i = 0; i < W.Length; i++)
            {
                if (W[i] < min)
                    min = W[i];
            }
        }

        private void Metodo2()
        {
            for (int i = 0; i < W.Length; i++)
            {
                W[i] = r.Next(0, 1000);
                media += W[i];
            }
            for (int i = 0; i < V.Length; i++)
                media += V[i];
            media = media / 2000;
        }
    }
}
