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

        public async Task<IActionResult> Index(int? page)
        {
            var itensByPage = 10;
            var currentPage = page ?? 1;

            try
            {
                var response = await _httpClient.GetAsync(Endpoint);

                if (response.IsSuccessStatusCode)
                {

                        string content = await response.Content.ReadAsStringAsync();
                        var personagem = JsonConvert.DeserializeObject<Personagem>(content);
                        return View(await personagem.Data.Values.ToPagedListAsync(currentPage, itensByPage));
 
                }
                else
                {
                    ModelState.AddModelError(null, "Erro ao processar os dados");
                }


            }
            catch (Exception ex)
            {
                _ = ex.Message;
                throw ex;
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            List<Datum> personagens = new List<Datum>();
            var lowerId = id.ToLower();
            var upperId = char.ToUpper(lowerId[0]) + lowerId.Substring(1);
            var response = await _httpClient.GetAsync(Endpoint);
            try
            {
                string content = await response.Content.ReadAsStringAsync();
                var personagem = JsonConvert.DeserializeObject<Personagem>(content);
                var res = personagem.Data.Values.Where(c => c.Id.Contains(upperId)).FirstOrDefault();
                personagens.Add(res);
                return View(personagens);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
    }
}
