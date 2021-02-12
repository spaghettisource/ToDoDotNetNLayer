using Core;
using System.Threading.Tasks;
using ToDoDotNet.Data;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ToDoDbContext context;

        public UnitOfWork(ToDoDbContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
