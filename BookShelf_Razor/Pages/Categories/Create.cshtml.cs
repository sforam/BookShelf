using BookShelf_Razor.Data;
using BookShelf_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShelf_Razor.Pages.Categories
{

	[BindProperties]
	public class CreateModel : PageModel

    {
        private readonly ApplicationDbContext dbContext;
       
        public category category { get; set; }

        public CreateModel(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet()
        {
        }

		public IActionResult OnPost()
        {
            dbContext.Categories.Add(category);
            dbContext.SaveChanges();
            TempData["Success"] = "Category Created Successfully";
            return RedirectToPage("List");

        }


    }
}
