using System;

namespace JSON_VAT_Project
{

    class Program
    {
        static void Main(string[] args)
        {

            string vatJson = JsonProcessing.getJson("https://euvatrates.com/rates.json");

            var countries = JsonProcessing.getListOfCountries(vatJson);

            var highestRateCountries = Country.GetHighestRateCountries(countries, 3);

            Console.WriteLine("EU countries with the highest standard VAT rate: ");
            foreach(var country in highestRateCountries)
            {
                Console.WriteLine(country.country);
            }

            Console.WriteLine();

            var lowestRateCountries = Country.GetLowesRateCountries(countries, 3);

            Console.WriteLine("EU countries with the lowest standard VAT rate: ");
            foreach (var country in lowestRateCountries)
            {
                Console.WriteLine(country.country);
            }


            Console.ReadLine();
        }
    }
}
