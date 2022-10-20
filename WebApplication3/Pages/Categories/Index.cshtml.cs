using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication3.Data;
using WebApplication3.Model;

namespace WebApplication3.Pages.Categories
{
    public class IndexModel : PageModel
    {

        private readonly ApplicationDbContext _db;
        public IEnumerable<Category> Categories { get; set; }
    
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Categories = _db.Category;

        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var cat = _db.Category.Where(u => u.Id == id).FirstOrDefault();

            _db.Category.Remove(cat);
            await _db.SaveChangesAsync();

            TempData["success"] = "Category delete successfully";

            return RedirectToPage();
        }


    }
}
