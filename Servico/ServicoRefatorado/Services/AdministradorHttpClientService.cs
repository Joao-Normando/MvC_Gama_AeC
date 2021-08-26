using gama_aec.Models;
using gama_aec.Servico.ServicoRefatorado.Interfaces;
using Microsoft.Extensions.Configuration;

namespace gama_aec.Servico.ServicoRefatorado.Services
{
    public class AdministradorHttpClientService : HttpClientService<Administrador>, IAdministradorHttpClientService
    {
        const string SERVICE_URL = "AdministradoresAPI";
        //Se precisarmos aumentar a quantidade de parametros do contrutor do serviço
        //IConfiguration será resolvido automaticamente pela injeção de 
        public AdministradorHttpClientService(IConfiguration configuration) : base(configuration, SERVICE_URL)
        {
        }

        //Qualquer outro metodo individual do administradores referente requisção http
    }
}