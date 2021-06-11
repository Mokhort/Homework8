using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Home8.Controllers
{

    public class FlightStruct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Route> Route { get; set; }
        public int Cost { get; set; }
        public DateTime Time_Departure { get; set; }
        public DateTime Time_Registration { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class TOPFlightController : ControllerBase
    {
        public static Context context = new Context();

        [HttpGet]
        public List<FlightStruct> Get()
        {
            IQueryable<Flight> flights = (from flight in context.Flight
                                             select flight).Take(10);
            List<FlightStruct> result = new List<FlightStruct>();
            if (flights != null)
            {
                foreach (Flight flight in flights)
                {
                    result.Add(new FlightStruct()
                    {
                        Name = flight.Name,
                        Route = flight.Route,
                        Cost = flight.Cost,
                        Time_Departure = flight.Time_Departure,
                        Time_Registration = flight.Time_Registration
                    });
                }
            }
            return result;
        }
    }
}
