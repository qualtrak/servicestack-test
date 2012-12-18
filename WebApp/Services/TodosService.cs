namespace WebApp.Services
{
    using ServiceStack.Common;
    using ServiceStack.ServiceInterface;  
    using WebApp.Model;
    using WebApp.Repositories;

    public class TodosService : Service
    {
        private readonly TodoRepository _repository;

        public TodosService(TodoRepository repository)
        {
            this._repository = repository;
        }

        // public TodoRepository Repository { get; private set; }  //Injected by IOC

        public object Get(Todos request)
        {
            return request.Ids.IsEmpty()
                ? this._repository.GetAll()
                : this._repository.GetByIds(request.Ids);
        }

        public object Post(Todo todo)
        {
            return this._repository.Store(todo);
        }

        public object Put(Todo todo)
        {
            return this._repository.Store(todo);
        }

        public void Delete(Todos request)
        {
            this._repository.DeleteByIds(request.Ids);
        }
    }

/*  Example calling above Service with ServiceStack's C# clients:

	var client = new JsonServiceClient(BaseUri);
	List<Todo> all = client.Get(new Todos());           // Count = 0

	var todo = client.Post(
	    new Todo { Content = "New TODO", Order = 1 });      // todo.Id = 1
	all = client.Get(new Todos());                      // Count = 1

	todo.Content = "Updated TODO";
	todo = client.Put(todo);                            // todo.Content = Updated TODO

	client.Delete(new Todos(todo.Id));
	all = client.Get(new Todos());                      // Count = 0

*/
}
