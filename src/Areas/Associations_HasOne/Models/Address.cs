namespace Ext.Net.MVC.Examples.Areas.Associations_HasOne.Models
{
    public class Address
    {
        public Address(int id, string number, string street, string city, string zip)
        {
            this.Id = id;
            this.Number = number;
            this.Street = street;
            this.City = city;
            this.Zip = zip;
        }

        public int Id
        {
            get;
            private set;
        }

        public string Number
        {
            get;
            private set;
        }

        public string Street
        {
            get;
            private set;
        }

        public string City
        {
            get;
            private set;
        }

        public string Zip
        {
            get;
            private set;
        }
    }
}