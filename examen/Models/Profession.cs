using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace examen.Models
{
    public class Profession
    {
        public Guid ProfessionId { set; get; }
        [Required(ErrorMessage = "Campo {0} es obligatorio")]
        [Display(Name = "Nombre")]
        public string Name { set; get; }


        public virtual ICollection<Instructor>? Instructors { get; set; }
    }
}
