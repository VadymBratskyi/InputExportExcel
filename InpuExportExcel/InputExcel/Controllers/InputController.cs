using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InputExcel.Models;
using Microsoft.AspNetCore.Mvc;

namespace InputExcel.Controllers
{
    [Route("api/[controller]")]
    public class InputController : Controller
    {
        private List<TestObject> testList = new List<TestObject>() {
            new TestObject() { Name = "AAAAAA", Number = 1 },
            new TestObject() { Name = "BBBBBB", Number = 2 },
            new TestObject() { Name = "CCCCCC", Number = 3 },
            new TestObject() { Name = "DDDDDD", Number = 4 },
            new TestObject() { Name = "EEEEEE", Number = 5 },
            new TestObject() { Name = "FFFFFF", Number = 6 },
            new TestObject() { Name = "GGGGGG", Number = 7 },

        };


        private InputExportDbContext _db;

        public InputController(InputExportDbContext db) {
            _db = db;
        }
        
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<TestObject>> GetTestObjects()
        {
            return testList;
        }

        [HttpPost("[action]")]
        public void PostTestObjects([FromBody] string value)
        {

        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}