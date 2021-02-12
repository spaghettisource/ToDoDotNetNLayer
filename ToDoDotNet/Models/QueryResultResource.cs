using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoDotNet.Models
{
    public class QueryResultResource<T>
    {
            
        public int TotalItems { get; set; }
        public IEnumerable<T> Items { get; set; }
    
}
}