namespace WebApp.Models
{
    using System;
    using ServiceStack.ServiceHost;

    [Route("{account}/tags", "POST")]
    [Route("{account}/tags/{id}", "PUT")]
    public class Tag
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid Account { get; set; }
    }

}