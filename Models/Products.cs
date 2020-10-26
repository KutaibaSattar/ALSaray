using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ALSaray.Models
{
    public class Products
    {
        [Key]
        public int prodId { get; set; }

       [Required]
       [StringLength(255)]
        public string prodName { get; set; }

       
       
        //Master Table
        public int? catId { get; set; }
        public Category category { get; set; }


        [ForeignKey("prodId")]
        public ICollection<PurchaseItems> PurchaseItems { get; set; }



    }
}