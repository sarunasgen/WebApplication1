using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public int RandomSkaicius { get; set; } = 50;
        [BindProperty]
        public List<Company> Companies { get; set; }
        public List<ActorFilmDetail> ActorsAndTheirFilms { get; set; }

        private readonly IDatabaseService _databaseService;
        public IndexModel(ILogger<IndexModel> logger, IDatabaseService databaseService)
        {
            _logger = logger;
            _databaseService = databaseService;
        }

        public void OnGet(string vardas)
        {
            Companies = new List<Company>();
            Company k1 = new Company
            {
                Country = "Lietuva",
                Name = "VCS",
                Director = "Director"
            };
            Company k2 = new Company
            {
                Country = "Latvia",
                Name = "Random",
                Director = "Bad Director"
            };
            Companies.Add(k1);
            Companies.Add(k2);

            ActorsAndTheirFilms = (_databaseService.GetActorFilmDetails()).ToList();

        }
    }
}
