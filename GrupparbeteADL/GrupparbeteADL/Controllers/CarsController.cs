using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GrupparbeteADL.Models;
using GrupparbeteADL.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GrupparbeteADL.Controllers
{
    public class CarsController : Controller
    {

        EastwindContext context;

        public CarsController(EastwindContext context)
        {
            this.context = context;
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            var models = context.ListCars();
            return View(models);
        }

        [HttpGet]
        public IActionResult Create()
        {
            DisplayCreateVM v = new DisplayCreateVM();
            v.ListViewModels = context.ListCars();
            return View(v);
        }

        [HttpPost]
        public IActionResult Create(CarsCreateVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            
            context.AddCar(viewModel);
            return RedirectToAction(nameof(CarsController.Create));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = context.GetCarForEdit(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CarsEditVM viewModel, int id)
        {
            if(!ModelState.IsValid)
            {
                return View(viewModel);
            }
            context.EditCar(viewModel, id);
            return RedirectToAction(nameof(CarsController.Create));
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction(nameof(CarsController.Create));
            }
            context.RemoveCar(id);
            return RedirectToAction(nameof(CarsController.Create));
        }

    }
}
