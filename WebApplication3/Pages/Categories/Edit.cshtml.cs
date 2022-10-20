using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication3.Data;
using WebApplication3.Model;
namespace WebApplication3.Pages.Categories
{
    [IgnoreAntiforgeryToken]
    public class delete : PageModel
    {
        ApplicationDbContext _db;

        [BindProperty]
        public Category categories { get; set; }
    
        public delete(ApplicationDbContext db)
        {
            _db = db; 

     
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            categories = _db.Category.Where(u=>u.Id==id).FirstOrDefault();
            if (categories == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if(categories.Name == categories.DisplayOrder.ToString())
            {
                ModelState.AddModelError("categories.Name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
             
                _db.Category.Update(categories);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category updated successfully";

                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
