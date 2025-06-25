using System;

namespace BikeShopAPI.Entities
{
    public record RideLog(
        DateTime Date,
        string StartLocation,
        string EndLocation,
        string RouteName)
    {
        public static RideLog Parse(string signature)
        {
            // Expected format: ddMMyyyy-START-END-ROUTE
            var parts = signature.Split('-');
            if (parts.Length != 4)
                throw new FormatException("Invalid RideLogSignature format.");

            if (!DateTime.TryParseExact(parts[0], "ddMMyyyy", null, System.Globalization.DateTimeStyles.None, out var date))
                throw new FormatException("Invalid date format in RideLogSignature.");

            return new RideLog(
                date,
                parts[1],
                parts[2],
                parts[3]
            );
        }
    }
}
