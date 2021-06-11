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
    public class AddPassangerController : ControllerBase
    {
        public static Context context = new Context();
        [HttpGet]
        public string Post(string Name, string LastName, string Email, string Password, string Passport)
        {
            IQueryable<Passanger> passangers = from passanger in context.Passanger
                                             where (passanger.Name == Name) &&
                                             (passanger.LastName == LastName) &&
                                             (passanger.Email == Email) &&
                                             (passanger.Password == Password) &&
                                             (passanger.Passport == Passport)
                                             select passanger;
            if (passangers.Count() > 0)
            {
                return "Passanger is exists!";
            }
            else
            {
                try
                {
                    Passanger newPassanger = new Passanger()
                    {
                        Name = Name,
                        LastName = LastName,
                        Email = Email,
                        Password = Password,
                        Passport = Passport
                    };
                    context.Passanger.Add(newPassanger);
                    context.SaveChangesAsync();
                    return "Passanger is registered!";
                }
                catch
                {
                    return "User registration is failed!";
                }
            }
        }
    }



}
