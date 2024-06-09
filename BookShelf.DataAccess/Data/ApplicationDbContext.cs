
using BookShelf.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BookShelf.DataAccess.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        
        {
            
        }
		public DbSet<category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<category>().HasData(
                new category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new category { Id = 2, Name = "SciFic", DisplayOrder = 2 },
                new category { Id = 3, Name = "Thriller", DisplayOrder = 3 }
                );



            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Echoes of Eternity",
                    Author = "Mark Twain",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam.\r\n\r\nNunc feugiat mi a tellus consequat imperdiet.",
                    ISBN = "ETO9999001",
                    ListPrice = 150,
                    Price = 140,
                    Price50 = 130,
                    Price100 = 120,
                    CategoryId=1,
                    ImageUrl=""
                },
                new Product
                {
                    Id = 2,
                    Title = "Mystery of the Blue Moon",
                    Author = "Alice Walker",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam.\r\n\r\nNunc feugiat mi a tellus consequat imperdiet.",
                    ISBN = "MBM777777701",
                    ListPrice = 45,
                    Price = 40,
                    Price50 = 35,
                    Price100 = 30,
                    CategoryId = 1,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 3,
                    Title = "Whispers of the Forest",
                    Author = "Emily Bronte",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam.\r\n\r\nNunc feugiat mi a tellus consequat imperdiet.",
                    ISBN = "WTF5555501",
                    ListPrice = 60,
                    Price = 55,
                    Price50 = 50,
                    Price100 = 45,
                    CategoryId = 3,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 4,
                    Title = "Shadows of the Night",
                    Author = "George Orwell",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam.\r\n\r\nNunc feugiat mi a tellus consequat imperdiet.",
                    ISBN = "SON3333333301",
                    ListPrice = 80,
                    Price = 75,
                    Price50 = 70,
                    Price100 = 65,
                    CategoryId = 2,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 5,
                    Title = "Journey Through Time",
                    Author = "H.G. Wells",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam.\r\n\r\nNunc feugiat mi a tellus consequat imperdiet.",
                    ISBN = "JTT1111111101",
                    ListPrice = 35,
                    Price = 30,
                    Price50 = 28,
                    Price100 = 25,
                    CategoryId = 3,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 6,
                    Title = "Secrets of the Ocean",
                    Author = "Jules Verne",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam.\r\n\r\nNunc feugiat mi a tellus consequat imperdiet.",
                    ISBN = "SOT000000001",
                    ListPrice = 50,
                    Price = 45,
                    Price50 = 42,
                    Price100 = 40,
                    CategoryId = 1,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 7,
                    Title = "Glimmer of Hope",
                    Author = "Leo Tolstoy",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam.\r\n\r\nNunc feugiat mi a tellus consequat imperdiet.",
                    ISBN = "GOH000000002",
                    ListPrice = 55,
                    Price = 50,
                    Price50 = 45,
                    Price100 = 40,
                    CategoryId = 3,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 8,
                    Title = "Winds of Change",
                    Author = "Virginia Woolf",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam.\r\n\r\nNunc feugiat mi a tellus consequat imperdiet.",
                    ISBN = "WOC000000003",
                    ListPrice = 65,
                    Price = 60,
                    Price50 = 55,
                    Price100 = 50,
                    CategoryId = 2,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 9,
                    Title = "Flames of Passion",
                    Author = "Charlotte Bronte",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam.\r\n\r\nNunc feugiat mi a tellus consequat imperdiet.",
                    ISBN = "FOP000000004",
                    ListPrice = 70,
                    Price = 65,
                    Price50 = 60,
                    Price100 = 55,
                    CategoryId = 1,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 10,
                    Title = "Echoes of the Past",
                    Author = "Jane Austen",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam.\r\n\r\nNunc feugiat mi a tellus consequat imperdiet.",
                    ISBN = "EOP000000005",
                    ListPrice = 75,
                    Price = 70,
                    Price50 = 65,
                    Price100 = 60,
                    CategoryId = 2,
                    ImageUrl = ""
                }



                );

        }
    }
}
