using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Haslo.Data;
using Haslo.Models;
using Haslo.Interfaces;

namespace Haslo.Pages.OstatnioSzukane
{
    public class DeleteModel : PageModel
    {

        private readonly IPersonService _personService;

        public DeleteModel(IPersonService personService)
        {   
            _personService = personService;
        }

        [BindProperty]
        public Person Person { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Person = _personService.Find(id);

            if (Person == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Person = _personService.Find(id);

            if (Person != null && Person.User == User.Identity.Name)
            {
                _personService.DeleteEntry(Person);
            }
            else
            {
                return Forbid();
            }

            return RedirectToPage("./Index");
        }
    }
}
