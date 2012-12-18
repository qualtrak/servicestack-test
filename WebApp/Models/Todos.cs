namespace WebApp.Model
{
    using System;
    using System.Collections.Generic;
    using ServiceStack.ServiceHost;

    // REST Resource DTO
    [Route("/todos")]
    [Route("/todos/{Ids}")]
    public class Todos : IReturn<List<Todo>>
    {
        public Guid[] Ids { get; set; }

        public Todos(params Guid[] ids)
        {
            this.Ids = ids;
        }
    }
}