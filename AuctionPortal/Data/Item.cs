using System.ComponentModel.DataAnnotations;

namespace AuctionPortal.Data
{
    public class Item
    {



        public int Id { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public string Category{ get; set; }
        [Required]
        public decimal Price{ get; set; }
        [Required]
        public bool IsSpecial{ get; set; }
        
    }
}