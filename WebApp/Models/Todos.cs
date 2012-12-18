namespace WebApp.Model
{
    using System.Collections.Generic;
    using ServiceStack.ServiceHost;

    // REST Resource DTO
    [Route("/todos")]
    [Route("/todos/{Ids}")]
    public class Todos : IReturn<List<Todo>>
    {
        public long[] Ids { get; set; }
        public Todos(params long[] ids)
        {
            this.Ids = ids;
        }
    }
}