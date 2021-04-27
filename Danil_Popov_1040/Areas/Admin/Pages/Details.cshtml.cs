using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Danil_Popov_1040.DAL.Data;
using Danil_Popov_1040.DAL.Entities;

namespace Danil_Popov_1040.Areas.Admin.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly Danil_Popov_1040.DAL.Data.ApplicationDbContext _context;

        public DetailsModel(Danil_Popov_1040.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Dish Dish { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dish = await _context.Dishes
                .Include(d => d.DishGroup).FirstOrDefaultAsync(m => m.DishId == id);

            if (Dish == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
