using System.ComponentModel.DataAnnotations;

namespace gama_aec.Models
{
    public class Material : Entidade
    {

        [Required]
        [MaxLength(150)]
        public string Nome { get; set; }

        [Required]
        public int AlunoId { get; set; }

    }
}