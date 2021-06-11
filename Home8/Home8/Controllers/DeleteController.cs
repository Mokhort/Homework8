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
    public class DeleteController : ControllerBase
    {
        public static Context context = new Context();
        public Flight DeleteFl(int Id)
        {
            Flight DeleteFl = context.Flight.Find(Id);
            if (DeleteFl != null)
            {
                context.Flight.Remove(DeleteFl);
                context.SaveChangesAsync();
            }
            return DeleteFl;
        }
    }
}
