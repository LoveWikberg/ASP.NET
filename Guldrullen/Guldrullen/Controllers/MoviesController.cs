using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Guldrullen.Models;
using Guldrullen.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Guldrullen.Controllers
{
    public class MoviesController : Controller
    {
        GuldrullenContext context;

        public MoviesController(GuldrullenContext context)
        {
            this.context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            //MoviesIndexVM viewModel = new MoviesIndexVM();
            //viewModel.Comfirmation = (string)TempData["Comfirmation"];

            //var models = context.ListMovies();
            //return View(models);

            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MoviesCreateVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            context.AddMovie(viewModel);
            //TempData["Comfirmation"] = "The movie has been added.";
            return RedirectToAction(nameof(MoviesController.Index));
        }
    }
}
