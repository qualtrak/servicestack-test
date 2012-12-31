namespace WebApp.Models
{
    using System;
    using System.Collections.Generic;
    using ServiceStack.DataAnnotations;

    public class Content
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public DateTime CreatedAt { get; set; }

        [Index]
        [BelongTo(typeof(Account))]
        public Guid AccountId { get; set; }

        [Index]
        [BelongTo(typeof(Service))]
        public Guid ServiceId { get; set; }

        // Ignore properties

        [Ignore]
        public ICollection<string> NewTags { get; set; }

        [Ignore]
        public ICollection<Guid> Tags { get; set; }

        [Ignore]
        public IDictionary<Guid, string> TagsLookup { get; set; }
    }
}

