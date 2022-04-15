using System;
using System.Threading;

namespace Logic
{
    public class Program
    {

        static void Main(string[] args)
        {
            Thread watek = new Thread(dodaj);
            watek.Start();
            Thread watek2 = new Thread(odejmij);
            watek2.Start(); 
        }

        static void dodaj()
        {
            for(int i = 0; i < 100; i++)
            Console.WriteLine(4 + i);
        }
        static void odejmij()
        {
            for (int i = 0; i < 100; i++)
                Console.WriteLine(-1 - i);
        }
    }
}
