﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace JSON_VAT_Project
{
    public class Country
        {
        public string country { get; set; }

        [JsonConverter(typeof(RateJsonConverter))]
        public decimal standard_rate { get; set; }

        [JsonConverter(typeof(RateJsonConverter))]
        public decimal reduced_rate { get; set; }

        [JsonConverter(typeof(RateJsonConverter))]
        public decimal reduced_rate_alt { get; set; }

        [JsonConverter(typeof(RateJsonConverter))]
        public decimal super_reduced_rate { get; set; }

        [JsonConverter(typeof(RateJsonConverter))]
        public decimal parking_rate { get; set; }

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

                    if ((country.standard_rate != -1) && (country.standard_rate >= highestRateCountries[i].standard_rate))
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

                    if ((country.standard_rate != -1) && (country.standard_rate <= lowestRateCountries[i].standard_rate))
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
