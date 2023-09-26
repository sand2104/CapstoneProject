using System.ComponentModel.DataAnnotations;

namespace BlogTracker.Models
{
    public class AdminInfo
    {
        [Key]
        public int AdminInfoId { get; set; }
        [Required]
        [EmailAddress]
        public string EmailId { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
