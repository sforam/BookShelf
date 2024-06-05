using BookShelf_Razor.Data;
using BookShelf_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShelf_Razor.Pages.Categories
{

	[BindProperties]
    public class EditModel : PageModel
    {
		private readonly ApplicationDbContext dbContext;

		public category category { get; set; }

		public EditModel(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public void OnGet(int? id)
		{
			if (id != null && id!=0)
			{
				category = dbContext.Categories.Find(id);



			}
		}

		public IActionResult OnPost()
		{
			if (ModelState.IsValid)
			{
				dbContext.Categories.Update(category);
				dbContext.SaveChanges();
				TempData["Success"] = "Category updated Successfully";
				return RedirectToPage("List");


			}
			return Page();
		}

	}
}
