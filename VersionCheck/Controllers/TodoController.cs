using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VersionCheck.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VersionCheck.Controllers
{
    [Route("api/[controller]")]
    ///<summary>
    ///Manages todo's made by users
    ///</summary>
    public class TodoController : Controller
    {
        // GET: api/<controller>
        /// <summary>
        /// get all todo items in json format
        /// </summary>
        [HttpGet]
        public JsonResult GetAll()
        {
            return Json(VersionCheck.Models.Todo.list);
        }

        // GET api/<controller>/5
        /// <summary>
        /// get todo item of a particular user of a particular todo id
        /// </summary>
        /// <param name="user">name of user</param>
        /// <param name="id">todo ID</param>
        /// <returns></returns>
        [HttpGet("u/{user}/{id}")]
        public JsonResult Get(string user, int id)
        {
            return Json(from element in Todo.list where element.id == id && element.User == user select element);
        }

        /// <summary>
        /// Create a new todo
        /// </summary>
        /// <param name="userName">name of user creating(should be ID)</param>
        /// <param name="message">Todo body</param>
        /// <returns></returns>
        [HttpPost("create/u/{userName}")]
        public JsonResult CreateTodo(String userName,[FromBody] string message)
        {
            Console.WriteLine(userName + "   "+ message);
            return Json(new Todo(userName, message));


        }

        /// <summary>
        /// delete a particular todo with todi id of a particular user
        /// </summary>
        /// <param name="user">name of user</param>
        /// <param name="id">id of todo</param>
        // DELETE api/<controller>/5
        [HttpDelete("u/{user}/{id}")]
        public void Delete(string user, int id)
        {
            foreach( Todo obj in (from element in Todo.list where element.id == id && element.User == user select element))
            {
                Todo.list.Remove(obj);
            }
        }
    }

    class messageStructure
    {
        public string message;
    }
}
