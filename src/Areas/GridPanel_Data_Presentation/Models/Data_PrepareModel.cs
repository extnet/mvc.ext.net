using System;
using System.Collections;
using System.Collections.Generic;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Data_Presentation.Data_Prepare
{
    public class Customer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public Address Address { get; set; }
    }

    public class Address
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
    }

    public class Customers
    {
        public static IEnumerable GetAll()
        {
            List<Customer> list = new List<Customer>(5);

            for (int i = 1; i <= 5; i++)
            {
                Customer customer = new Customer
                {
                    ID = i,
                    FirstName = ("FirstName" + i),
                    LastName = ("LastName" + i),
                    Company = ("Company" + i)
                };

                Address address = new Address
                {
                    StreetAddress = ("Street" + i),
                    City = ("City" + i)
                };

                customer.Address = address;

                list.Add(customer);
            }

            return list;
        }
    }
}