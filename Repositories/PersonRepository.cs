using Haslo.Data;
using Haslo.Interfaces;
using Haslo.Models;

namespace Haslo.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Person> GetAllEntries()
        {
            return _context.Person;
        }

        public IQueryable<Person> GetEntriesFromToday()
        {
            DateTime dateTime = DateTime.Today.AddDays(1);
            return _context.Person.Where(p => p.Data >= DateTime.Today && p.Data < dateTime);
        }

        public void AddEntry(Person person)
        {
            _context.Person.Add(person);
            _context.SaveChanges();
        }

        public void DeleteEntry(Person person )
        {
            _context.Person.Remove(person);
            _context.SaveChanges();
        }
        public Person Find(int id)
        {
            return _context.Person.Find(id);
        }

    }
}
