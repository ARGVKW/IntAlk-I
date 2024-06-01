using System.ComponentModel.DataAnnotations;

namespace IntAlk_I.Models
{
    public class FormValues
    {
        [Required(ErrorMessage = "Szám megadása kötelező"), Display(Name = "Első szám:")]
        public double Szam1 { get; set; }
        [Required(ErrorMessage = "Szám megadása kötelező"), Display(Name = "Második szám:")]
        public double Szam2 { get; set; }
        [Required]
        public required string Muvelet { get; set; }
    }
}
