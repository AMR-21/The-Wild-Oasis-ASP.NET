using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheWildOasis.Data;
using TheWildOasis.Models;

namespace TheWildOasis.Pages.Cabins
{
    public class EditModel : PageModel
    {
        private readonly TheWildOasis.Data.TheWildOasisContext _context;

        public EditModel(TheWildOasis.Data.TheWildOasisContext context)
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

            var cabin =  await _context.Cabins.FirstOrDefaultAsync(m => m.Id == id);
            if (cabin == null)
            {
                return NotFound();
            }
            Cabin = cabin;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Cabin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CabinExists(Cabin.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CabinExists(int id)
        {
            return _context.Cabins.Any(e => e.Id == id);
        }
    }
}
