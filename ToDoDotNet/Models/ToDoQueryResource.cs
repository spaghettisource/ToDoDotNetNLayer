using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoDotNet.Models
{
    public class ToDoQueryResource
    {
            public string Title { get; set; }
        public string Sort { get; set; } = "Title";
            public string SortDir { get; set; }
            public int Page { get; set; }
            public byte PageSize { get; set; }        
    }
}