using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ALSaray.Models
{
    public class Category
    {
        [Key]    
         public int catId { get; set; }

        [Required]
        [StringLength(255)]
        public string catName { get; set; }


        
       
        [ForeignKey("catId")]
        public ICollection<Products> Products { get; set; }

        public Category()
        {
            Products = new Collection<Products>();


        }

    }
}