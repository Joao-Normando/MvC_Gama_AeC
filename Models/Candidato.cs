using System.ComponentModel.DataAnnotations.Schema;

namespace gama_aec.Models
{
    [Table("candidatos")]
    public class Candidato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Nascimento { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public int UF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int ProfissaoId { get; set; }
        public Profissao Profissoes { get; set; }
    }
}