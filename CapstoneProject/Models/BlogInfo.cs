using System.ComponentModel.DataAnnotations;

namespace BlogTracker.Models
{
    public class BlogInfo
    {
        [Key]
        public int BlogInfoId { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength(50)]
        public string Subject { get; set; }
        [Required]
        public DateTime DateOfCreation { get; set; }
        [Required]
        [Url]
        public string BlogUrl { get; set; }
        [Required]
        [EmailAddress]
        public string EmpEmailId { get; set; }
    }
}
