using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core;
using Core.Extensions;

namespace ToDoDotNet.Data
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ToDoDbContext context;

        public ToDoRepository(ToDoDbContext context)
        {
            this.context = context;
        }

        public async Task<ToDo> GetToDo(int id)
        {
            return await context.ToDos.FindAsync(id);
        }

        public void Add(ToDo vehicle)
        {
            context.ToDos.Add(vehicle);
        }

        public void Remove(ToDo vehicle)
        {
            context.ToDos.Remove(vehicle);
        }

        public async Task<QueryResult<ToDo>> GetToDos(ToDoQuery queryObj)
        {
            var result = new QueryResult<ToDo>();

            var query = context.ToDos.AsQueryable();

            query = query.ApplyFiltering(queryObj);

            var columnsMap = new Dictionary<string, Expression<Func<ToDo, object>>>()
            {
                ["Title"] = v => v.Title,
                ["Body"] = v => v.Body,
                ["CreationDate"] = v => v.CreationDate.ToString()
            };
            query = query.ApplyOrdering(queryObj, columnsMap);

            result.TotalItems = await query.CountAsync();

            query = query.ApplyPaging(queryObj);

            result.Items = await query.ToListAsync();

            return result;
        }

    }
}
