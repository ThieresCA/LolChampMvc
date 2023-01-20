using LolChampMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList;
namespace LolChampMvc.Controllers
{
    public class PersonagensController : Controller
    {
        private readonly string Endpoint = "https://ddragon.leagueoflegends.com/cdn/13.1.1/data/pt_BR/champion.json";
        private readonly HttpClient _httpClient = null;

        public PersonagensController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(Endpoint);
        }

        public async Task<IActionResult> Index()
        {
 
            try
            {
                var response = await _httpClient.GetAsync(Endpoint);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var personagem = JsonConvert.DeserializeObject<Personagem>(content);
                    return View(personagem.Data.Values);
                }
                else
                {
                    ModelState.AddModelError(null, "Erro ao processar os dados");
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw ex;
            }

            return View();
        }
    }
}
