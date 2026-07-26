using Lab.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController(IUserService user, SingeltonService ss1, SingeltonService ss2,TransientService ts1, TransientService ts2,ScopedService s1,ScopedService s2) : Controller
    {
        [HttpGet]
        [Route("users")]
        public async Task<ActionResult> GetUsers()
        {
            return Ok(user.GetUserName());
        }

        [HttpGet]
        public async Task<ActionResult<Object>> GetGuid()
        {
            return Ok(new
            {
                Singleton1 = ss1.Id,
                Singleton2 = ss2.Id,

                Scoped1 = s1.Id,
                Scoped2 = s2.Id,

                Transient1 = ts1.Id,
                Transient2 = ts2.Id
            });
        }
    }
}
