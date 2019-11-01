using System.ComponentModel.DataAnnotations;

namespace challenge.Models{
    public class Category{

        [Key]

        public int id {get; set;}

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo de conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo de conter entre 3 e 60 caracteres")]

        public string Name{get; set;}
    }
}