﻿using CountryData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryData.StaticData
{
    public class CountryTaxService : ICountryTaxService
    {
        public readonly List<Tax> _countriesTax = new List<Tax>();

        public CountryTaxService()
        {
            _countriesTax.Add(new Tax { Country = "finland", VAT = 20 });
            _countriesTax.Add(new Tax { Country = "ireland", VAT = 30 });
            _countriesTax.Add(new Tax { Country = "norway", VAT = 40 });

        }

        public List<Tax> GetAllCountriesWithTax()
        {
            return _countriesTax;
        }

        public float GetCountryTax(string country, decimal amount)
        {
            var tax = _countriesTax.Where(x => x.Country == country).Select(s => s.VAT).FirstOrDefault();
            return (float) (amount / 100) * tax;
        }
    }
}
