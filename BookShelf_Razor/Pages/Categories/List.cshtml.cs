using BookShelf_Razor.Data;
using BookShelf_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShelf_Razor.Pages.Categories
{
    public class ListModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;

        public List<category> CategoryList { get; set; }

        public ListModel(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet()
        {
            CategoryList = dbContext.Categories.ToList();
        }
    }
}
