namespace WebApp.Repositories
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using WebApp.Model;
    
    public class TodoRepository
    {
        List<Todo> _todos = new List<Todo>();
        
        public List<Todo> GetByIds(long[] ids)
        {
            return this._todos.Where(x => ids.Contains(x.Id)).ToList();
        }

        public List<Todo> GetAll()
        {
            return _todos;
        }

        public Todo Store(Todo todo)
        {
            var existing = _todos.FirstOrDefault(x => x.Id == todo.Id);

            if (existing == null)
            {
                var newId = this._todos.Count > 0 ? this._todos.Max(x => x.Id) + 1 : 1;
                todo.Id = newId;
            
            }

            this._todos.Add(todo);

            return todo;
        }

        public void DeleteByIds(params long[] ids)
        {
            this._todos.RemoveAll(x => ids.Contains(x.Id));
        }
    }
}