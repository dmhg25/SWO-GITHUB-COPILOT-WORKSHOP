using System;
using System.Globalization;

namespace BikeShopAPI.Entities
{
    // Models a ride log signature, e.g. "17121903-START-END-ROUTE"
    public record RideLog(DateTime Date, string Start, string End, string Route)
    {
        // Parses a signature string into a RideLog record
        public static RideLog Parse(string signature)
        {
            // Expecting format: ddMMyyyy-START-END-ROUTE
            var parts = signature.Split('-');
            if (parts.Length != 4)
                throw new FormatException("Invalid RideLogSignature format.");

            if (!DateTime.TryParseExact(parts[0], "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
                throw new FormatException("Invalid date in RideLogSignature.");

            return new RideLog(date, parts[1], parts[2], parts[3]);
        }
    }
}
