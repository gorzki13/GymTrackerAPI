using GymTrackerAPI.Data;
using GymTrackerAPI.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly DataContext _context;
        public TrainingController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Training>>> GetTraining()
        {
            return Ok(await _context.Trainings.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult<List<Training>>> CreateTraining(Training training)
        {
            _context.Trainings.Add(training);
            await _context.SaveChangesAsync();
            return Ok(await _context.Trainings.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Training>>> UpdateTraining(Training training)
        {
            var dbTraining = await _context.Trainings.FindAsync(training.Id);
            if (dbTraining == null)
            {
                return BadRequest("Not Found");

            }
            dbTraining.Name = training.Name;
            
            

            await _context.SaveChangesAsync();

            return Ok(await _context.Trainings.ToListAsync());

        }
       
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Training>>> DeleteTraining(int id)
        {

            var dbTraining = await _context.Trainings.FindAsync(id);
            if (dbTraining == null)
            {
                return BadRequest("Not Found");

            }
            _context.Trainings.Remove(dbTraining);
            await _context.SaveChangesAsync();

            return Ok(await _context.Trainings.ToListAsync());

        }
    }
}
