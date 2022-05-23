using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Haslo.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string? LastName { get; set; }
        [Required, Range(1899, 2022, ErrorMessage = "Oczekiwana wartość {0} z zakredu {1} i {2}.")]
        public int? RokUrodzenia { get; set; }
        public string? Rok { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Data { get; set; }
        public string? User { get; set; }
        public bool IsActive { get; set; }

        public void SprawdzPrzestepnosc()
        {
            Data = DateTime.Now;
            if ((RokUrodzenia % 4 == 0 && RokUrodzenia % 100 != 0) || (RokUrodzenia % 400 == 0))
            {
                Rok = "przestepny";
            }
            else Rok = "nie przestepny";

        }

    }
}
