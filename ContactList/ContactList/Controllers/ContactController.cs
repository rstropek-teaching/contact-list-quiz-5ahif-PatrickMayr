using ContactList;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controllers.ContactList
{
    [Route("api/Contacts")]
    public class ContactController : Controller
    {
        private static List<Person> list = new List<Person>();

        static ContactController()
        {
            Person person1 = new Person(1, "Daniel", "Barth", "dani@gmail");
            Person person2 = new Person(2, "Patrick", "Mayr", "pat@gmail");
            list.Add(person1);
            list.Add(person2);
        }

        [HttpGet]
        public IActionResult GetAllPersons()
        {
            return Ok(list);
        }

        [HttpPost]
        public IActionResult AddPerson(int id, string firstName, string lastName, string email)
        {
            Person person = new Person(id, firstName, lastName, email);
            list.Add(person);                                                                                         
            //return CreatedAtRoute("GetSpecificPerson", new { index = person.id }, person);
            return Ok();
        }

        [HttpDelete]
        [Route("{index}")]
        public IActionResult DeletePerson(int index)
        {
            if(index >= 0 && index < list.Count)
            {
                list.RemoveAt(index);
                return Ok();
            }

            return BadRequest("Invalid index");
        }

        [HttpGet]
        [Route("{lastName}")]
        public IActionResult GetPerson(string lastName)
        {
            List<Person> help = new List<Person>();

            if(lastName != null && !lastName.Equals("")){

                for(int i = 0; i < list.Count; i++)
                {
                    Person person = list[i];
                    if (person.lastName.Equals(lastName))
                    {
                        help.Add(person);
                    }
                }

                return Ok(help);
            }

            return BadRequest("Invalid lastName");
        }
    }
}
