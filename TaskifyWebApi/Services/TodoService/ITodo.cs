using TaskifyWebApi.Models;

namespace TaskifyWebApi.Services.TodoService
{
    public interface ITodo
    {
        Task<List<Todo>> GetAllTodos();

        Task<Todo> GetSingleTodo(int id);

        Task<List<Todo>> AddTodo(string title, string description, bool iscomplete);

        List<Todo> DeleteTodo(int id);

        List<Todo> UpdateTodo(int id,Todo todo);
    }
}