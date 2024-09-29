using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheWildOasis.Pages.Account
{
  public class IndexModel : PageModel
  {

    // private readonly UserManager<IdentityUser> _manager;
    private readonly SignInManager<IdentityUser> _manager;

    public IndexModel(SignInManager<IdentityUser> manager)
    {
      _manager = manager;
    }
    public IActionResult OnGet()
    {

      if (!_manager.IsSignedIn(User))
      {
        return RedirectToPage("/Account/Login", new { area = "Identity" });
      }
      // Add your logic here

      return Page();
    }
  }
}