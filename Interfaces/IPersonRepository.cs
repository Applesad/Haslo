using Haslo.Models;
namespace Haslo.Interfaces
{
    public interface IPersonRepository
    {
        IQueryable<Person> GetAllEntries();
        IQueryable<Person> GetEntriesFromToday();
        void AddEntry(Person person);
        void DeleteEntry(Person person);
        Person Find(int id);
    }
}
