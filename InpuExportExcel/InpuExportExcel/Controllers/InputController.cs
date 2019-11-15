using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using InpuExportExcel.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InpuExportExcel.Controllers
{    
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    public class InputController : Controller
    {
        private List<TestObject> testList;
        private InputExportDbContext _db;
        private IHostingEnvironment _hosting;


        public InputController(InputExportDbContext db, IHostingEnvironment hostingEnvironment) {
            _db = db;
            _hosting = hostingEnvironment;
            //loadData();
            AvtoGenerateUsers();
        }
        
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<TestObject>> GetTestObjects()
        {
            var data = testList;
            return data.ToList();
        }

        [HttpPost("[action]")]
        public void PostTestObjects([FromBody] TestValue value)
        {

        }

        
        [HttpPost("[action]")]                          //List<IFormFile>
        public async Task<IActionResult> PostAddFile(IFormFileCollection  files) { 

            if (files != null && files.Count > 0)
            {
                foreach (var fl in files) {
                    // путь к папке Files
                    string path = "/Files/" + fl.FileName;
                    // сохраняем файл в папку Files в каталоге wwwroot
                    using (var fileStream = new FileStream(_hosting.WebRootPath + path, FileMode.Create))
                    {
                        await fl.CopyToAsync(fileStream);
                    }
                    FileModel file = new FileModel { Name = fl.FileName, Path = path };
                    _db.Files.Add(file);
                }
                _db.SaveChanges();

            }


            return Ok();

        }

        [HttpPost("[action]")]
        public async Task<ActionResult> PostRemoveFiles(object files)
        {

            if (files != null)
            {
                //// путь к папке Files
                //string path = "/Files/" + uploadedFile.FileName;
                //// сохраняем файл в папку Files в каталоге wwwroot
                //using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                //{
                //    await uploadedFile.CopyToAsync(fileStream);
                //}
                //FileModel file = new FileModel { Name = uploadedFile.FileName, Path = path };
                //_context.Files.Add(file);
                //_context.SaveChanges();
            }


            return Ok();

        }

        private void loadData()
        {
            var data = _db.TestObjects;
            if (!data.Any()) {
                _db.TestObjects.AddRange(testList);
                _db.SaveChanges();
            }
        }

        private void AvtoGenerateUsers() {
            var faker = new Faker("ru");
            testList = new List<TestObject>()
            {
                new TestObject() { Name = faker.Name.FullName(), Number = 1 },
                new TestObject() { Name = faker.Name.FullName(), Number = 2 },
                new TestObject() { Name = faker.Name.FullName(), Number = 3 },
                new TestObject() { Name = faker.Name.FullName(), Number = 4 },
                new TestObject() { Name = faker.Name.FullName(), Number = 5 },
                new TestObject() { Name = faker.Name.FullName(), Number = 6 },
                new TestObject() { Name = faker.Name.FullName(), Number = 7 },
                new TestObject() { Name = faker.Name.FullName(), Number = 8 }
            };
        }


        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }

    public class TestValue {
        public string Value { get; set; }
    }

    public class MyFIles
    {
        public string FileName { get; set; }
    }

}