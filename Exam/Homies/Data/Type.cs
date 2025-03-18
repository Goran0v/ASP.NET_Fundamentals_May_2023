using System.ComponentModel.DataAnnotations;
using static Homies.Common.ApplicationConstants.TypeConstants;

namespace Homies.Data
{
    public class Type
    {
        public Type()
        {
            this.Events = new HashSet<Event>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Event> Events { get; set; } = null!;
    }
}
