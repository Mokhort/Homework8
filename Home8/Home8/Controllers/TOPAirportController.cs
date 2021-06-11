using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Home8.Controllers
{
    public class AirportStruct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string ShortName { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class TOPAirportController : ControllerBase
    {
        public static Context context = new Context();

        [HttpGet]
        public List<AirportStruct> Get()
        {
            IQueryable<Airport> airports = (from airport in context.Airport
                                           select airport).Take(10);
            List<AirportStruct> result = new List<AirportStruct>();
            if (airports != null)
            {
                foreach (Airport airport in airports)
                {
                    result.Add(new AirportStruct()
                    {
                        Name = airport.Name,
                        City = airport.City,
                        ShortName = airport.ShortName
                    });
                }
            }
            return result;
        }
    }
}
