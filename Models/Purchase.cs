using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace ALSaray.Models
{
    public class Purchase
    {
        
        [Key]
        public int purchId { get; set; }

        [Required]
        [StringLength(255)]
        public string purchNo { get; set; }

        [StringLength(255)]
        public string pMethod { get; set; }

        public Single? gtotal { get; set; }


        // Master table
        [Required]
        public int? accId { get; set; }
        public MyDbAcct dbAcct { get; set; }

        public DateTime? LastUpdatedDate { get; set; }





        [ForeignKey("purchId")]
        public ICollection<PurchaseItems> purchaseItems {get;set;}
       
        public Purchase()
        {
                purchaseItems = new Collection<PurchaseItems>();

        }



    }
}
