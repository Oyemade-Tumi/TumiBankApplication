using System.ComponentModel.DataAnnotations;

namespace tumibankapp.Data
{
    public class BankAccountTbl
    {
        [Key]
        public int AccountId { get; set; }
        public int AccountNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        //[Required]
        public string LastName { get; set; }
        //[Required]
        public string EmailAddress { get; set; }
        //[Required]
        public string PhoneNumber { get; set; }
        //[Required]
        public bool IsCorporate { get; set; }
        //[Required]
        public string AccountType { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime ClosedDate { get; set;}
    }
}
