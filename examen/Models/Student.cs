using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace examen.Models
{
    public class Student
    {

        public Guid StudentId { get; set; }
        [Required(ErrorMessage = "Campo {0} es obligatorio")]
        [Display(Name = "Documento")]
        public string Document { get; set; }
        [Required(ErrorMessage = "Campo {0} es obligatorio")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Campo {0} es obligatorio")]
        [Display(Name = "Correo")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo {0} es obligatorio")]
        [Display(Name = "Telefono")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Campo {0} es obligatorio")]
        [Display(Name = "Direccion")]
        public string Address { get; set; }


        [ForeignKey("EnvriomentId")]
        public Guid EnvriomentId { get; set; }
        public virtual Envrioment? Envrioment { get; set; }




        [ForeignKey("ProgramaId")]
        public Guid ProgramaId { get; set; }
        public virtual Programa? Programa { get; set; }





    }
}