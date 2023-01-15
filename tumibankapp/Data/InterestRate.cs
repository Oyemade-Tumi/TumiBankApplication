
using System.ComponentModel.DataAnnotations;

namespace tumibankapp.Data
{
    public class InterestRate
    {
        [Key]    
        public int InterestRateId { get; set; }
        [Required]
        public double CurrentRate { get; set; }
        [Required]
        public double ApplyInterest { get; set; }
    }

}
