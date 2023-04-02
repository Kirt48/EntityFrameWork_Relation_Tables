using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace examen.Models
{
    public class Instructor
    {

        public Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Campo {0} es obligatorio")]
        [Display(Name ="Documento")]
        public string Document { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Campo {0} es obligatorio")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Campo {0} es obligatorio")]
        [Display(Name = "Correo electronico")]
        public string Email { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Campo {0} es obligatorio")]
        [Display(Name = "Telefono")]
        public string Phone { get; set; }


        [ForeignKey("ProfessionId")]
        [Display(Name = "Profesion")]
        public Guid ProfessionId { get; set; }
        
        public virtual Profession? Profession { get; set; }

        public virtual ICollection<Envrioment>? Envrioments { set; get; } 

    }
}