using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Data;

namespace CheeseMVC.ViewModels
{
    public class AddCheeseViewModel
    {
        [Required]
        [Display(Name = "Cheese Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must give your cheese a description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Catagory")]
        public int CatagoryID { get; set; }

        public List<SelectListItem> Catagories { get; set; }
        public AddCheeseViewModel() { }
        public AddCheeseViewModel(IEnumerable<CheeseCatagory> catagories)
        {
            Catagories = new List<SelectListItem>();


            // <option value="0">Hard</option>
            foreach (CheeseCatagory catagory in catagories)
            {
                Catagories.Add(new SelectListItem
                {
                    Value = catagory.ID.ToString(),
                    Text = catagory.Name.ToString()
                    
                });
            }

            /*Catagories.Add(new SelectListItem
            {
                Value = ((int)Catagories.Fake).ToString(),
                Text = CheeseType.Fake.ToString()
            }); */

        }
    }
}
