using System;
using System.Collections.Generic;

namespace JSON_VAT_Project
{
    class Country
        {
        public string country { get; set; }
        public double standard_rate { get; set; }
        public string reduced_rate { get; set; }
        public string reduced_rate_alt { get; set; }
        public string super_reduced_rate { get; set; }
        public string parking_rate { get; set; }

        static public Country[] GetHighestRateCountries(List<Country> countries, int count)
        {
            Country[] highestRateCountries = new Country[count];

            for (int j = 0; j < count; j++)
            {
                highestRateCountries[j] = countries[0];
            }

            for (int i = 0; i < count; i++)
            {
                foreach (var country in countries)
                {
                    var changeValue = true;

                    if (country.standard_rate >= highestRateCountries[i].standard_rate)
                    {
                        for (int k = 0; k < i; k++)
                        {
                            if (highestRateCountries[k] == country)
                            {
                                changeValue = false;
                            }
                        }

                        if (changeValue)
                        {
                            highestRateCountries[i] = country;
                        }
                    }
                }
            }

            return highestRateCountries;
        }

        static public Country[] GetLowesRateCountries(List<Country> countries, int count)
        {
            Country[] lowestRateCountries = new Country[count];

            for (int j = 0; j < count; j++)
            {
                lowestRateCountries[j] = countries[0];
            }


            for (int i = 0; i < 3; i++)
            {
                foreach (var country in countries)
                {
                    var changeValue = true;

                    if (country.standard_rate <= lowestRateCountries[i].standard_rate)
                    {
                        for (int k = 0; k < i; k++)
                        {
                            if (lowestRateCountries[k] == country)
                            {
                                changeValue = false;
                            }
                        }

                        if (changeValue)
                        {
                        lowestRateCountries[i] = country;
                        }
                    }
                }
            }

            return lowestRateCountries;
        }
    }
}
