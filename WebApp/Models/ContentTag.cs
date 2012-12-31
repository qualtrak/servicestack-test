namespace WebApp.Models
{
    using System;
    using ServiceStack.DataAnnotations;

    public class ContentTag
    {
        public Guid Id { get; set; }

        [Index]
        [BelongTo(typeof(Content))]
        public Guid ContentId { get; set; }

        [Index]
        [BelongTo(typeof(Tag))]
        public Guid TagId { get; set; }
    }
}