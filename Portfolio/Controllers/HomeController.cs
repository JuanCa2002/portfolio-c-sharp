using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Services;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProyectRepository proyectRepository;
        private readonly IConfiguration configuration;
        private readonly IEmailService emailService;

        public HomeController(ILogger<HomeController> logger, IProyectRepository proyectRepository,
            IConfiguration configuration, IEmailService emailService)
        {
            _logger = logger;
            this.proyectRepository = proyectRepository;
            this.configuration = configuration;
            this.emailService = emailService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var applicationName = configuration.GetValue<string>("ApplicationName");
            _logger.LogInformation($"The application name is {applicationName}");
            _logger.LogInformation("Getting Index View");

            var proyects = proyectRepository.GetProyects().Take(3).ToList();
            HomeIndexViewModel homeIndexViewModel = new ()
            {
                Proyects = proyects
            };
            return View(homeIndexViewModel);
        }

        [HttpGet]
        public IActionResult Proyects ()
        {
            return View(proyectRepository.GetProyects());
        }

        [HttpGet]
        public IActionResult Contact ()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendForm(ContactViewModel contactViewModel)
        {
            await emailService.SendEmail(contactViewModel);
            return RedirectToAction("ThanksForSubmit");
        }

        [HttpGet]
        public IActionResult ThanksForSubmit()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
