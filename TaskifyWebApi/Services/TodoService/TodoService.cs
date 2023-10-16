﻿using TaskifyWebApi.Models;

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
                    title="todo two",
                    description ="description two",
                    iscomplete=false
                },


            };

        public List<Todo> AddTodo(string title, string description, bool iscomplete)
        {
            var new_todo = new Todo
            {
                id = TodoList.Count + 1,
                title = title,
                description = description,
                iscomplete = false
            };
            
            TodoList.Add(new_todo);

            return TodoList;
        }

        public List<Todo> DeleteTodo(int id)
        {
            TodoList.RemoveAll(x => x.id == id);
            return TodoList;
        }

        public List<Todo> GetAllTodos()
        {
            return TodoList;
        }

        public Todo GetSingleTodo(int id)
        {
            var single_todo = TodoList.Find(x => x.id == id);
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
