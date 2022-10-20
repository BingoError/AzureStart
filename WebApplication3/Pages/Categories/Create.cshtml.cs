using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication3.Data;
using WebApplication3.Model;
namespace WebApplication3.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        ApplicationDbContext _db;


        public Category categories { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db; 
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if(categories.Name == categories.DisplayOrder.ToString())
            {
                ModelState.AddModelError("categories.Name", "The DisplayOrder cannot exactly match the Name.");
            }
         
            if (ModelState.IsValid)
            {
                await _db.Category.AddAsync(categories);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category created successfully"; 
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
