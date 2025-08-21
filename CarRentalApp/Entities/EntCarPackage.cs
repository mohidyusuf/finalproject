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
    public class EntCarPackage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }


        public string BusinessId { get; set; } = string.Empty;
        public string CarId { get; set; } = string.Empty;

        [Required] public decimal Price { get; set; }
        public bool WithDriver { get; set; }
        [Required] public string Duration { get; set; }


        public string CarMake { get; set; }
        public string CarImage { get; set; }
        public string CarModel { get; set; }
        public string Cartype { get; set; }
    }
}
