using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        //Data Annotations
        [Required(ErrorMessage ="Digite o Nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage ="Digite o Email")]
        [EmailAddress(ErrorMessage ="Digite um Email valido")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Digite o Celular")]
        [Phone(ErrorMessage ="O celular informado não é valido")]
        public string Celular { get; set; } 
    }
}
