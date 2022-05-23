using Haslo.Interfaces;
using Haslo.ViewModels.Person;
using Haslo.Models;
namespace Haslo.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepo;
        public PersonService(IPersonRepository personRepo)
        {
            _personRepo = personRepo;
        }

        public List<PersonForListVM> GetAllEntries()
        {
            var people = _personRepo.GetAllEntries();
            List<PersonForListVM> result = new List<PersonForListVM>();
            foreach (var person in people)
            {
                var personVM = new PersonForListVM()
                {
                    FullName = person.FirstName + " " + person.LastName,
                    Rok = person.Rok,
                    Date = person.Data,
                    Id = person.Id
                };
                result.Add(personVM);
            }
            return result;
        }

        public List<PersonForListVM> GetEntriesFromToday()
        {
            var people = _personRepo.GetEntriesFromToday();
            List<PersonForListVM> result = new List<PersonForListVM>();

            foreach (var person in people)
            {
                var personVM = new PersonForListVM()
                {
                    FullName = person.FirstName + " " + person.LastName,
                    Rok = person.Rok,
                    Date = person.Data,
                    Id = person.Id
                };
                result.Add(personVM);
            }
            return result;
        }

        public void AddEntry(Person person)
        {
            _personRepo.AddEntry(person);
        }
        public void DeleteEntry(Person person)
        {
            _personRepo.DeleteEntry(person);
        }
        public Person Find(int id)
        {
            return _personRepo.Find(id);
        }
    }
}
