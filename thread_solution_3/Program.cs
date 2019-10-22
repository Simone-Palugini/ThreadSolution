using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace thread_solution_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Thread>();

            //Qui creiamo ed eseguiamo cinque worker thread 
            for (int index=0; index<5; index++)
            {
                var myThread = new Thread((currentIndex) =>
                {
                    Console.WriteLine("Thtread {0} è iniziato", currentIndex);
                    Thread.Sleep(500);
                    Console.WriteLine("Thtread {0} è terminato", currentIndex);
                });
                myThread.Start(index);
                list.Add(myThread);
            }

            //attesa del completamento di ognuno dei worker thread
            foreach (Thread thread in list)
            {
                thread.Join();
            }

            Console.WriteLine("Esecuzione di tutti i thread terminata");

            Console.ReadLine();
        }
    }
}
