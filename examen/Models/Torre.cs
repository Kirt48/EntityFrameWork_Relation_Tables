
using System.ComponentModel.DataAnnotations;

namespace examen.Models
{
    public class Torre
    {

        public Guid TorreId { get; set; }

        [Required(ErrorMessage = "Campo {0} obligatorio")]
        [Display(Name ="Zona")]
        public string Zone { get; set; }

        public virtual ICollection<Envrioment>? Envrioments { get; set; }
    }

}