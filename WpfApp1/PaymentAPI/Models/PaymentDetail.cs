using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentAPI.Models
{
    public class PaymentDetail
    {
        [Key]
        public int PaymentDetailID { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string CardOwnerName { get; set; }
        [Column(TypeName = "nvarchar(16)")]
        public string CardNumber { get; set; }
        ////mm/yy
        //[Column(TypeName = "nvarchar(5)")]
        //public string ExpirationDate { get; set; }
        //[Column(TypeName = "nvarchar(3)")]
        //public string SecurityCode { get; set; }
        //[Key] [Required] public int deptid { get; set; }
        //[StringLength(50)] public String dname { get; set; }
        //[StringLength(50)] public String location { get; set; }

    }
}
