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
            Description = "Bikes built for the toughest trails.",
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
                Description = "A versatile mountain bike for all types of trails.",
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
                Price = 4000,
                ForkTravel = 160,
                RearTravel = 150,
                WaterInBidon = 900,
                ShopId = 4
                }
            }
            },
            // Wheel Brothers Collection - Shop 1
            new BikeShop
            {
            Id = 5,
            Name = "Wheel Brothers Downtown",
            Description = "Flagship store of the Wheel Brothers Collection, featuring exclusive models.",
            Category = "Flagship",
            HasDelivery = true,
            AddressId = 105,
            Status = ShopStatus.Open,
            ImageUrl = "https://example.com/images/wheelbrothers-downtown.jpg",
            Bikes = new List<Bike>
            {
                new() {
                Id = 9,
                Brand = "Bianchi",
                Model = "Oltre XR4",
                Description = "Aero road bike for the ultimate racing experience.",
                Price = 6500,
                ForkTravel = 0,
                RearTravel = 0,
                WaterInBidon = 750,
                ShopId = 5
                },
                new() {
                Id = 10,
                Brand = "Cervélo",
                Model = "Caledonia-5",
                Description = "Endurance road bike for long, comfortable rides.",
                Price = 5200,
                ForkTravel = 0,
                RearTravel = 0,
                WaterInBidon = 800,
                ShopId = 5
                }
            }
            },
            // Wheel Brothers Collection - Shop 2
            new BikeShop
            {
            Id = 6,
            Name = "Wheel Brothers Adventure",
            Description = "Adventure and gravel bikes for the explorers at heart.",
            Category = "Adventure",
            HasDelivery = false,
            AddressId = 106,
            Status = ShopStatus.Closed,
            ImageUrl = "https://example.com/images/wheelbrothers-adventure.jpg",
            Bikes = new List<Bike>
            {
                new() {
                Id = 11,
                Brand = "Giant",
                Model = "Revolt Advanced",
                Description = "Gravel bike built for speed and comfort on any terrain.",
                Price = 3200,
                ForkTravel = 40,
                RearTravel = 0,
                WaterInBidon = 1000,
                ShopId = 6
                },
                new() {
                Id = 12,
                Brand = "Specialized",
                Model = "Diverge",
                Description = "Versatile adventure bike for gravel and road.",
                Price = 3400,
                ForkTravel = 20,
                RearTravel = 0,
                WaterInBidon = 950,
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

        [HttpGet("{id}")]
        public ActionResult<BikeShop> GetById(int id)
        {
            _logger.LogInformation($"GET by ID 🚲🚲🚲 ID: {id} 🚲🚲🚲");
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
            _logger.LogInformation("POST 🚲🚲🚲 CREATE NEW BIKE SHOP 🚲🚲🚲");
            BikeShops.Add(bikeShop);
            return CreatedAtAction(nameof(GetById), new { id = bikeShop.Id }, bikeShop);
        }
        [HttpPut("{id}")]
        public ActionResult<BikeShop> Update(int id, BikeShop bikeShop)
        {
            _logger.LogInformation($"PUT 🚲🚲🚲 UPDATE BIKE SHOP ID: {id} 🚲🚲🚲");
            var existingBikeShop = BikeShops.Find(p => p.Id == id);
            if (existingBikeShop == null)
            {
                return NotFound();
            }

            existingBikeShop.Name = bikeShop.Name;
            existingBikeShop.Description = bikeShop.Description;
            existingBikeShop.Category = bikeShop.Category;
            existingBikeShop.HasDelivery = bikeShop.HasDelivery;
            existingBikeShop.AddressId = bikeShop.AddressId;
            existingBikeShop.Status = bikeShop.Status;
            existingBikeShop.Bikes = bikeShop.Bikes;

            return Ok(existingBikeShop);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        { 
            _logger.LogInformation($"DELETE 🚲🚲🚲 DELETE BIKE SHOP ID: {id} 🚲🚲🚲");
            var bikeShop = BikeShops.Find(p => p.Id == id);
            if (bikeShop == null)
            {
                return NotFound();
            }

            BikeShops.Remove(bikeShop);
            return NoContent();
        }

        // search bike shops by name
        [HttpGet("search")]
        [HttpPost("{id}/status")]
        public ActionResult UpdateShopStatus(int id, ShopStatus newStatus)
        {
            _logger.LogInformation($"POST 🚲🚲🚲 UPDATE SHOP STATUS ID: {id} 🚲🚲🚲");
            var bikeShop = BikeShops.Find(b => b.Id == id);

            if (bikeShop == null)
            {
            return NotFound("Bike shop not found.");
            }

            string validationError = ValidateStatusTransition(bikeShop.Status, newStatus);
            if (!string.IsNullOrEmpty(validationError))
            {
            return BadRequest(validationError);
            }

            bikeShop.Status = newStatus;
            return Ok($"Bike shop status updated to {newStatus}.");
        }

        private static string ValidateStatusTransition(ShopStatus currentStatus, ShopStatus newStatus)
        {
            if (newStatus == ShopStatus.Open && currentStatus == ShopStatus.Renovating)
            {
            return "Cannot reopen, shop is currently renovating.";
            }
            if (newStatus == ShopStatus.Closed && currentStatus == ShopStatus.Renovating)
            {
            return "Cannot close, shop is currently renovating.";
            }
            if (newStatus == ShopStatus.Renovating && currentStatus == ShopStatus.Open)
            {
            return "Shop must be closed before starting renovations.";
            }
            if (!Enum.IsDefined(typeof(ShopStatus), newStatus))
            {
            return "Unknown or unsupported shop status.";
            }
            return null;
        }

        [HttpPost("{shopId}/bikes/{bikeId}/takeRide/{rideLength}")]
        public ActionResult TakeRide(int shopId, int bikeId, int rideLength)
        {
            _logger.LogInformation($"POST 🚲🚲🚲 TAKE RIDE 🚲🚲🚲 Shop ID: {shopId}, Bike ID: {bikeId}, Ride Length: {rideLength} km");
            var bikeShop = BikeShops.Find(b => b.Id == shopId);

            var bike = bikeShop?.FindBikeById(bikeId);

            if (bike == null)
            {
                return NotFound("Bike not found in the specified bike shop.");
            }

            int waterConsumptionPerKm = 50;

            for (int i = 0; i < rideLength; i++)
            {
                if (bike.WaterInBidon == 0)
                {
                    return BadRequest("Bike stopped, rider dehydrated due to lack of water.");
                }
                else
                {
                    bike.WaterInBidon -= waterConsumptionPerKm;
                }
            }

            return Ok($"Bike rode {rideLength} kilometers. Water left in bidon: {bike.WaterInBidon} ml.");
        }

        [HttpPost("{shopId}/bikes/{bikeId}/bikeMalfunction")]
        public ActionResult BikeMalfunction(int shopId, int bikeId)
        {
            _logger.LogInformation($"POST 🚲🚲🚲 BIKE MALFUNCTION 🚲🚲🚲 Shop ID: {shopId}, Bike ID: {bikeId}");
            var bikeShop = BikeShops.Find(b => b.Id == shopId);

            var bike = bikeShop?.FindBikeById(bikeId);

            if (bike == null)
            {
                return NotFound("Bike not found in the specified bike shop.");
            }

            // Simulate a malfunction by setting a property or status
            // Add a property to Bike if needed, e.g., IsMalfunctioning
            // For now, let's just log and return a message
            //_logger.LogWarning($"Bike {bikeId} in shop {shopId} is now malfunctioning.");
            //bike.IsMalfunctioning = true; // Uncomment if property exists

            return Ok($"Bike {bikeId} in shop {shopId} is now malfunctioning.");
        }

        [HttpPost("{shopId}/bikes/{bikeId}/calculateRange")]
        public ActionResult CalculateRange(int shopId, int bikeId)
        {
            _logger.LogInformation($"POST 🚲🚲🚲 CALCULATE RANGE 🚲🚲🚲 Shop ID: {shopId}, Bike ID: {bikeId}");
            Stopwatch stopwatch = new();
            stopwatch.Start();

            // Use a more efficient Sieve of Eratosthenes for prime calculation
            List<int> primes = SievePrimes(shopId + bikeId, 300000);

            stopwatch.Stop();
            _logger.LogInformation($"Found {primes.Count} prime numbers.");
            _logger.LogInformation($"Elapsed Time: {stopwatch.ElapsedMilliseconds / 1000.0} seconds");

            return Ok($"Calculated range. Found {primes.Count} primes in {stopwatch.ElapsedMilliseconds / 1000.0} seconds.");
        }

        // Sieve of Eratosthenes for better performance
        public static List<int> SievePrimes(int start, int end)
        {
            if (end < 2 || start > end) return new List<int>();
            bool[] isPrime = new bool[end + 1];
            Array.Fill(isPrime, true);
            isPrime[0] = isPrime[1] = false;

            for (int i = 2; i * i <= end; i++)
            {
            if (isPrime[i])
            {
                for (int j = i * i; j <= end; j += i)
                {
                isPrime[j] = false;
                }
            }
            }

            List<int> primes = new();
            for (int i = Math.Max(2, start); i <= end; i++)
            {
            if (isPrime[i])
                primes.Add(i);
            }
            return primes;
        }
    }
}
