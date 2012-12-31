namespace WebApp.Model
{
    using System;
    using System.Collections.Generic;
    using ServiceStack.ServiceHost;

    // REST Resource DTO
    [Route("/todos")]
    [Route("/todos/{Ids}")]
    public class Todos : IReturn<ICollection<Todo>>
    {
        public ICollection<Guid> Ids { get; set; }

        public Todos(ICollection<Guid> ids)
        {
            this.Ids = ids;
        }
    }
}