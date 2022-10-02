using ERYAZ.Service;
using ERYAZ.WebClient.Mappers;
using ERYAZ.WebClient.Models;
using ERYAZ.WebClient.Models.Film;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ERYAZ.WebClient.Controllers
{
    public class FilmController : BaseController
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IFilmService _filmService;
        public FilmController(IHttpClientFactory httpClientFactory, IFilmService filmService)
        {
            _httpClientFactory = httpClientFactory;
            _filmService = filmService;
        }

        public IActionResult List()
        {
            return View();
        }

        public async Task<IActionResult> Search(string title, short year, string kind)
        {
            var result = new Result();
            if (string.IsNullOrEmpty(title))
            {
                result.Messages.Add("Film Adı Zorunlu Alan");
                return Json(result);
            }

            var client = _httpClientFactory.CreateClient();
            var url = $"http://www.omdbapi.com/?apikey=2b94795c&s={title}&type={kind}&y={year}";

            var res = await client.GetAsync(url);
            if (res.IsSuccessStatusCode)
            {
                var body = await res.Content.ReadAsStringAsync();
                result.Item = JsonConvert.DeserializeObject<FilmSearchModel>(body);
            }
            else
            {
                result.Messages.Add($"Hata Oluştu. Durum : {res.StatusCode}");
            }

            return Json(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(FilmCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = FilmMapper.CreateDto(model);
                var result = await _filmService.CreateAsync(dto);

                if (result)
                {
                    return RedirectToAction(nameof(List));
                }
            }

            return View(model);
        }
    }
}
