using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Update.Models.Restful
{
    [Model(Name="Person")]
    public class TestPerson
    {
        [ModelField(IDProperty=true, UseNull=true)]
        [Field(Ignore=true)]
        public int? Id
        {
            get;
            set;
        }

        [EmailValidator]
        [PresenceValidator]
        public string Email
        {
            get;
            set;
        }

        [PresenceValidator]
        public string First
        {
            get;
            set;
        }

        [PresenceValidator]
        public string Last
        {
            get;
            set;
        }

        private static int curId = 7;
        private static object lockObj = new object();

        private static int NewId
        {
            get
            {
                return System.Threading.Interlocked.Increment(ref curId);
            }
        }

        public static List<TestPerson> TestData
        {
            get
            {
                return new List<TestPerson>
               {
                   new TestPerson{Id=1, Email="fred@flintstone.com", First="Fred", Last="Flintstone"},
                   new TestPerson{Id=2, Email="wilma@flintstone.com", First="Wilma", Last="Flintstone"},
                   new TestPerson{Id=3, Email="pebbles@flintstone.com", First="Pebbles", Last="Flintstone"},
                   new TestPerson{Id=4, Email="barney@rubble.com", First="Barney", Last="Rubble"},
                   new TestPerson{Id=5, Email="betty@rubble.com", First="Betty", Last="Rubble"},
                   new TestPerson{Id=6, Email="bambam@rubble.com", First="BamBam", Last="Rubble"}
               };
            }
        }

        public static List<TestPerson> Storage
        {
            get
            {
                var persons = HttpContext.Current.Session["TestPersons"];

                if (persons == null || !(persons is List<TestPerson>))
                {
                    persons = TestPerson.TestData;
                    HttpContext.Current.Session["TestPersons"] = persons;
                }

                return (List<TestPerson>)persons;
            }
            set
            {
                HttpContext.Current.Session["TestPersons"] = value;
            }
        }

        public static void Clear()
        {
            TestPerson.Storage = null;
        }

        public static int? AddPerson(TestPerson person)
        {
            lock (lockObj)
            {
                var persons = TestPerson.Storage;
                person.Id = TestPerson.NewId;
                persons.Add(person);
                TestPerson.Storage = persons;

                return person.Id;
            }
        }

        public static void DeletePerson(int id)
        {
            lock (lockObj)
            {
                var persons = TestPerson.Storage;
                TestPerson person = null;

                foreach (TestPerson p in persons)
                {
                    if (p.Id == id)
                    {
                        person = p;
                        break;
                    }
                }

                if (person == null)
                {
                    throw new Exception("TestPerson not found");
                }

                persons.Remove(person);

                TestPerson.Storage = persons;
            }
        }

        public static void UpdatePerson(TestPerson person)
        {
            lock (lockObj)
            {
                var persons = TestPerson.Storage;
                TestPerson updatingPerson = null;

                foreach (TestPerson p in persons)
                {
                    if (p.Id == person.Id)
                    {
                        updatingPerson = p;
                        break;
                    }
                }

                if (updatingPerson == null)
                {
                    throw new Exception("TestPerson not found");
                }

                updatingPerson.Email = person.Email;
                updatingPerson.Last = person.Last;
                updatingPerson.First = person.First;

                TestPerson.Storage = persons;
            }
        }
    }
}