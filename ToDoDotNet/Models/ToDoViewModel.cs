using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoDotNet.Models
{
    public class ToDoViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreationDate { get; set; }
    }
}