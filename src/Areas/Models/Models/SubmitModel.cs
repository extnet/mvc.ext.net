using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ext.Net.MVC.Examples.Areas.Models
{
    public class Person
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Sex Sex { get; set; }
        public bool Approved { get; set; }

        public static Person GetPerson()
        {
            Person person = new Person();
            person.ID = "1";
            person.FirstName = "John";
            person.LastName = "Last";
            person.DateOfBirth = new DateTime(1990, 1, 1);
            person.Sex = Sex.Male;
            person.Approved = true;

            return person;
        }
    }

    public enum Sex
	{
	   Male,
       Female
	}
}