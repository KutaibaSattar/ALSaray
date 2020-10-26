
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Types;
using Microsoft.SqlServer.Types.SqlHierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALSaray.Controllers.Resource
{
    public class MyDBAcctsResources
    {
     
        public int acctId { get; set;}
        public string acctKey { get; set;}
        public string acctName { get; set;}
       
        
        public string nodePath { get; set;}

              
        //public string path { get; set;}
        
        //public byte[] Node { get; set; }

        



    }
}
