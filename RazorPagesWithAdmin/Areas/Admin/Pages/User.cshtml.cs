using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesWithAdmin.Areas.Admin.Pages
{
    public class UserModel : PageModel
    {
        [FromRoute]
        public int? Id { get; set; }

        [FromRoute]
        public string? Name { get; set; }

        public void OnGet()
        {
        }
    }
}
