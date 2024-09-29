using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheWildOasis.Models;

namespace TheWildOasis.Pages.Cabins
{
    public class CabinModel : PageModel
    {
        private readonly TheWildOasis.Data.TheWildOasisContext _context;

        public CabinModel(TheWildOasis.Data.TheWildOasisContext context)
        {
            _context = context;
        }

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
    }
}
