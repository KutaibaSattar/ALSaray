using System.Reflection.Emit;
namespace ALSaray.Controllers.Resource
{
    public class PurchaseQuereyResource
    {   
        public int? acctId { get; set;}

        public string SortBy { get; set; }  

        public bool IsSortAscending { get; set; }
        
    }
}