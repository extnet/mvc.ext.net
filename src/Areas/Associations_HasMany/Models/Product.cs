namespace Ext.Net.MVC.Examples.Areas.Associations_HasMany.Models
{
    public class Product
    {
        public Product(int id, string name)
        {
            this.Id = id;
            this.Name = name;
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
    }
}