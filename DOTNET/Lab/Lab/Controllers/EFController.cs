using Lab.Data;
using Lab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EFController(AppDbContext context):ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            //insert
            var user = new Lab.Models.User
            {
                Name = "Test",
                Age = 23
            };

            context.Users.Add(user);
            await context.SaveChangesAsync();

            //update
            var u=context.Users.FirstOrDefault()!;
            u.Name = "Updated";
            await context.SaveChangesAsync();

            //Select
            //var users=context.Users.AsNoTracking().ToList();

            //IEnumerable
            var users = context.Users.ToList().Where(x => x.Age == 23);

            //IQueryable
            var usersQ = context.Users.Where(x => x.Age == 23);

            return Ok(users!);
        }
    }
}
