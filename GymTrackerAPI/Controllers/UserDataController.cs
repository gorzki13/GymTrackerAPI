using GymTrackerAPI.Data;
using GymTrackerAPI.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : ControllerBase
    {
       
        
        private readonly DataContext _context;
        public UserDataController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserData>>> GetUserData()
        {
            return Ok(await _context.UserData.ToListAsync());

        }
        
        [HttpPost]
        public async Task<ActionResult<List<UserData>>> CreateUserData(UserData userData)
        {
            _context.UserData.Add(userData);
            await _context.SaveChangesAsync();
            return Ok(await _context.UserData.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<UserData>>> UpdateUserData(UserData userData)
        {
            var dbuserdata = await _context.UserData.FindAsync(userData.Id);
            if (dbuserdata == null)
            {
                return BadRequest("Not Found");

            }
            dbuserdata.Height = userData.Height;
            dbuserdata.Weight = userData.Weight;
            dbuserdata.TargetWeight = userData.TargetWeight;

            await _context.SaveChangesAsync();

            return Ok(await _context.UserData.ToListAsync());

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<UserData>>> DeleteUserdata(int id)
        {

            var dbuserdata = await _context.UserData.FindAsync(id);
            if (dbuserdata == null)
            {
                return BadRequest("Not Found");

            }
            _context.UserData.Remove(dbuserdata);
            await _context.SaveChangesAsync();

            return Ok(await _context.UserData.ToListAsync());

        }


    }
}
