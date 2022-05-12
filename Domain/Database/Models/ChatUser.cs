using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace telbot.Domain.Database.Models
{
    public class ChatUser:BaseEntity
    {
        public long ChatId{get;set;}
        public string Name{get;set;}
    }
}