﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Models
{
    public class IdentityUserBook
    {
        [ForeignKey(nameof(Collector))]
        public string CollectorId { get; set; } = null!;

        public IdentityUser Collector { get; set; } = null!;

        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }

        public Book Book { get; set; } = null!; 
    }
}

//CollectorId – a string, Primary Key, foreign key (required)
//• Collector – IdentityUser
//• BookId – an integer, Primary Key, foreign key (required)
//• Book – Book