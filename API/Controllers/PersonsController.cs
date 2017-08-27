using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestApi1.Models;

namespace TestApi1.Controllers
{
    public class PersonsController : ApiController
    {
        // GET: api/Persons
        public IEnumerable<Person> Get()
        {
            var personRepository = new PersonRepository();
            return personRepository.Retrieve();
        }

        // PUT: api/Persons/1
        public void Put(int id, [FromBody]Person person)
        {
            try
            {
                var personRepository = new PersonRepository();
                var updatePersons = personRepository.Save(id, person);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }
        }
    }
}
