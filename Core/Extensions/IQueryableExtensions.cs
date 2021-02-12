using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class IQueryableExtensions
    {
        private static string ASC = "ASC";
        private static string DESC = "DESC";

        public static IQueryable<ToDo> ApplyFiltering(this IQueryable<ToDo> query, ToDoQuery queryObj)
        {
            if (!String.IsNullOrEmpty(queryObj.Title))
                query = query.Where(v => v.Title == queryObj.Title);

            return query;
        }

        public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> query, IQueryObject queryObj, Dictionary<string, Expression<Func<T, object>>> columnsMap)
        {
            if (String.IsNullOrWhiteSpace(queryObj.Sort) || !columnsMap.ContainsKey(queryObj.Sort))
                return query;

            if (queryObj.SortDir == ASC)
                return query.OrderBy(columnsMap[queryObj.Sort]);
            else
                return query.OrderByDescending(columnsMap[queryObj.Sort]);
        }

        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, IQueryObject queryObj)
        {
            if (queryObj.Page <= 0)
                queryObj.Page = 1;

            if (queryObj.PageSize <= 0)
                queryObj.PageSize = 10;

            return query.Skip((queryObj.Page - 1) * queryObj.PageSize).Take(queryObj.PageSize);
        }
    }
}
