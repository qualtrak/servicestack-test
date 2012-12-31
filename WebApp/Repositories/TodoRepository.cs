namespace WebApp.Repositories
{
    using System;
    using System.Data;
    using System.Collections.Generic;
    using ServiceStack.OrmLite;
    using WebApp.Model;
    
    public class TodoRepository
    {
        private readonly IDbConnection _db;

        public TodoRepository(IDbConnectionFactory dbFactory)
        {
            this._db = dbFactory.OpenDbConnection();
        }

        public ICollection<Todo> GetByIds(Guid[] ids)
        {
            ICollection<Todo> result = this._db.GetByIds<Todo>(ids);
            return result;
        }

        public ICollection<Todo> GetAll()
        {
            ICollection<Todo> result = this._db.Select<Todo>();
            return result;
        }

        public Todo Store(Todo todo)
        {
            try
            {
                Todo result;                
                bool isNew = todo.Id == Guid.Empty ? true : false;
                
                if (isNew)
                {
                    result = todo;
                    result.Id = Guid.NewGuid();
                }
                else
                {
                    result = this._db.GetById<Todo>(todo.Id);  
                    
                    if (result == null)
                    {
                        throw new Exception("The given Todo Id is unknown or non-existent!");
                    }
                    
                    result.Content = todo.Content;
                    result.Order = todo.Order;
                    result.Done = todo.Done;               
                }
                
                this._db.Save<Todo>(result);
                
                
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }

        public void DeleteByIds(ICollection<Guid> ids)
        {
            this._db.DeleteByIds<Todo>(ids);
        }
    }
}