using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.SqlServer.Types.SqlHierarchy;
using Microsoft.SqlServer.Types;
using ALSaray.Controllers.Resource;

namespace ALSaray.Models
{
    public class MyDbAcct
    {

        //private byte[] node;
        //private SqlHierarchyId nodeSql;

        [Key]
        public int acctId { get; set; }

        [Required]
        [StringLength(255)]
        public string acctName { get; set; }

       
        [ForeignKey("accId")]
        public ICollection<Purchase> Purchases { get; set; }

        [Required]
        [StringLength(255)]
        
        public string acctKey { get; set; }

        public HierarchyId nodePath { get; set; }

        //[NotMapped]
        //public string path
        //{
        //    get => nodePath.ToString();
        //    set => HierarchyId.Parse(nodePath.ToString());

            
        //}



        //[NotMapped]
        //public byte[] Node
        //{
        //    get => nodePath.ToByteArray();
        //    set => nodePath.ToByteArray();

        //}







    }


}
