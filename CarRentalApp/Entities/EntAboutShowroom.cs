using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class EntAboutShowroom
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [Required]
        public string? ShowroomName { get; set; }

        [Required]
        public string? OwnerName { get; set; }

        [Required]
        public string? Description { get; set; }
        [Required]
        public TimeOnly? OpeningTime { get; set; }
        [Required]
        public TimeOnly? ClosingTime { get; set; }

        [Required]
        public bool Status { get; set; } = true;

        public string UserId { get; set; } = string.Empty;

        [Required]
        public string? Address { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? Country { get; set; } = "Pakistan";
        public string? GoogleMapsLink { get; set; }
        [Required]
        public string? ContactPhone { get; set; }
        public string? ContactEmail { get; set; }

         
        public string? FacebookUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? Logo { get; set; } 
        public string? Cover { get; set; }






    }
}