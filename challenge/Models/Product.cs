using System.ComponentModel.DataAnnotations;

namespace challenge.Models{
    public class Product{

       [Key]
        public int id {get; set;}

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo de conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo de conter entre 3 e 60 caracteres")]
        public string Title{get; set;}

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(1024, ErrorMessage = "Este campo de conter no máximo 1024 caracteres")]       
        public string Description{get; set;}

        [Required(ErrorMessage = "Este campo é obrigatório")] 
        [Range(1, int.MaxValue, ErrorMessage = "Este campo é obrigatório")] 
        public decimal Price{get; set;}

        [Required(ErrorMessage = "Este campo é obrigatório")] 
        [Range(1, int.MaxValue, ErrorMessage = "Categoria inválida")] 
        public int CategoryId{get; set;}

        public Category Category{get; set;}
    }
}