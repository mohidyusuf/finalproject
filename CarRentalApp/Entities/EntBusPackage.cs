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
    public class EntBusPackage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string BusId { get; set; } = string.Empty;
        public string BusinessId { get; set; } = string.Empty;

        [Required] public decimal Price { get; set; }
        [Required] public string Duration { get; set; }

        public bool WithDriver { get; set; }
        public string BusMake { get; set; }
        public string BusImage { get; set; }
        public string BusModel { get; set; }
    }
}
