namespace WebApp.Model
{
    using System;
    using ServiceStack.ServiceHost;

    [Route("/todos", "POST")]
    [Route("/todos/{Id}", "PUT")]
    public class Todo : IReturn<Todo>
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public int Order { get; set; }
        public bool Done { get; set; }
    }
}
