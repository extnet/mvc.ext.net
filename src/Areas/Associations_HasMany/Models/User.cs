using System.Collections.Generic;

namespace Ext.Net.MVC.Examples.Areas.Associations_HasMany.Models
{
    public class User
    {
        public User(int id, string name, List<Product> products)
        {
            this.Id = id;
            this.Name = name;
            this.Products = products;
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

        public List<Product> Products
        {
            get;
            private set;
        }
    }
}