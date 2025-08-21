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
    public class EntHiace
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [Required] public string Make { get; set; } = string.Empty;
        [Required] public string Model { get; set; } = string.Empty;
        [Required] public int Year { get; set; }
        [Required] public string Color { get; set; } = string.Empty;
        [Required] public string RegistrationNumber { get; set; } = string.Empty;
        public string? FuelType { get; set; }
        public string? Image { get; set; }
        public string? Transmission { get; set; }
        public string? HiaceDescription { get; set; }
        public string SeatingCapacity { get; set; }
    
        public bool Status { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsAC { get; set; }
        public bool HasRearCamera { get; set; }
        public bool WitCarrier { get; set; }
        public string CargoCapacityKg { get; set; }
        public string? HiaceType { get; set; }
        public string BusinessId { get; set; } = string.Empty;
    }


}
