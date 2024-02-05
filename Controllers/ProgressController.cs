using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace LanguageAPI.Controllers
{
    [System.Web.Http.Route("api/[controller]")]
    [ApiController]


    public class ProgressController : ApiController
    {
        private List<Progress> progresses = new List<Progress>
    {
        new Progress { Id = 1, UserId = 1, CourseId = 1, Percentage = 50 },
        new Progress { Id = 2, UserId = 2, CourseId = 1, Percentage = 75 }
    };

        public IHttpActionResult Get()
        {
            return Ok(progresses);
        }

        public IHttpActionResult Get(int id)
        {
            var progress = progresses.FirstOrDefault(p => p.Id == id);
            if (progress == null)
            {
                return NotFound();
            }
            return Ok(progress);
        }

        public IHttpActionResult Post([System.Web.Http.FromBody] Progress progress)
        {
            progress.Id = progresses.Count + 1;
            progresses.Add(progress);
            return Created(Request.RequestUri + progress.Id.ToString(), progress);
        }

        public IHttpActionResult Put(int id, [System.Web.Http.FromBody] Progress progress)
        {
            var existingProgress = progresses.FirstOrDefault(p => p.Id == id);
            if (existingProgress == null)
            {
                return NotFound();
            }
            existingProgress.UserId = progress.UserId;
            existingProgress.CourseId = progress.CourseId;
            existingProgress.Percentage = progress.Percentage;
            return Ok(existingProgress);
        }

        public IHttpActionResult Delete(int id)
        {
            var progress = progresses.FirstOrDefault(p => p.Id == id);
            if (progress == null)
            {
                return NotFound();
            }
            progresses.Remove(progress);
            return Ok(progress);
        }
    }

    public class Progress
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public int Percentage { get; set; }
    }
}

