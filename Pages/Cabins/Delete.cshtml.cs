using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheWildOasis.Data;
using TheWildOasis.Models;

namespace TheWildOasis.Pages.Cabins
{
    public class DeleteModel : PageModel
    {
        private readonly TheWildOasis.Data.TheWildOasisContext _context;

        public DeleteModel(TheWildOasis.Data.TheWildOasisContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cabin Cabin { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cabin = await _context.Cabins.FirstOrDefaultAsync(m => m.Id == id);

            if (cabin == null)
            {
                return NotFound();
            }
            else
            {
                Cabin = cabin;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cabin = await _context.Cabins.FindAsync(id);
            if (cabin != null)
            {
                Cabin = cabin;
                _context.Cabins.Remove(Cabin);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
