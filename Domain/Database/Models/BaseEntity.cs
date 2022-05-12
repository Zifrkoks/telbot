using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace telbot.Domain.Database.Models
{
    public class BaseEntity
    {
        public long id{get;set;}
        public DateTime CreactedAt {get;set;} = DateTime.UtcNow;
    }
}