using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Home8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        public static Context context = new Context();

        [HttpGet]
        public List<FlightStruct> Get(DateTime dep)
        {
            IQueryable<Flight> flights = (from flight in context.Flight where (flight.Time_Departure.Date == dep) select flight);
            List<FlightStruct> result = new List<FlightStruct>();
            if (flights.Count() > 0)
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
