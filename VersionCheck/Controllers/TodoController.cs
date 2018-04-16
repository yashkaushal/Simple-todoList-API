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
    public class TodoController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public JsonResult GetAll()
        {
            return Json(VersionCheck.Models.Todo.list);
        }

        // GET api/<controller>/5
        [HttpGet("/u/{user}/{id}")]
        public JsonResult Get(string user, int id)
        {
            return Json(from element in Todo.list where element.id == id && element.User == user select element);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("/u/{user}/{id}")]
        public void Delete(string user, int id)
        {
            foreach( Todo obj in (from element in Todo.list where element.id == id && element.User == user select element))
            {
                Todo.list.Remove(obj);
            }
        }
    }
}
