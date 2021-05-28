using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GeradorNumero.Data;
using GeradorNumero.Models;

namespace GeradorNumero.Controllers{

    [ApiController]
    [Route("v1/users")]
    public class UserController : ControllerBase{
        
        [HttpGet]
        public async Task<ActionResult<User>> Get(
            [FromServices] Context context,
            [FromQuery] string email
        ){
            var user = await context.Users.Where(x=>x.Email==email).FirstOrDefaultAsync();
            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>>Post(
            [FromServices] Context context,
            [FromBody] User user
        ){
            if(ModelState.IsValid)
            {
                context.Users.Add(user);
                await context.SaveChangesAsync();
                return user;
            }
            else{
                return BadRequest(ModelState);
            }
        }

    }


}