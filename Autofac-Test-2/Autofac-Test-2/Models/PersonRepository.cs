using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autofac_Test_2.Models
{
    public class PersonRepository : IPersonRepository
    {
        List<Person> people = new List<Person>();
        public PersonRepository()
        {
            Add(new Person { Id = 1, Name = "joye.net1", Age = 18, Address = "中国上海" });
            Add(new Person { Id = 2, Name = "joye.net2", Age = 18, Address = "中国上海" });
            Add(new Person { Id = 3, Name = "joye.net3", Age = 18, Address = "中国上海" });
        }

        public Person Add(Person person)
        {
            if (person == null)
            {
                throw new ArgumentException("item");
            }
            people.Add(person);
            return person;
        }

        public bool Delete(int id)
        {
            people.Remove(people.Find(m => m.Id == id));
            return true;
        }

        public Person Get(int id)
        {
            return people.Find(m => m.Id == id);
        }

        public IEnumerable<Person> GetAll()
        {
            return people;
        }

        public bool Update(Person person)
        {
            if (person == null)
            {
                throw new ArgumentException("item is null");
            }
            int index = people.FindIndex(p => p.Id == person.Id);
            if (index == -1)
            {
                return false;
            }
            people.RemoveAt(index);
            people.Add(person);
            return true;
        }
    }
}