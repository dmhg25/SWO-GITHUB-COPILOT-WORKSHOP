using Microsoft.AspNetCore.Mvc;
using BikeShopAPI.Entities;
using System.Diagnostics;

namespace BikeShopAPI.Controllers
{
    [Route("api/bikeshop")]
    [ApiController]

    public class BikeShopController : ControllerBase
    {
        private readonly ILogger<BikeShopController> _logger;

        public BikeShopController(ILogger<BikeShopController> logger)
        {
            _logger = logger;
        }

        private static readonly List<BikeShop> BikeShops = new()
        {
            new BikeShop
            {
            Id = 1,
            Name = "Fast Wheels",
            Description = "Your one-stop shop for high-speed bikes.",
            Category = "Road",
            HasDelivery = true,
            AddressId = 101,
            Status = ShopStatus.Closed,
            ImageUrl = "https://example.com/images/fastwheels.jpg",
            Bikes = new List<Bike>
            {
                new() {
                Id = 1,
                Brand = "Cannondale",
                Model = "Synapse",
                Description = "A road bike that's light, stiff, fast and surprisingly comfortable.",
                Price = 2000,
                ForkTravel = 0,
                RearTravel = 0,
                WaterInBidon = 400,
                ShopId = 1
                },
                new() {
                Id = 2,
                Brand = "Specialized",
                Model = "Roubaix",
                Description = "A performance road bike that's both comfortable and fast.",
                Price = 2500,
                ForkTravel = 0,
                RearTravel = 0,
                WaterInBidon = 750,
                ShopId = 1
                }
            }
            },
            new BikeShop
            {
            Id = 2,
            Name = "Eco Riders",
            Description = "Environmentally friendly bikes for the eco-conscious rider.",
            Category = "Electric",
            HasDelivery = true,
            AddressId = 102,
            Status = ShopStatus.Open,
            ImageUrl = "https://example.com/images/ecoriders.jpg",
            Bikes = new List<Bike>
            {
                new() {
                Id = 3,
                Brand = "Gazelle",
                Model = "CityZen",
                Description = "A comfortable and fast electric bike for city riding.",
                Price = 3000,
                ForkTravel = 0,
                RearTravel = 0,
                WaterInBidon = 1000,
                ShopId = 2
                },
                new() {
                Id = 4,
                Brand = "Riese & Müller",
                Model = "Supercharger2",
                Description = "A high-performance electric bike for long-distance riding.",
                Price = 4000,
                ForkTravel = 0,
                RearTravel = 0,
                WaterInBidon = 1300,
                ShopId = 2
                }
            }
            },
            new BikeShop
            {
            Id = 3,
            Name = "City Cruisers",
            Description = "Perfect bikes for the urban jungle.",
            Category = "Urban",
            HasDelivery = false,
            AddressId = 103,
            Status = ShopStatus.Renovating,
            ImageUrl = "https://example.com/images/citycruisers.jpg",
            Bikes = new List<Bike>
            {
                new() {
                Id = 5,
                Brand = "VanMoof",
                Model = "S3",
                Description = "A stylish and smart bike for city riding.",
                Price = 1500,
                ForkTravel = 0,
                RearTravel = 0,
                WaterInBidon = 1500,
                ShopId = 3
                },
                new() {
                Id = 6,
                Brand = "Tern",
                Model = "GSD",
                Description = "A compact and powerful e-bike for city riding.",
                Price = 2000,
                ForkTravel = 0,
                RearTravel = 0,
                WaterInBidon = 1200,
                ShopId = 3
                }
            }
            },
            new BikeShop
            {
            Id = 4,
            Name = "Mountain Masters",
            Description = "For the thrill-seekers and mountain bikers.",
            Category = "Mountain",
            HasDelivery = true,
            AddressId = 104,
            Status = ShopStatus.Open,
            ImageUrl = "https://example.com/images/mountainmasters.jpg",
            Bikes = new List<Bike>
            {
                new() {
                Id = 7,
                Brand = "Trek",
                Model = "Fuel EX",
                Description = "A versatile trail bike for all-day adventures.",
                Price = 3500,
                ForkTravel = 150,
                RearTravel = 140,
                WaterInBidon = 800,
                ShopId = 4
                },
                new() {
                Id = 8,
                Brand = "Santa Cruz",
                Model = "Hightower",
                Description = "A high-performance mountain bike for aggressive riding.",
                Price = 4500,
                ForkTravel = 160,
                RearTravel = 150,
                WaterInBidon = 600,
                ShopId = 4
                }
            }
            },
            // Wheel Brothers Collection additions
            new BikeShop
            {
            Id = 5,
            Name = "Wheel Brothers Downtown",
            Description = "Flagship store with exclusive Wheel Brothers bikes and gear.",
            Category = "Flagship",
            HasDelivery = true,
            AddressId = 105,
            Status = ShopStatus.Open,
            ImageUrl = "https://example.com/images/wheelbrothers_downtown.jpg",
            Bikes = new List<Bike>
            {
                new() {
                Id = 9,
                Brand = "Wheel Brothers",
                Model = "Downtown Racer",
                Description = "Premium urban racer with custom Wheel Brothers components.",
                Price = 3200,
                ForkTravel = 0,
                RearTravel = 0,
                WaterInBidon = 1000,
                ShopId = 5
                },
                new() {
                Id = 10,
                Brand = "Wheel Brothers",
                Model = "Flagship MTB",
                Description = "Top-tier mountain bike for serious trail enthusiasts.",
                Price = 5000,
                ForkTravel = 170,
                RearTravel = 160,
                WaterInBidon = 900,
                ShopId = 5
                }
            }
            },
            new BikeShop
            {
            Id = 6,
            Name = "Wheel Brothers Riverside",
            Description = "Scenic riverside shop specializing in leisure and touring bikes.",
            Category = "Touring",
            HasDelivery = false,
            AddressId = 106,
            Status = ShopStatus.Closed,
            ImageUrl = "https://example.com/images/wheelbrothers_riverside.jpg",
            Bikes = new List<Bike>
            {
                new() {
                Id = 11,
                Brand = "Wheel Brothers",
                Model = "Tourer Elite",
                Description = "Comfortable touring bike for long scenic rides.",
                Price = 2800,
                ForkTravel = 40,
                RearTravel = 0,
                WaterInBidon = 1200,
                ShopId = 6
                },
                new() {
                Id = 12,
                Brand = "Wheel Brothers",
                Model = "Leisure Cruiser",
                Description = "Relaxed geometry cruiser for riverside paths.",
                Price = 1800,
                ForkTravel = 30,
                RearTravel = 0,
                WaterInBidon = 1500,
                ShopId = 6
                }
            }
            }
        };

        [HttpGet]
        public ActionResult<List<BikeShop>> GetAll()
        {
            _logger.LogInformation("GET all 🚲🚲🚲 NO PARAMS 🚲🚲🚲");

            return Ok(BikeShops);
        }

        // search shops by name
        [HttpGet("search")]
        public ActionResult<List<BikeShop>> SearchByName(string name)
        {
            // Normalize search term: trim, collapse spaces, lower
            string normalizedName = string.Join(" ", name.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)).ToLower();
            _logger.LogInformation($"GET all 🚲🚲🚲 with name: {normalizedName}");


            var results = BikeShops.Where(s =>
                !string.IsNullOrWhiteSpace(s.Name) &&
                string.Join(" ", s.Name.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)).ToLower().Contains(normalizedName)
            ).ToList();

            return Ok(results);
        }

        [HttpGet("{id}")]
        public ActionResult<BikeShop> GetById(int id)
        {
            _logger.LogInformation($"GET by ID 🚲🚲🚲 with ID: {id}");
            var bikeshop = BikeShops.Find(p => p.Id == id);

            if (bikeshop == null)
            {
                return NotFound();
            }

            return Ok(bikeshop);
        }

        [HttpPost]
        public ActionResult<BikeShop> Create(BikeShop bikeShop)
        {
            _logger.LogInformation($"POST 🚲🚲🚲 with Name: {bikeShop.Name}");
            BikeShops.Add(bikeShop);
            return CreatedAtAction(nameof(GetById), new { id = bikeShop.Id }, bikeShop);
        }
        [HttpPut("{id}")]
        public ActionResult Update(int id, BikeShop updatedBikeShop)
        {
            _logger.LogInformation($"PUT 🚲🚲🚲 with ID: {id} and Name: {updatedBikeShop.Name}");
            var bikeShop = BikeShops.Find(b => b.Id == id);
            if (bikeShop == null)
            {
                return NotFound();
            }

            bikeShop.Name = updatedBikeShop.Name;
            bikeShop.Description = updatedBikeShop.Description;
            bikeShop.Category = updatedBikeShop.Category;
            bikeShop.HasDelivery = updatedBikeShop.HasDelivery;
            bikeShop.AddressId = updatedBikeShop.AddressId;
            bikeShop.Status = updatedBikeShop.Status;
            bikeShop.Bikes = updatedBikeShop.Bikes;

            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _logger.LogInformation($"DELETE 🚲🚲🚲 with ID: {id}");
            var bikeShop = BikeShops.Find(b => b.Id == id);
            if (bikeShop == null)
            {
            return NotFound();
            }

            BikeShops.Remove(bikeShop);
            return NoContent();
        }

        [HttpPost("{id}/status")]
        public ActionResult UpdateShopStatus(int id, ShopStatus newStatus)
        {
            _logger.LogInformation($"POST 🚲🚲🚲 with ID: {id} to update status to {newStatus}");
            var bikeShop = BikeShops.Find(b => b.Id == id);
            if (bikeShop == null)
            {
                return NotFound("Bike shop not found.");
            }

            var validationError = ValidateStatusChange(bikeShop.Status, newStatus);
            if (validationError != null)
            {
                return BadRequest(validationError);
            }

            bikeShop.Status = newStatus;
            return Ok($"Bike shop status updated to {newStatus}.");
        }

        private static string? ValidateStatusChange(ShopStatus current, ShopStatus requested)
        {
            if (requested == ShopStatus.Open && current == ShopStatus.Renovating)
                return "Cannot reopen, shop is currently renovating.";

            if (requested == ShopStatus.Closed && current == ShopStatus.Renovating)
                return "Cannot close, shop is currently renovating.";

            if (requested == ShopStatus.Renovating && current == ShopStatus.Open)
                return "Shop must be closed before starting renovations.";

            if (!Enum.IsDefined(typeof(ShopStatus), requested))
                return "Unknown or unsupported shop status.";

            return null;
        }

        [HttpPost("{shopId}/bikes/{bikeId}/takeRide/{rideLength}")]
        public ActionResult TakeRide(int shopId, int bikeId, int rideLength)
        {
            _logger.LogInformation($"POST 🚲🚲🚲 with shopId: {shopId}, bikeId: {bikeId}, rideLength: {rideLength}");
            var bikeShop = BikeShops.Find(b => b.Id == shopId);

            var bike = bikeShop?.FindBikeById(bikeId);

            if (bike == null)
            {
                return NotFound("Bike not found in the specified bike shop.");
            }

            int waterConsumptionPerKm = 50;
            int totalWaterNeeded = rideLength * waterConsumptionPerKm;

            if (bike.WaterInBidon < totalWaterNeeded)
            {
                return BadRequest("Not enough water in bidon for the requested ride length.");
            }

            bike.WaterInBidon -= totalWaterNeeded;

            return Ok($"Bike rode {rideLength} kilometers. Water left in bidon: {bike.WaterInBidon} ml.");
        }

        [HttpPost("{shopId}/bikes/{bikeId}/bikeMalfunction")]
        public ActionResult BikeMalfunction(int shopId, int bikeId)
        {
            _logger.LogInformation($"POST 🚲🚲🚲 with shopId: {shopId}, bikeId: {bikeId} for malfunction simulation");
            var bikeShop = BikeShops.Find(b => b.Id == shopId);

            var bike = bikeShop?.FindBikeById(bikeId);

            if (bike == null)
            {
                return NotFound("Bike not found in the specified bike shop.");
            }

            // Simulate a malfunction causing recursion on the bicycle 
            BikeMalfunction(shopId, bikeId);

            return Ok($"Recovered from bicycle malfunction.");
        }

        [HttpPost("{shopId}/bikes/{bikeId}/calculateRange")]
        public ActionResult CalculateRange(int shopId, int bikeId)
        {
            _logger.LogInformation($"POST 🚲🚲🚲 with shopId: {shopId}, bikeId: {bikeId} for range calculation");
            Stopwatch stopwatch = new();
            stopwatch.Start();

            List<int> primes = CalculatePrimes(shopId + bikeId, 300000);

            stopwatch.Stop();
            _logger.LogInformation($"Found {primes.Count} prime numbers.");
            _logger.LogInformation($"Elapsed Time: {stopwatch.ElapsedMilliseconds / 1000.0} seconds");

            return Ok($"Calculated range.");
        }

        public static List<int> CalculatePrimes(int start, int end)
        {
            List<int> primes = new List<int>();
            for (int number = Math.Max(start, 2); number <= end; number++)
            {
            if (IsPrime(number))
            {
                primes.Add(number);
            }
            }
            return primes;
        }

        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;
            int boundary = (int)Math.Sqrt(number);
            for (int i = 3; i <= boundary; i += 2)
            {
            if (number % i == 0) return false;
            }
            return true;
        }
    }
}
