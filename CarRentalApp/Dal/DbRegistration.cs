using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class DbRegistration
    {
    
        private readonly string? cars;
        private readonly string? Busses;
        private readonly string? Hiaces;
        public static string? ConnectionString { get; set; } = "mongodb://localhost:27017/";
        public static string? DatabaseName { get; set; } = "CarRental";
        public static string? CarCollection { get; set; } = "Cars";
        public static string? BusCollection { get; set; } = "Busses";
        public static string? HiaceCollection { get; set; } = "Hiaces";
        public static string? CarPackageCollection { get; set; } = "CarPackages";
        public static string? BusPackageCollection { get; set; } = "BusPackages";
        public static string? HiacePackageCollection { get; set; } = "HiacePackages";
        public static string? UserCollection { get; set; } = "Users";

        public static string? AboutCollection { get; set; } = "AboutShowroom";
        public static string? AddressCollection { get; set; } = "ShowroomAddresses";
        public static string? ProfileCollection { get; set; } = "ShowroomProfiles";
        public static string? SocialCollection { get; set; } = "SocialReferences";
        public static string? ContactCollection { get; set; } = "ContactShowrooms";
        public static string? ProfileImageCollection { get; set; } = "ShowroomImage";
    }

}
