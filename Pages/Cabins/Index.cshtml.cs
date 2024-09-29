using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using TheWildOasis.Models;

namespace TheWildOasis.Pages.Cabins
{
    public class IndexModel : PageModel
    {
        private readonly TheWildOasis.Data.TheWildOasisContext _context;

        public IndexModel(TheWildOasis.Data.TheWildOasisContext context)
        {
            _context = context;
        }

        public IList<Cabin> Cabins { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? Capacity { get; set; }

        public string[] filters = ["all", "small", "medium", "large"];
        public string ActiveFilter { get; set; } = "all"; // Default value

        public async Task OnGetAsync()
        {
            var baseCabins = await _context.Cabins.ToListAsync();

            switch (Capacity)
            {
                case "small":
                    Cabins = baseCabins.Where(cabin => cabin.MaxCapacity <= 3 && cabin.MaxCapacity > 1).ToList();
                    break;
                case "medium":
                    Cabins = baseCabins.Where(cabin => cabin.MaxCapacity <= 7 && cabin.MaxCapacity > 3).ToList();
                    break;
                case "large":
                    Cabins = baseCabins.Where(cabin => cabin.MaxCapacity > 7).ToList();
                    break;
                default:
                    Cabins = baseCabins;
                    break;
            }
        }
    }
}
