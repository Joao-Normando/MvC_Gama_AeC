using gama_aec.Models;
using Microsoft.Extensions.Configuration;

namespace gama_aec.Servico.ServicoRefatorado.Services
{
    public class CandidatoHttpClientService : HttpClientService<Candidato> , ICandidatoHttpClientService
    {
        const string SERVICE_URL = "CandidatoAPI";
        public CandidatoHttpClientService(IConfiguration configuration) : base(configuration, SERVICE_URL)
        {
        }
    }
}