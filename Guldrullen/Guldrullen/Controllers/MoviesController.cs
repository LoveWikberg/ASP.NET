using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Guldrullen.Models.Entities;
using Guldrullen.Models;

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
        [HttpGet]
        public IActionResult Index()
        {
            MovieDisplayVM viewModel = new MovieDisplayVM();
            viewModel.Search = (string)TempData["Search"];

            if (viewModel.Search == null)
                viewModel.ListViewModels = context.ListMovies("");
            else
                viewModel.ListViewModels = context.ListMovies(viewModel.Search);

            return View(viewModel);

            #region Test (bra egentligen)
            //else if (viewModel.DisplayAction)
            //    viewModel.ListViewModels = context.ListMovies("Action");

            //else if (viewModel.DisplayRomance)
            //    viewModel.ListViewModels = context.ListMovies("Romance");
            //context.ListMovies("Action").CopyTo(viewModel.ListViewModels, 0);
            //context.ListMovies("Romance").CopyTo(viewModel.ListViewModels, 1);
            //if (!viewModel.DisplayAction)
            // Array.Copy(context.ListMovies("Romance"), viewModel.ListViewModels, context.ListMovies("Romance").Length);
            // viewModel.ListViewModels = context.ListMovies("Action");
            // if (!viewModel.DisplayAction)
            //   Array.Copy(context.ListMovies("Action"), viewModel.ListViewModels, context.ListMovies("Action").Length);
            #endregion
        }

        [HttpPost]
        public IActionResult Index(MovieDisplayVM viewModel)
        {
            TempData["Search"] = viewModel.Search;
            return RedirectToAction(nameof(MoviesController.Index));
        }

        public IActionResult Review()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(MovieCreateVM viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            context.AddMovie(viewModel);
            return RedirectToAction(nameof(MoviesController.Index));
        }

        public IActionResult Reviews()
        {
            return View();
        }
    }
}
