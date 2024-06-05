using BookShelf_Razor.Data;
using BookShelf_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShelf_Razor.Pages.Categories
{

    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;

        public category category { get; set; }

        public DeleteModel(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                category = dbContext.Categories.Find(id);



            }
        }

        public IActionResult OnPost()
        {
            

                category? obj = dbContext.Categories.Find(category.Id);
                if (obj == null)
                {
                    return NotFound();
                }
                dbContext.Remove(obj);
                dbContext.SaveChanges();
                TempData["Success"] = "Category Deleted Successfully";
            return RedirectToPage("List");


            
          
        }

    }
}
