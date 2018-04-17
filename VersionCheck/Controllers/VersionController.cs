using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VersionCheck.Controllers
{
    [Route("api/[controller]")]
    public class VersionController : Controller
    {

        // get latest version number
        // GET: api/<controller>
        /// <summary>
        /// Get latest version number
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string GetLatestversionNumber()
        {
            return Models.Version.Number;
        }

        
        // check if your version is latest
        // GET api/<controller>/5
        /// <summary>
        /// Matches the given version with latest version
        /// </summary>
        /// <param name="ver">version number(string)</param>
        /// <returns>latest if versino matches or obsolete if they don't</returns>
        [HttpGet("checkLatest/{ver}")]
        public string Get(string ver)
        {
            return ver == Models.Version.Number ? "Latest" : "obsolete";
        }
    }
}
