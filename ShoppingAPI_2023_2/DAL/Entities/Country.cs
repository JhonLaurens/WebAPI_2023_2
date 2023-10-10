using System.ComponentModel.DataAnnotations;

namespace ShoppingAPI_2023_2.DAL.Entities
{
    public class Country : AuditBase
    {
        [Display(Name = "País")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "Es campo {0} es obligatorio")]

        public string Name { get; set; }




    }
}
