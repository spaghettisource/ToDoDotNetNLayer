using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    [Table("ToDo")]
    class ToDo
    {
            public int Id { get; set; }

            [Required]
            [StringLength(255)]
            public string Title { get; set; }

            public string Body { get; set; }

            public DateTime TimeCreated { get; set; }
        }
    }
}
