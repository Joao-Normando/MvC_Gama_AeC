using System.ComponentModel.DataAnnotations;

namespace gama_aec.Models
{
    public abstract class Entidade
    {
        [Key]
        public int Id { get; set; }
    }
}