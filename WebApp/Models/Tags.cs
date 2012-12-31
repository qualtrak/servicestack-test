namespace WebApp.Models
{
    using System;
    using System.Collections.Generic;
    using ServiceStack.ServiceHost;

    [Route("{account}/tags", "GET")]
    public class Tags : IReturn<ICollection<Tag>>
    {
        public Tags(ICollection<Guid> tagIds)
        {
            this.TagIds = tagIds;
        }

        public ICollection<Guid> TagIds { get; set; }

        public string Account { get; set; }
    }
}