using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace CountryRatesTests
{
    [TestClass]
    public class UnitTests
    {
        // In order to run the below test(s), 
        // please follow the instructions from http://go.microsoft.com/fwlink/?LinkId=619687
        // to install Microsoft WebDriver.

        [Test]

        // MethodName_StateUnderTest_ExpectedBehavior
        public void GetHighestRateCountries_GetsCountriesWithHighestRate_GetsFourCountriesWithHighestRate()
        {
            // Arrange - Setup enviroment
            int number1 = 10;
            int number2 = 5;
            int expectedResult = ;

            // Act - SUT Szstem Under Test
            int actualResult = Program.Sum(number1, number2);

            // Assert - Validate expected result
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
