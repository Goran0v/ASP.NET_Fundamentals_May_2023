﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Homies.Common.ApplicationConstants.EventConstants;

namespace Homies.Data
{
    public class Event
    {
        public Event()
        {
            this.EventsParticipants = new HashSet<EventParticipant>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Organiser))]
        public string OrganiserId { get; set; } = null!;

        [Required]
        public virtual IdentityUser Organiser { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        [Required]
        [ForeignKey(nameof(Type))]
        public int TypeId { get; set; }

        [Required]
        public virtual Type Type { get; set; } = null!;

        public virtual ICollection<EventParticipant> EventsParticipants { get; set; } = null!;
    }
}