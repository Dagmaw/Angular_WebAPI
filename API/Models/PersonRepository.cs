using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace TestApi1.Models
{
    public class PersonRepository
    {

        /// <summary>
        /// Retrieves the list of persons.
        /// </summary>
        /// <returns></returns>
        internal List<Person> Retrieve()
        {
            var filePath = HostingEnvironment.MapPath(@"~/App_Data/persons.json");

            var json = System.IO.File.ReadAllText(filePath);

            var persons = JsonConvert.DeserializeObject<List<Person>>(json);

            return persons;
        }

        /// <summary>
        /// Updates an existing person
        /// </summary>
        /// <param name="id"></param>
        /// <param name="person"></param>
        /// <returns></returns>
        ///
        
        internal Person Save(int id, Person person)
        {
            // Read in the existing persons
            var persons = this.Retrieve();

            // Locate and replace the item
            foreach (var item in persons)
            {
                if (id == item.ID)
                {
                    List<Person> p = new List<Person>();
                    item.ID = person.ID;
                    item.FirstName = person.FirstName;
                    item.LastName = person.LastName;
                    item.JobTitle = person.JobTitle;

                    p.Add(item);
                    WriteData(p);

                }
                else
                {
                    return null;
                }

            }

            return person;
        }


        private bool WriteData(List<Person> persons)
        {
            // Write out the Json
            var filePath = HostingEnvironment.MapPath(@"~/App_Data/person.json");

            var json = JsonConvert.SerializeObject(persons, Formatting.Indented);
            System.IO.File.WriteAllText(filePath, json);
            return true;
        }
    }
}