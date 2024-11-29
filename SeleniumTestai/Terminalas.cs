using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTestai;
using SeleniumTestai.testai;
using System;
using System.Reflection;
using System.Threading;

namespace Terminalas
{
    class Program
    {
        static void Main(string[] args)
        {
            Functions veiksmai = new Functions();
            DarbuotojoPridejimas Pirmas_testas = new DarbuotojoPridejimas();
            DarbuotojoPakeitimai Antras_testas = new DarbuotojoPakeitimai();
            KandidatoPridejimas Trecias_testas = new KandidatoPridejimas();
            BuzzFeed Ketvirtas_testas = new BuzzFeed();
            NaujaAtaskaita Penktas_testas = new NaujaAtaskaita();
            string? userURL = null;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nPasirinkite testą:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1 - Pridėti naują darbuotoją ir atlikti paiešką (pirmas testas)");
                Console.WriteLine("2 - Sukurto darbuotojo asmeninių duomenų pakeitimai (antras testas)");
                Console.WriteLine("3 - Pridėti i darbą naują kandidatą (trecias testas)");
                Console.WriteLine("4 - 'BuzzFeed' (ketviras testas)");
                Console.WriteLine("5 - Naujos ataskaitos kūrimas (penktas testas)");
                Console.WriteLine("9 - Išvalyti terminalą");
                Console.WriteLine("0 - Išeiti");
                Console.Write("Įveskite savo pasirinkimą: ");

                string pasirinkimas = Console.ReadLine() ?? " ";

                switch (pasirinkimas)
                {
                    case "1":
                        userURL = Pirmas_testas.PridėtiDarbuotoją();
                        break;
                    case "2":
                        veiksmai.ExecuteTestIfUserExists(userURL, Antras_testas.AtnaujintiDarbuotoją);
                        break;
                    case "3":
                        veiksmai.ExecuteTestIfUserExists(userURL, Trecias_testas.PridėtiKandidatą);
                        break;
                    case "4":
                        Ketvirtas_testas.NaujienųSrautoTestai();
                        break;
                    case "5":
                        Penktas_testas.SukurtiAtaskaitą();
                        break;
                    case "9":
                        Console.Clear();
                        break;
                    case "0":
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nNeteisingas pasirinkimas. Bandykite dar kartą.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }
        }
    }
}
