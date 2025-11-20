using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Test_Lists_console_START
{
    internal class Program
    {
        /*
         * NAAM: Jules Stoop 
         * KLAS: 6ICW
         * DATUM: 20/11/2025
        */

        static void Main(string[] args)
        {
            // consolekleuren instellen
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();

            // Declaratie
            List<string[]> cars = new List<string[]>();
            // Bestand inlezen en vullen van de lijst 'cars'
            cars = BestandInlezen();
     
            ToonWagens(cars);
            
         


            // Bestand inlezen
            // aanvullen...


            // Zoekopdrachten
            Console.WriteLine("\n--- Zoekopdrachten en filters ---\n");

            // 1. (Lambda) Zoek de eerste wagen met benzine als brandstof
            Console.WriteLine("Eerste wagen met benzine:");

            List<string[]> bevatBezine = cars.FindAll(bezineIn);
            ToonWagens(bevatBezine);
            


            // 2. (Lambda) Vind alle wagens onder een bepaalde prijs (bijvoorbeeld onder 15000 euro)
            Console.WriteLine("\nWagens onder 15.000 EUR:");
            List<string[]> onder15 = cars.FindAll(prijs15);
            ToonWagens(onder15);


            // 3. (Lambda) Zoek wagens van een specifiek merk (bijvoorbeeld "Fiat")
            Console.WriteLine("\nAlle wagens van het merk Fiat:");
            List<string[]> bevatFiat = cars.FindAll(bevatFi);
            ToonWagens(bevatFiat);

            // 4. (Predicate) Zoek wagens met CO2-uitstoot hoger dan 120 g/km
            Console.WriteLine("\nWagens met CO2-uitstoot hoger dan 120 g/km:");
            


            // Voeg een wagen toe + tonen
            // aanvullen...


            // wachten op enter
            Console.WriteLine("\nDruk op enter om te eindigen.");
            Console.ReadLine();
        }

        private static bool bevatFi(string[] car)
        {
            return (car[0] == "Fiat");
        }

        private static bool prijs15(string[] car)
        {
            return (Convert.ToInt32(car[3]) < 15000);
        }

        private static bool bezineIn(string[] car)
        {
          
            return (car[2] == "Benzine" || car[2] == "Elektrisch/Benzine");
        }

        private static void ToonWagens(List<string[]> cars)
        {
            foreach (var car in cars)
            {
                // Controleer of het car-array minstens 2 elementen heeft
                if (car.Length >= 2)
                {
                    Console.WriteLine("{0} ({1} {2} {3}", car[0], car[1].PadRight(25), car[2].PadRight(15), car[3].PadRight(15));
                }
               
            }
        }


        // Bestand inlezen
        private static List<string[]> BestandInlezen()
        {
            List<string[]> tempCars = new List<string[]>();
            string volledigeLijn;

            using (StreamReader streamLees = new StreamReader("auto_export_file.txt"))
            {
                while (!streamLees.EndOfStream)
                {
                    volledigeLijn = streamLees.ReadLine();
                    tempCars.Add(volledigeLijn.Split(';'));
                }
            }

            return tempCars;
        }

        


        // De eerste parameter is de tekst die verkort moet worden
        // De tweede parameter is de maximale tekstlengte
        // De methode geeft de verkorte tekst terug
        private static string ShortItem(string item, int lengte)
        {
            return item.Length > lengte ? item.Substring(0, lengte) + "..." : item;
        }
    }
}
