using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace examen.Models
{
    public class Envrioment
    {
        public Guid EnvriomentId { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Campo {0} es obligatorio")]
        [Display(Name = "Codigo")]
        public string Code { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Campo {0} es obligatorio")]
        [Display(Name = "Piso")]

        public string Floor { get; set; }


        [ForeignKey("InstructorId")]
        [Display(Name = "Instructor")]
        public Guid InstructorId { get; set; }

        public virtual Instructor? Instructor { get; set; }


        public virtual ICollection<Student>? Students { set; get; }

        [ForeignKey("TorreId")]
        [Display(Name = "Torre")]
        public Guid TorreId { get; set; }

        public virtual Torre? Torre { get; set; }



    }
}