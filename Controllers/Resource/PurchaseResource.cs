using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ALSaray.Models;

namespace ALSaray.Controllers.Resource
{
    public class PurchaseResource
    {

        public int? purchId { get; set; }

        [Required]
        [StringLength(255)]
        public string purchNo { get; set; }

        [StringLength(255)]
        public string pMethod { get; set; }

        public Single? gtotal { get; set; }


        // Master table
        public int? accId { get; set; }





        public ICollection<PurchaseItemsResource> purchaseItems { get; set; }
        public PurchaseResource()
        {
            purchaseItems = new Collection<PurchaseItemsResource>();

        }




    }
}
