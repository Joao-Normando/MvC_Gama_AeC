
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Net.Http;using gama_aec.Servicos;
using System.Collections.Generic;
using Newtonsoft.Json;
using gama_aec.Models;
using gama_aec;

namespace gama_aec.Servicos
  {

      
  
public class ApiService
  {
    public static async Task<List<Candidato>> GetCandidatos()
    {
      HttpClient http = new HttpClient();
      var response = await http.GetAsync($"{Program.ApiHost}/candidatos");
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