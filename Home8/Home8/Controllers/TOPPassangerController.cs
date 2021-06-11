using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Home8.Controllers
{
   public  class Pass
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Passport { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class TOPPassangerController : ControllerBase
    {

        public static Context context = new Context();

        [HttpGet]
        public List<Pass> Get()
        {
            IQueryable<Passanger> passangers = (from passanger in context.Passanger
                                                select passanger).Take(10);
            List<Pass> result = new List<Pass>();
            if (passangers != null)
            {
                foreach (Passanger passanger in passangers)
                {
                    result.Add(new Pass()
                    {
                        Name = passanger.Name,
                        LastName = passanger.LastName,
                        Email = passanger.Email,
                        Password = passanger.Password,
                        Passport = passanger.Passport
                    });
                }
            }
            return result;
        }
    }
}


