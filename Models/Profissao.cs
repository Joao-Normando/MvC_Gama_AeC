using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using gama_aec.Models;

namespace gama_aec.Models
{    public class Profissao
    {
        public int Id {get; set;}

        public string Descricao{get; set;}

        public ICollection <Candidato> candidatos {get; set;} 
        
    }
}