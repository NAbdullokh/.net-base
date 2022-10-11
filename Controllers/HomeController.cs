using DataBaseFirst.Data;
using DataBaseFirst.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataBaseFirst.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public HomeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _dataContext.Users.ToList();
            return Ok(users);
        }

        [HttpPost]
        public IActionResult AddUser(User value)
        {
            _dataContext.Users.Add(value);
            _dataContext.SaveChanges();
            return Ok(value);
        }
    }
}
