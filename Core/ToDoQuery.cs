using Core.Extensions;

namespace Core
{
    public class ToDoQuery : IQueryObject
    {
        public string Title { get; set; }
        public string Sort { get; set; } = "Title";
        public string SortDir { get; set; }
        public int Page { get; set; }
        public byte PageSize { get; set; }
    }
}