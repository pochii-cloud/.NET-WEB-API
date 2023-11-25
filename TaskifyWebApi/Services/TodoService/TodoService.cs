using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TaskifyWebApi.Data;
using TaskifyWebApi.Models;

namespace TaskifyWebApi.Services.TodoService
{
    public class TodoService : ITodo
    {
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

        public async Task<List<Todo>> DeleteTodo(int id)
        {
            var todoRemove = await _dbContext.Todos.FirstOrDefaultAsync(x => x.id == id);

            if(todoRemove != null)
            {
                _dbContext.Todos.Remove(todoRemove);
                await _dbContext.SaveChangesAsync();
            }

            var todoList = await _dbContext.Todos.ToListAsync();
            return todoList;

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

        public async Task<List<Todo>> UpdateTodo(int id,Todo todo)
        {
            var todo_to_update = await  _dbContext.Todos.FirstOrDefaultAsync(t=>t.id == id);
            if(todo_to_update != null)
            {
                todo_to_update.title = todo.title;
                todo_to_update.description = todo.description;
                todo_to_update.iscomplete = todo.iscomplete;

                await _dbContext.SaveChangesAsync();
            }
          
            return await _dbContext.Todos.ToListAsync();
        }
    }
}
