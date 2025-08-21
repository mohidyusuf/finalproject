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

    public class EntCar
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [Required] public string Make { get; set; } = string.Empty;
        [Required] public string Model { get; set; } = string.Empty;
        [Required] public int Year { get; set; }
        
        [Required] public string? Image { get; set; }
        public string Color { get; set; } = string.Empty;
        [Required] public string RegistrationNumber { get; set; } = string.Empty;

        public string BusinessId { get; set; } = string.Empty;

        public string? FuelType { get; set; }
        public string? CarDescription { get; set; }
        public string? Transmission { get; set; }

        public string SeatingCapacity { get; set; }
        [Required] public int EngineCapacity { get; set; }

        public bool Status { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool HasAC { get; set; }
        public bool HasGPS { get; set; }
        public int Doors { get; set; }
        public int BootSpaceLiters { get; set; }
        public string? CarType { get; set; }
    }








}

