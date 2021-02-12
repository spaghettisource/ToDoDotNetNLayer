using System.Threading.Tasks;

namespace Core
{
    public interface IToDoRepository
    {
        Task<ToDo> GetToDo(int id);
        void Add(ToDo vehicle);
        void Remove(ToDo vehicle);
        Task<QueryResult<ToDo>> GetToDos(ToDoQuery filter);
    }
}
