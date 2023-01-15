using System.ComponentModel.DataAnnotations;

namespace tumibankapp.Data
{
    public class Transactions
    {
        [Key]
        public int TransactionId { get; set; }
        [Required]
        public string SenderName { get; set; }
        [Required]
        public int SenderAccountNumber { get; set; }
        [Required]
        public string RecieverName { get; set; }
        [Required]
        public int RecieverAccountNumber { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal CurrentBalance { get; set; }
        public decimal PreviousBalance { get; set; }        
        public string TransactionStatus { get; set; }

        public bool IsCoperate { get; set; }
        public bool IsExternalTransfer { get; set; }
        public string RefrenceNumber { get; set; }




    }
}
