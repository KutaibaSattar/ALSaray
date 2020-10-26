using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ALSaray.Controllers.Resource
{
    public class PurchaseItemsResource
    {
      
        public int? purchItemId { get; set; }

        // Master table
        public int? prodId { get; set; }
        //public Products Products { get; set; }

        // Master table
        public int? purchId { get; set; }

        //[JsonIgnore]
        //public Purchase Purchase { get; set; }
        public int? quantity { get; set; }

        public Single? price { get; set; }

        public Single? total { get; set; }
    }
}
