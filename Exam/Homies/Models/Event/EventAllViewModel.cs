using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Homies.Models.Event
{
    public class EventAllViewModel
    {
        public EventAllViewModel()
        {
            this.JoinedUsers = new HashSet<IdentityUser>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{yyyy-MM-dd H:mm}")]
        public DateTime Start { get; set; }

        public string Organiser { get; set; } = null!;

        public string Type { get; set; } = null!;

        public virtual ICollection<IdentityUser> JoinedUsers { get; set; } = null!;
    }
}
