using System.ComponentModel.DataAnnotations;

namespace MyWebApiCoreService.Models
{
    public class CUSTOMER
    {
        [Key]
        public int CustId { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public string City { get; set; }
        public bool Status { get; set; }
    }
}
