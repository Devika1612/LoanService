using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LoginService.Models
{
    public class LoanDetail
    {

        [Key]
        public int LNId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string LoanOwnerName { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Address { get; set; }
        [Required]
        [Column(TypeName = "varchar(5)")]
        public string LoanNumber { get; set; }
        [Required]
        [Column(TypeName = "varchar(7)")]
        public string LoanAmount { get; set; }
        [Required]
        [Column(TypeName = "varchar(2)")]
        public string LoanTerm { get; set; }
        [Required]
        [Column(TypeName = "varchar(5)")]
        public string LoanType { get; set; }
        [Required]
        [Column(TypeName = "varchar(15)")]
        public string LegalDocuments { get; set; }
    }
}
