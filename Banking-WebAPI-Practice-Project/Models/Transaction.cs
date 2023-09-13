using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banking_WebAPI_Practice_Project.Models {
    public class Transaction {
        public int ID { get; set; }
        public int AccountID { get; set; }
        public virtual Account? Account { get; set; }
        [Column(TypeName = "decimal(11,2)")] public decimal PreviousBalance { get; set; }
        [StringLength(1)] public string TransactionType { get; set; }
        [Column(TypeName = "decimal(11,2)")] public decimal NewBalance { get; set; }
        [StringLength(80)]public string? Description { get; set; }
        [Column(TypeName = "datetime")]public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
