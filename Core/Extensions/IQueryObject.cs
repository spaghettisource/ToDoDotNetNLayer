using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public interface IQueryObject
    {
        string Title { get; set; }
        string Sort { get; set; }
        string SortDir { get; set; }
        int Page { get; set; }
        byte PageSize { get; set; }
    }
}
