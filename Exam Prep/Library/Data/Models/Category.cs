﻿using System.ComponentModel.DataAnnotations;

namespace Library.Data.Models
{
    public class Category
    {
        public Category()
        {
            this.Books = new HashSet<Book>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        public ICollection<Book> Books { get; set; } = null!;
    }
}
