using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace YouLendProject.Controllers
{
    public class ValuesController : ApiController
    {

        static List<string> sList = new List<string>()
        {
                
        };

        // GET api/values
        public IEnumerable<string> Get()
        {
            return sList;
        }

        // GET api/values/5
        public string Get(int id)
        {
            
            return sList[id];
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            sList.Add(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            sList[id] = value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            sList.RemoveAt(id);
        }
    }
}
