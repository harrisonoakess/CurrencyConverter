using System;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic;

namespace CurrencyConverterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // On startup, everything below here runs
            Console.WriteLine("Welcome to my Currency Converter!");
            var rates = LoadExchangeRates();

            bool active = true;
            while (active)
            {
                ShowMenu();
                Console.Write("Please select an option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ConvertCurrency();
                        break;

                    case "2":
                        ListAllCurrencies(rates);
                        break;

                    case "3":
                        active = CloseApp(active);
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;

                }
            }

            Console.Write("See you next time!");
        }

        static void ShowMenu()
        {
            Console.WriteLine("\n=== Menu ===");
            Console.WriteLine("1. Convert currency");
            Console.WriteLine("2. List all currencies");
            Console.WriteLine("3. Exit");
        }

        static void ListAllCurrencies(Dictionary<string, (string name, decimal rate)> rates)
        {
            Console.WriteLine("\n=== Currencies ===");
            Console.WriteLine($"{"Code",-6} {"Name",-25} {"Rate/USD",-10}");
            Console.WriteLine(new string('-', 50));

            foreach (var line in rates)
            {
                string code = line.Key;
                string name = line.Value.name;
                decimal rate = line.Value.rate;
                Console.WriteLine($"{code,-6} {name,-25} {rate,-10:F6}");
            }
        }

        static void ConvertCurrency()
        {
            var rates = new Dictionary<string, decimal>
                {
                    { "USD", 1.0m },
                    { "PHP", 43.1232m },
                    { "EUR", 0.92m },
                    { "JPY", 150.5m }
                };

            Console.WriteLine("Enter amount: ");
            string amountInput = Console.ReadLine();
            bool isValidAmount = decimal.TryParse(amountInput, out decimal amount);
            if (!isValidAmount)
            {
                Console.WriteLine("Invalid amount. Please enter a valid number");
                return;
            }
            Console.Write("From currency: ");
            string fromInput = Console.ReadLine().ToUpper();
            bool validFromInput = rates.ContainsKey(fromInput);
            if (!validFromInput)
            {
                Console.WriteLine("Please select a valid currency");
                return;
            }

            Console.Write("To currency: ");
            string toInput = Console.ReadLine().ToUpper();

            bool validToInput = rates.ContainsKey(toInput);
            if (!validToInput)
            {
                Console.WriteLine("Please select a valid currency");
                return;
            }

            decimal rateFrom = rates[fromInput];
            decimal rateTo = rates[toInput];

            decimal amountInUSD = amount / rateFrom;
            decimal converted = amountInUSD * rateTo;

            Console.WriteLine($"  Amount: {amount}");
            Console.WriteLine($"  From:   {fromInput} @ rate {rateFrom}");
            Console.WriteLine($"  To:     {toInput} @ rate {rateTo}");
            Console.WriteLine($"  Result: {converted:F2} {toInput}");

        }

        static bool CloseApp(bool active)
        {
            active = false;
            return active;
        }

        static Dictionary<string, (string name, decimal rate)> LoadExchangeRates()
        {
            return new Dictionary<string, (string, decimal)>
            {
                { "USD", ("US Dollar", 1.000000m) },
                { "EUR", ("Euro", 0.854101m) },
                { "GBP", ("British Pound", 0.745700m) },
                { "INR", ("Indian Rupee", 88.685344m) },
                { "AUD", ("Australian Dollar", 1.526500m) },
                { "CAD", ("Canadian Dollar", 1.393802m) },
                { "SGD", ("Singapore Dollar", 1.291593m) },
                { "CHF", ("Swiss Franc", 0.797388m) },
                { "MYR", ("Malaysian Ringgit", 4.221235m) },
                { "JPY", ("Japanese Yen", 149.382469m) },
                { "CNY", ("Chinese Yuan Renminbi", 7.135415m) }
            };
        }
    }
}
