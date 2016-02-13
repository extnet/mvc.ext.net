using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace Ext.Net.MVC.Examples.Areas.Models
{
    public class Customer
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public Address BillingAddress { get; set; }
        public Address ShippingAddress { get; set; }

        public static Customer GetCustomer()
        {
            Customer customer = new Customer();
            customer.ID = "08-1";
            customer.FirstName = "Geoffrey";
            customer.LastName = "McGill";
            customer.Company = "Ext.NET, Inc.";

            Address address = new Address();
            address.StreetAddress = "#208, 10113 104 Street";
            address.ZipPostalCode = "T5J 1A1";
            address.City = "Edmonton";

            Country country = new Country();
            country = new Country();
            country.Code = "CA";

            address.Country = country;
            customer.ShippingAddress = address;

            return customer;
        }
    }

    public class Address
    {
        public string StreetAddress { get; set; }
        public string ZipPostalCode { get; set; }
        public string City { get; set; }
        public Country Country { get; set; }
    }

    public class Country
    {
        public Country()
        {
        }

        public Country(string code)
        {
            this.Code = code;
        }

        private Country(string code, string name)
        {
            this.code = code;
            this.name = name;
        }

        private string name;
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        private string code;
        public string Code
        {
            get
            {
                return this.code;
            }
            set
            {
                this.code = value;
                this.name = Country.Countries.First(c => c.Code == value).Name;
            }
        }

        private static List<Country> countryList;
        public static IEnumerable<Country> Countries
        {
            get
            {
                if (countryList != null)
                {
                    return countryList;
                }

                countryList = new List<Country>();

                CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);

                foreach (CultureInfo culture in cultures)
                {
                    if (!culture.IsNeutralCulture && culture.LCID != CultureInfo.InvariantCulture.LCID)
                    {
                        RegionInfo region = new RegionInfo(culture.LCID);

                        if (!countryList.Any(c => c.Code == region.TwoLetterISORegionName))
                        {
                            countryList.Add(new Country(region.TwoLetterISORegionName, region.EnglishName));
                        }
                    }
                }

                countryList.Sort((c1, c2) => c1.Name.CompareTo(c2.Name));
                return countryList;
            }
        }

        public static IEnumerable<ListItem> CountryItems
        {
            get
            {
                return Country.Countries.Select(c=>new ListItem(c.Name,c.Code));
            }
        }
    }
}