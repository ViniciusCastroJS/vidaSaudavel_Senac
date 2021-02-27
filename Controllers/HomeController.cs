using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Hotsite.Models;

namespace Hotsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Interesse cad)
        {

            if (String.IsNullOrEmpty(cad.Email) || 
                String.IsNullOrEmpty(cad.Nome) || 
                String.IsNullOrEmpty(cad.Mensagem))
            {
                ViewBag.MessageSucess = "";
                ViewBag.MessageError = "Preencha todos os campos.";
                return View("Index");
            }

            try
            {
                DatabaseService dbs = new DatabaseService();
                dbs.CadastraInteresse(cad);
                ViewBag.MessageSucess = "Cadastrado com Sucesso";
                ViewBag.MessageError = "";
                return View("Index",cad);
            }
            catch
            {               
                ViewBag.MessageSucess = "";
                ViewBag.MessageError = "Erro no Cadastro. Tente mais tarde.";
                return View("Index");
            }
        }

    }
}
