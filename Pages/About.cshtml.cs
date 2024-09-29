using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheWildOasis.Data;
using TheWildOasis.Models;

namespace TheWildOasis.Pages
{
  public class AboutModel : PageModel
  {

    private readonly TheWildOasisContext _context;
    public AboutModel(TheWildOasisContext context)
    {
      _context = context;
    }

    public IList<Cabin> Cabins { get; set; } = default!;
    public async Task OnGetAsync()
    {

      Cabins = await _context.Cabins.ToListAsync();
    }
  }
}