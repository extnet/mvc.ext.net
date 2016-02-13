namespace Ext.Net.MVC.Examples.Areas.Associations_HasOne.Models
{
    public class Person
    {
        public Person(int id, string name, Address address)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
        }

        public int Id
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }

        public Address Address
        {
            get;
            private set;
        }
    }
}