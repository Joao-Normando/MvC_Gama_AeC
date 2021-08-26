using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using aec_gama_api.Models;
using Newtonsoft.Json;

namespace gama_aec.Servico
{
    public class ProfissaoServico
    {
        public static async Task<List<Profissao>> Todos(int pagina = 1)
        {
            using (var http = new HttpClient())
            {
                using (var response = await http.GetAsync($"{Program.ProfissoesAPI}/pais?page={pagina}"))
                {
                    if(!response.IsSuccessStatusCode) return new List<Profissao>();

                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Profissao>>(json);
                }
            }
        }

        public static async Task<Profissao> BuscaPorId(int id)
        {
            using (var http = new HttpClient())
            {
                using (var response = await http.GetAsync($"{Program.ProfissaosAPI}/pais/{id}"))
                {
                    if(!response.IsSuccessStatusCode) return null;
                    return JsonConvert.DeserializeObject<Profissao>(await response.Content.ReadAsStringAsync());
                }
            }
        }

        public static async Task<Profissao> Salvar(Profissao pai)
        {
            using (var http = new HttpClient())
            {
                if(Convert.ToInt32(pai.Id) == 0)
                {
                    using (var response = await http.PostAsJsonAsync($"{Program.ProfissaosAPI}/pais", pai))
                    {
                        string retorno = await response.Content.ReadAsStringAsync();
                        if(!response.IsSuccessStatusCode)
                        {
                            Console.WriteLine("========================");
                            Console.WriteLine(retorno);
                            Console.WriteLine("========================");
                            throw new Exception("Erro ao incluir na API");
                        }
                        return JsonConvert.DeserializeObject<Profissao>(retorno);
                    }
                }
                else
                {
                    using (var response = await http.PutAsJsonAsync($"{Program.ProfissaosAPI}/pais/{pai.Id}", pai))
                    {
                        if(!response.IsSuccessStatusCode) throw new Exception("Erro ao atualizar na API");
                        return JsonConvert.DeserializeObject<Profissao>(await response.Content.ReadAsStringAsync());
                    }
                }
            }
        }

        public static async Task ExcluirPorId(int id)
        {
            using (var http = new HttpClient())
            {
                using (var response = await http.DeleteAsync($"{Program.ProfissaosAPI}/pais/{id}"))
                {
                    if(!response.IsSuccessStatusCode) throw new Exception("Erro ao excluir da API");
                }
            }
        }
    }
}