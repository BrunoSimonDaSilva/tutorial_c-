using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using selecao.Models;
using selecao.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace selecao.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServiceSelecao _serviceSelecao;

        public HomeController(ILogger<HomeController> logger, IServiceSelecao serviceSelecao )
        {
            _logger = logger;
            _serviceSelecao = serviceSelecao;
        }

        public IActionResult Index()
        {
            return View(_serviceSelecao.GetAll());
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit([Bind("Id,Nome,Titulos")] Time time)
        {
            return View(_serviceSelecao.GetById(time.Id));
        }
        public IActionResult Delete(int? id)
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateConfirm([Bind("Id,Nome,Titulos")] Time time)
        {
            _serviceSelecao.Create(time);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteConfirm(int id)
        {
            _serviceSelecao.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult EditConfirm(Time time)
        {
            Time del = _serviceSelecao.GetById(time.Id);
            _serviceSelecao.Update(time);
            return RedirectToAction("Index");
        }


    }
}
