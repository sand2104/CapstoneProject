using System.ComponentModel.DataAnnotations;

namespace BlogTracker.Models
{
    public class EmpInfo
    {
        [Key]
        public int EmpInfoId { get; set; }
        [Required]
        [EmailAddress]
        public string EmailId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public DateTime DateOfJoining { get; set; }
        [Required]
        [Range(1000, 9999)]
        public int PassCode { get; set; }
    }
}
