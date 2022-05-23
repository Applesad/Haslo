using Haslo.Models;
using Haslo.ViewModels.Person;
namespace Haslo.Interfaces
{   
    public interface IPersonService
    {
        List<PersonForListVM> GetAllEntries();
        List<PersonForListVM> GetEntriesFromToday();
        void AddEntry(Person person);
        void DeleteEntry(Person person);
        Person Find(int id);
    }
}
