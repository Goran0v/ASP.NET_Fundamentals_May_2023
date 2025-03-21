﻿using System.ComponentModel.DataAnnotations;
using static Forum_App.Common.EntityValidations.Post;

namespace Forum_App.Data.Models
{
    public class Post
    {
        public Post()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; } = null!;
    }
}
