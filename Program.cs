using Pastel;
using System;
using System.Threading.Tasks;

namespace Monitorowanie
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Here is the position monitor! Press any key to stop moving the players and display the menu.");
            Console.WriteLine("Starting in 5 seconds");
            System.Threading.Thread.Sleep(5000);
            
            while (true)
            {
                var controller = new Controller();
                controller.Run();
                Console.ReadKey();
                controller.Stop();
                break;
            }

            Console.WriteLine();
            Console.WriteLine("you have pressed a key");
            Console.ReadLine();
        }

        
    }   
}
