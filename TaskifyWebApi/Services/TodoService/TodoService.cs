using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TaskifyWebApi.Data;
using TaskifyWebApi.Models;

namespace TaskifyWebApi.Services.TodoService
{
    public class TodoService : ITodo
    {
        static List<Todo> TodoList = new List<Todo>
            {
                new Todo
                {
                    id = 1,
                    title="todo one",
                    description ="description one",
                    iscomplete=false
                },
                 new Todo
                {
                    id = 2,
                    title="todo test",
                    description ="description two",
                    iscomplete=false
                },


            };
        private DataContext _dbContext;
        public TodoService(DataContext dbcontext)
        {
           _dbContext = dbcontext;
        }

        public async Task<List<Todo>> AddTodo(string title, string description, bool iscomplete)
        {
            var new_todo = new Todo
            {
                title = title,
                description = description,
                iscomplete = false
            };
            
            await _dbContext.Todos.AddAsync(new_todo);
            
            await _dbContext.SaveChangesAsync();

            var todos=await _dbContext.Todos.ToListAsync();
            return todos;
        }

        public List<Todo> DeleteTodo(int id)
        {
            TodoList.RemoveAll(x => x.id == id);
            return TodoList;
        }

        public async Task<List<Todo>> GetAllTodos()
        {
            return await _dbContext.Todos.ToListAsync();
        }

        public async Task<Todo> GetSingleTodo(int id)
        {
            var single_todo = await _dbContext.Todos.FirstOrDefaultAsync(todo => todo.id == id);
            return single_todo;
        }

        public List<Todo> UpdateTodo(int id,Todo todo)
        {
            var todo_to_update = TodoList.Find(x => x.id == id);
            todo_to_update.title = todo.title;
            todo_to_update.description = todo.description;
            todo_to_update.iscomplete = todo.iscomplete;
            return TodoList;
        }
    }
}
