using System.ComponentModel.DataAnnotations;

namespace MyCongressApp.Models
{
    public class Bill
    {
        [Required]
        public Guid Id { get; set; }
        public int CongressNumber { get; set; }
        public string? BillType { get; set; }
        public string? BillNumber { get; set; }
        public string? Title { get; set; }
        public string? Summary { get; set; }
        public string? Sponsor { get; set; }
        public DateTime? IntroducedDate { get; set; }
    }
}
