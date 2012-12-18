namespace WebApp.Model
{
    using ServiceStack.DataAnnotations;
    using ServiceStack.ServiceHost;

    [Route("/todos", "POST")]
    [Route("/todos/{Id}", "PUT")]
    public class Todo : IReturn<Todo>
    {
        [AutoIncrement]
        public long Id { get; set; }
        public string Content { get; set; }
        public int Order { get; set; }
        public bool Done { get; set; }
    }
}
