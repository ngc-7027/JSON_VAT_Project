using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JSON_VAT_Project;
using System.Collections.Generic;

namespace JSON_VAT_Tests
{
    [TestClass]
    public class CountryRateCalculationsTests
    {

        string vatJson = JsonProcessing.getJson("https://euvatrates.com/rates.json");

        List<Country> countries = JsonProcessing.getListOfCountries(vatJson);

        [Test]

        // MethodName_StateUnderTest_ExpectedBehavior
        public void GetHighestRateCountries_OneCountry_GetCountryWithHighestStandartRate()
        {
            // Arrange
            string expectedResult = "Hungary";

            // Act
            string actualResult = Country.GetHighestRateCountries(countries, 1)[0].ToString();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
