using GymTrackerAPI.Data;
using GymTrackerAPI.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly DataContext _context;
        public ExerciseController(DataContext context)
        {
            _context = context;
        }
      
        
        
        
        [HttpGet]
        public async Task<ActionResult<List<Exercise>>>GetExercise()
        {
            return Ok(await _context.Exercises.ToListAsync());
            
        }
        [HttpPost]
        public async Task<ActionResult<List<Exercise>>> CreateExercise(Exercise exercise)
        {
            _context.Exercises.Add(exercise);
            await _context.SaveChangesAsync();
            return Ok(await _context.Exercises.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Exercise>>> UpdateExercise(Exercise exercise) 
        {
            var dbExercise = await _context.Exercises.FindAsync(exercise.Id);
            if (dbExercise == null)
            {
                return BadRequest("Not Found");

            }
            dbExercise.Name = exercise.Name;
            dbExercise.BodyPart = exercise.BodyPart;
            dbExercise.Reps = exercise.Reps;
            dbExercise.Series = exercise.Series;
            dbExercise.Trainingid = exercise.Trainingid;

            await _context.SaveChangesAsync();

            return Ok(await _context.Exercises.ToListAsync());
        
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Exercise>>> DeleteExercise(int id)
        {

            var dbExercise = await _context.Exercises.FindAsync(id);
            if (dbExercise == null)
            {
                return BadRequest("Not Found");

            }
            _context.Exercises.Remove(dbExercise);
            await _context.SaveChangesAsync();

            return Ok(await _context.Exercises.ToListAsync());

        }



    }
}
