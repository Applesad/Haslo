using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Haslo.Interfaces;
using Haslo.ViewModels.Person;
using Microsoft.AspNetCore.Authorization;
namespace Haslo.Pages
{
    [Authorize]
    public class OstatnioSzukaneModel : PageModel
    {
        private readonly IPersonService _personService;

        public OstatnioSzukaneModel(IPersonService personService)
        {
            _personService = personService;
        }
        public IList<PersonForListVM> People { get; set; }

        public void OnGet()  
        {
            People = _personService.GetAllEntries();
            People.OrderByDescending(p => p.Date);
        }
    }
}
