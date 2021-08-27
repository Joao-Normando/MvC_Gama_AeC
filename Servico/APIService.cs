using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using gama_aec.Models;
using Newtonsoft.Json;

namespace gama_aec.Servico
{
  public class APIService
  {

    public static async Task<List<Candidato>> GetProfissoes()
    {
      
      HttpClient http = new HttpClient();
      
      var response = await http.GetAsync("https://localhost:5001/Candidatos");
      if(response.IsSuccessStatusCode)
      {
        var resultado = response.Content.ReadAsStringAsync().Result;
        var candidatos = JsonConvert.DeserializeObject<List<Candidato>>(resultado);
        return candidatos;
      }

      return new List<Candidato>();
    }


    public static async Task<List<Candidato>> GetCandidatos()
    {
      HttpClient http = new HttpClient();
      var response = await http.GetAsync("https://localhost:5002/Candidatos");
      if(response.IsSuccessStatusCode)
      {
        var resultado = response.Content.ReadAsStringAsync().Result;
        var candidatos = JsonConvert.DeserializeObject<List<Candidato>>(resultado);
        return candidatos;
      }

      return new List<Candidato>();
    }

  }
}