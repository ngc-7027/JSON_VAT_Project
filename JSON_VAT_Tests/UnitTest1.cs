using System.Collections.Generic;
using System.Net;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using JSON_VAT_Project;
using NUnit.Framework;

namespace JSON_VAT_Tests
{
    public class CountryRateCalculationsTests

    {

        [Test]

        // MethodName_StateUnderTest_ExpectedBehavior
        public void GetHighestRateCountries_OneCountry_GetCountryWithHighestStandartRate()
        {
            WebClient client = new WebClient();
            string vatJson = JsonProcessing.getJson("https://euvatrates.com/rates.json");

            List<Country> countries = new List<Country>();

            const string RegexPattern = @"""[A-Z]{2}""[ :]+((?=\[)\[[^]]*\]|(?=\{)\{[^\}]*\}|\""[^""]*\"")";
            foreach (var item in Regex.Matches(vatJson, RegexPattern, RegexOptions.Multiline))
            {
                var countrySubstringStartIndex = item.ToString().IndexOf('{');
                var countrySubstring = item.ToString().Substring(countrySubstringStartIndex);
                countries.Add(JsonConvert.DeserializeObject<Country>(countrySubstring));
            }

            // Arrange
            string expectedResult = "Hungary";

            // Act
            string actualResult = Country.GetHighestRateCountries(countries, 1)[0].ToString();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
