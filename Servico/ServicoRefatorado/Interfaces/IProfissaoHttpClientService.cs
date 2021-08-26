using aec_gama_api.Models;
using gama_aec.Models;

namespace gama_aec.Servico.ServicoRefatorado.Interfaces
{
    public interface IPaiHttpClientService : IHttpClientService<Profissao>
    {
         //contrato especializado para Profissao
    }
}