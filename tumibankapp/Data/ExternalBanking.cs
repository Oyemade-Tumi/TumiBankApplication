using System.ComponentModel.DataAnnotations;

namespace tumibankapp.Data
{
    public class ExternalBanking
    {
        [Key]
        public int ExternalTransferId { get; set; }
        //[Required]
        public string BankName { get; set; }
        public string BankAccountName { get; set; }   
        public string BankAddress { get; set; }
        public int BankAccountNumber { get; set; }
        public int BankSortCode { get; set; }
    }
}
