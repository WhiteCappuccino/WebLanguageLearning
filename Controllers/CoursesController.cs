using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LanguageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ApiController
    {
        private List<Course> courses = new List<Course>
    {
        new Course { Id = 1, Title = "Introduction to Programming", Description = "Learn the basics of programming" },
        new Course { Id = 2, Title = "Web Development Fundamentals", Description = "Explore the fundamentals of web development" }
    };
        public IHttpActionResult Get()
        {
            return Ok(courses);
        }

        // GET api/courses/5
        public IHttpActionResult Get(int id)
        {
            var course = courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        // POST api/courses
        public IHttpActionResult Post([FromBody] Course course)
        {
            course.Id = courses.Count + 1;
            courses.Add(course);
            return Created(Request.RequestUri + course.Id.ToString(), course);
        }

        // PUT api/courses/5
        public IHttpActionResult Put(int id, [FromBody] Course course)
        {
            var existingCourse = courses.FirstOrDefault(c => c.Id == id);
            if (existingCourse == null)
            {
                return NotFound();
            }
            existingCourse.Title = course.Title;
            existingCourse.Description = course.Description;
            return Ok(existingCourse);
        }

        // DELETE api/courses/5
        public IHttpActionResult Delete(int id)
        {
            var course = courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return NotFound();
            }
            courses.Remove(course);
            return Ok(course);
        }
    }

    public class Courses
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
