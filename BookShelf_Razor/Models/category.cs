﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BookShelf_Razor.Models
{

    public class category
    {
        [Key]

        [DisplayName("Category Order")]
        public int Id { get; set; }
        [Required]

        [MaxLength(30)]


        public string Name { get; set; }


        [DisplayName("Display Order")] //this is called Annotation
        [Range(1, 100, ErrorMessage = "Display Order must be between 1 and 100")]
        public int DisplayOrder { get; set; }


    }

}
