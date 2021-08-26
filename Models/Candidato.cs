using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using aec_gama_api.Models;

namespace gama_aec.Models
{
    [Table("candidatos")]
    public class Candidato
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nome", TypeName = "varchar")]
        [Required]
        [MaxLength(150)]
        public string Nome { get; set; }

        [Column("cpf", TypeName = "varchar")]
        [Required]
        [MaxLength(15)]
        public string Cpf { get; set; }

        [Column("genero", TypeName = "varchar")]
        [MaxLength(15)]
        public string Genero { get; set; }

        [Column("nascimento", TypeName = "date")]
        [Required]
        public DateTime Nascimento { get; set; }

        [Column("telefone", TypeName = "varchar")]
        [MaxLength(15)]
        public string Telefone { get; set; }

        [Column("email", TypeName = "varchar")]
        [Required]
        [MaxLength(150)]
        public string Email { get; set; }

        [Column("profissao", TypeName = "varchar")]
        [MaxLength(150)]
        public string Profissao { get; set; }

        [Column("estadoCivil", TypeName = "varchar")]
        [MaxLength(150)]
        public string EstadoCivil { get; set; }

        [Column("cep", TypeName = "varchar")]
        [Required]
        [MaxLength(9)]
        public string Cep { get; set; }

        [Column("logradouro", TypeName = "varchar")]
        [Required]
        [MaxLength(150)]
        public string Logradouro { get; set; }

        [Column("numero", TypeName = "int")]
        [Required]
        public int Numero { get; set; }


        [Column("bairro", TypeName = "varchar")]
        [Required]
        [MaxLength(150)]
        public string Bairro { get; set; }

        [Column("cidade", TypeName = "varchar")]
        [Required]
        [MaxLength(150)]
        public string Cidade { get; set; }

        [Column("estado", TypeName = "varchar")]
        [Required]
        [MaxLength(2)]
        public string Estado { get; set; }



        [Column("profissao_id")]
        [Required]
        [ForeignKey("ProfissaoId")]
        public int ProfissaoId { get; set; }
        public Profissao Profissoes { get; set; }
    }
}