using gama_aec.Models;

namespace gama_aec.Servico.ServicoRefatorado.Interfaces
{
    public interface IAlunoHttpClientService : IHttpClientService<Candidato>
    {
         //contrato especializado para Candidato
    }
}