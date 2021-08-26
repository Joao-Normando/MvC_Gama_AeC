
using gama_aec.Models;
using gama_aec.Servico.ServicoRefatorado.Interfaces;
using Microsoft.Extensions.Configuration;

namespace gama_aec.Servico.ServicoRefatorado.Services
{
    public class MaterialHttpClientService : HttpClientService<Material>, IMaterialHttpClientService
    {
        const string SERVICE_URL = "MateriaisAPI";
        public MaterialHttpClientService(IConfiguration configuration) : base(configuration, SERVICE_URL)
        {
        }
    }
}