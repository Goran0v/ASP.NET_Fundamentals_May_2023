using System.ComponentModel.DataAnnotations;

namespace ChatApplication.Models.Chat
{
    public class MessageViewModel
    {
        [Required]
        public string Sender { get; set; } = null!;

        [Required]
        [MaxLength(255)]
        public string MessageText { get; set; } = null!;
    }
}
