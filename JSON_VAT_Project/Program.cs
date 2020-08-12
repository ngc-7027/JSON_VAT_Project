using System;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace JSON_VAT_Project
{
    class Program
    {
        static public string getJson(string urlLink)
        {
            WebClient client = new WebClient();
            return client.DownloadString(urlLink);
        }

        static public List<Country> getListOfCountries(string str)
        {
            List<Country> countries = new List<Country>();

            const string RegexPattern = @"""[A-Z]{2}""[ :]+((?=\[)\[[^]]*\]|(?=\{)\{[^\}]*\}|\""[^""]*\"")";
            foreach (var item in Regex.Matches(str, RegexPattern, RegexOptions.Multiline))
            {
                var countrySubstringStartIndex = item.ToString().IndexOf('{');
                var countrySubstring = item.ToString().Substring(countrySubstringStartIndex);
                countries.Add(JsonConvert.DeserializeObject<Country>(countrySubstring));
            }

            return countries;
        }


        static void Main(string[] args)
        {

            string vatJson = getJson("https://euvatrates.com/rates.json");

            var countries = getListOfCountries(vatJson);

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
