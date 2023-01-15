using System.ComponentModel.DataAnnotations;

namespace tumibankapp.Data
{
    public class OverDraft
    {
        [Key]
        public int OverDraftId { get; set; }
        [Required]
        public decimal Overdraftfee { get; set; }
        [Required]
        public decimal DeductOverdraftFee { get; set; }
    }
}
