using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VersionCheck.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VersionCheck.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        // GET: api/<controller>
        /// <summary>
        /// returns all users with user id in Json format
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetAllUsers()
        {
            return Json(Models.User.list);
        }

        // GET api/<controller>/5
        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="name">name of new user</param>
        /// <returns></returns>
        [HttpGet("n/{name}")]
        public JsonResult Get(string name)
        {
            return Json(new User(name));
        }

        // DELETE api/<controller>/5
        /// <summary>
        /// remove user with particular user id
        /// </summary>
        /// <param name="id">user id</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            foreach(User user in (from element in Models.User.list
                                  where element.Id == id
                                  select element))
            {
                Models.User.list.Remove(user);
            }
        }
    }
}
