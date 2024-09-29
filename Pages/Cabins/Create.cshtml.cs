using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheWildOasis.Data;
using TheWildOasis.Models;

namespace TheWildOasis.Pages.Cabins
{
    public class CreateModel : PageModel
    {
        private readonly TheWildOasis.Data.TheWildOasisContext _context;

        public CreateModel(TheWildOasis.Data.TheWildOasisContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Cabin Cabin { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cabins.Add(Cabin);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
