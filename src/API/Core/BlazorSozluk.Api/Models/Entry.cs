﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Api.Domain.Models
{
    public class Entry:BaseEntity
    {
        public string Subject { get; set; }
        public string Content { get; set; } 
        public Guid CreateById { get; set; }
        public virtual User CretedBy { get; set; }
        public virtual ICollection<EntryComment> EntryComments { get;set }
        public virtual ICollection<EntryVote> EntryVotes { get; set }
    }
}