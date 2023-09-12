using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banking_WebAPI_Practice_Project.Models {
    public class Customer {
        public int ID { get; set; }
        [StringLength(30)] public string Name { get; set; } = String.Empty;
        public int  CardCode { get; set; }
        public int PinCode { get; set; }
        [Column(TypeName = "datetime")]public DateTime LastTransactionDate { get; set; }
        [Column(TypeName = "datetime")]public DateTime CreationDate { get; set;} = DateTime.Now;
        [Column(TypeName = "datetime")]public DateTime ModifiedDate { get; set;}
    }
}
