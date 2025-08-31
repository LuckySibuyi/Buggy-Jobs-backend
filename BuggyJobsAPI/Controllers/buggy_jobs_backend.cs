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
            {
                return BadRequest("Title is required");
            }

            jobs.Add(new Job
            {
                Id = nextId++,
                Title = job.Title,
                Description = job.Description,
                Location = job.Location,
                Type = job.Type,
                ClosingDate = job.ClosingDate
            });

            return Ok(job);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteJob(int id)
        {
            jobs.RemoveAll(j => j.Id == id);
            return Ok("Job deleted");
        }
    }

    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public DateTime ClosingDate { get; set; }
    }
}