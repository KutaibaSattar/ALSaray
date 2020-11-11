using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ALSaray.Models;

namespace ALSaray.Controllers.Resource
{
    public class SavePurchaseResource
    {

        public int? purchId { get; set; }

        [Required]
        [StringLength(255)]
        public string purchNo { get; set; }

        [StringLength(255)]
        public string pMethod { get; set; }

        public Single? gtotal { get; set; }

         public int? accId { get; set; }

       
       public MyDbAcct dbAcct { get; set; }

        public DateTime? LastUpdatedDate { get; set; }





        public ICollection<PurchaseItemsResource> purchaseItems { get; set; }
        public SavePurchaseResource()
        {
            purchaseItems = new Collection<PurchaseItemsResource>();

        }




    }
}
