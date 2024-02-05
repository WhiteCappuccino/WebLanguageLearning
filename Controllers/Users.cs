using Microsoft.AspNetCore.Mvc;

namespace LanguageAPI.Controllers
{
    public class Users
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public int LastName { get; set; }
        public string Password { get; set; }
        public string email { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class UserController : ApiController
    {
        private List<User> users = new List<User>
    {
        new User { Id = 1, Name = "John" },
        new User { Id = 2, Name = "Alice" }
    };

        // GET api/user
        public IHttpActionResult Get()
        {
            return Ok(users);
        }

        // GET api/user/5
        public IHttpActionResult Get(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST api/user
        public IHttpActionResult Post([FromBody] User user)
        {
            user.Id = users.Count + 1;
            users.Add(user);
            return Created(Request.RequestUri + user.Id.ToString(), user);
        }

        // PUT api/user/5
        public IHttpActionResult Put(int id, [FromBody] User user)
        {
            var existingUser = users.FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
            {
                return NotFound();
            }
            existingUser.Name = user.Name;
            return Ok(existingUser);
        }

        // DELETE api/user/5
        public IHttpActionResult Delete(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            users.Remove(user);
            return Ok(user);
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
