using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PawPos.Domain
{
    public class BaseEntity
    {
        [BsonId]
        public string Id { get; set; }
        public DateTime RecordDate { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}
