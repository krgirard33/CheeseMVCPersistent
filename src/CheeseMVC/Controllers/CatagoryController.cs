using CheeseMVC.Data;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Controllers
{
    public class CatagoryController : Controller
    {
        private readonly CheeseDbContext context;
        public CatagoryController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            IList<CheeseCatagory> catagories = context.Catagories.ToList();
            return View(catagories);
        }

        public IActionResult Add()
        {
            AddCatagoryViewModel addCatagoryViewModel = new AddCatagoryViewModel();
            return View(addCatagoryViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCatagoryViewModel addCatagoryViewModel)
        {
            if (ModelState.IsValid)
            {
                CheeseCatagory newCatagory = new CheeseCatagory
                {
                    Name = addCatagoryViewModel.Name
                };
                context.Catagories.Add(newCatagory);
                context.SaveChanges();

                return Redirect("/Catagory");
            }

            return View(addCatagoryViewModel);
        }

    }
}
