using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace JSON_VAT_Project
{
    public class JsonProcessing
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
    }
}
