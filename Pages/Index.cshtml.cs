using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Haslo.Models;
using Haslo.Interfaces;
using Haslo.ViewModels.Person;
using Microsoft.AspNetCore.Identity;
namespace Haslo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IPersonService _personService;
        private readonly SignInManager<IdentityUser> _signInManager;
        [BindProperty]
        public Person Person { get; set; }
        public List<PersonForListVM>? People { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IPersonService personService,SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _personService = personService;
            _signInManager = signInManager;
        }

        public void OnGet()
        {
            People = _personService.GetEntriesFromToday();
            People.OrderByDescending(p => p.Date);
        }
        public IActionResult OnPost()
        {
            //People = _context.Person.ToList();
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (ModelState.IsValid)
            {
                Person.SprawdzPrzestepnosc();
                if (_signInManager.IsSignedIn(User))
                {
                    Person.User = User.Identity.Name;
                }
                else Person.User = null;
               TempData["AlertMessage"] = Person.FirstName + " " + Person.LastName + " urodzil/a sie w " + Person.RokUrodzenia + ". Byl to rok " + Person.Rok;
                _personService.AddEntry(Person);
            }
            People = _personService.GetEntriesFromToday();
            People.OrderByDescending(p => p.Date);
            return RedirectToPage("./Index");
        }
    }
}