
using System.ComponentModel.DataAnnotations;

namespace gama_aec.Models
{
    public class Administrador : Entidade
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}