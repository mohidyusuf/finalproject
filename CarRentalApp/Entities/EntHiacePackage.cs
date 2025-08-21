using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class EntHiacePackage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string? HiaceId { get; set; } = string.Empty;
        public string BusinessId { get; set; } = string.Empty;

        [Required] public decimal Price { get; set; }
        [Required] public string? Duration { get; set; }

        public bool WithDriver { get; set; }
        public string? HiaceMake { get; set; }
        public string? HiaceImage { get; set; }
        public string? HiaceModel { get; set; }
    }
}
