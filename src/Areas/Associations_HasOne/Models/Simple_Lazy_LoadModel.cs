namespace Ext.Net.MVC.Examples.Areas.Associations_HasOne.Models
{
    public class Simple_Lazy_Load
    {
        public class Person
        {
            public Person(int id, string name, int addressId)
            {
                this.Id = id;
                this.Name = name;
                this.AddressId = addressId;
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

            public int AddressId
            {
                get;
                private set;
            }
        }
    }

}