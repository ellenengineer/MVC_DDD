using System.Diagnostics;
using ATS.Domain.Interfaces;
using ATS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ATS.WebApp.Controllers
{
    public class HomeController : Controller
    {
 
        private readonly IRepository<Veiculo> _veiculoRepository;

        public HomeController(IRepository<Veiculo> veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }
 
        public IActionResult Index()
        {
            return View(_veiculoRepository.GetAll());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View( );
        }
    }
}