using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace examen.Models
{
    public class Programa
    {
        public Guid ProgramaId { get; set; }
        [Required(ErrorMessage = "Campo {0} es obligatorio")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        public virtual ICollection<Student>? Students { get; set; }
    }
}