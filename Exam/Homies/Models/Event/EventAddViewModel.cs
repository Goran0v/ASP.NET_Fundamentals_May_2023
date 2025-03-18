using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static Homies.Common.ApplicationConstants;
using Type = Homies.Data.Type;

namespace Homies.Models.Event
{
    public class EventAddViewModel
    {
        public EventAddViewModel()
        {
            this.Types = new HashSet<Type>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(EventConstants.NameMaxLength, MinimumLength = EventConstants.NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(EventConstants.DescriptionMaxLength, MinimumLength = EventConstants.DescriptionMinLength)]
        public string Description { get; set; } = null!;

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int TypeId { get; set; }

        public virtual ICollection<Type> Types { get; set; } = null!;
    }
}
