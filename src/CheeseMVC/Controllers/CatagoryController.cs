using CheeseMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Controllers
{
    public class CatagoryController
    {
        private readonly CheeseDbContext context;
        public CatagoryController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }
    }
}
