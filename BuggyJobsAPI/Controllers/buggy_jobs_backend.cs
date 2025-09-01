using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JobSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private static List<Job> jobs = new List<Job>();
        private static int nextId = 1;

        [HttpGet]
        public IEnumerable<Job> GetJobs()
        {
            return jobs;
        }

        [HttpPost]
        public IActionResult AddJob(Job job)
        {
            if (string.IsNullOrWhiteSpace(job.Title))
                return BadRequest("Title is required");

            if (job.ClosingDate <= DateTime.Now)
                return BadRequest("Closing date must be in the future");

            job.Id = nextId++;
            jobs.Add(job);

            return Ok(job);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteJob(int id)
        {
            var job = jobs.FirstOrDefault(j => j.Id == id);
            if (job == null)
                return NotFound("Job not found");

            jobs.Remove(job);
            return Ok("Job deleted");
        }
    }

    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? Location { get; set; }
        public string? Type { get; set; }
        public DateTime ClosingDate { get; set; }
    }
}
