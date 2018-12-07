using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonPremierClient
{
    class Program
    {
        static async void MaMethodeAsynchrone(string input, ServiceReference1.Service1Client client)
        {

            Console.WriteLine($"Prix de l'objet {input} : {await client.GetPriceAsync(input)}");
        }

        static void Main(string[] args)
        {
            var input = "";
            var client = new ServiceReference1.Service1Client();

            do
            {
                Console.WriteLine("Quel est le nom de l'objet dont vous voulez savoir le prix ?");

                input = Console.ReadLine();

                //Console.WriteLine($"Prix de l'objet {input} : {client.GetPrice(input)}");
                Task.Run(() => MaMethodeAsynchrone(input, client));

            } while (input != "quit");

            client.Close();
        }
    }
}
