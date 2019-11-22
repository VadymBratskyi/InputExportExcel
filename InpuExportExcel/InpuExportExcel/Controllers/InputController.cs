using Bogus;
using ExcelParserLibrary.Process;
using InputExportExcel.DAL;
using InputExportExcel.DAL.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace InpuExportExcel.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    public class InputController : Controller
    {
        private List<TestContact> testList;

        private InputExportDbContext _db;
        private IHostingEnvironment _hosting;


        public InputController(InputExportDbContext db, IHostingEnvironment hostingEnvironment)
        {
            _db = db;
            _hosting = hostingEnvironment;
            //loadData();
            //AvtoGenerateUsers();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetTestContacts()
        {
            var requestQuery = HttpContext.Request.Query;

            var querySkip = requestQuery["skip"];
            var queryTake = requestQuery["take"];

            var couunt = _db.TestContacts.Count();

            var data = _db.TestContacts
                .Skip(int.Parse(querySkip))
                .Take(int.Parse(queryTake));

            return Ok(new { Count = couunt, Data = data });
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> PostDomParsing([FromBody] MyFile myFile)
        {
            var filePath = Path.Combine(_hosting.WebRootPath, "Files", myFile.FileName);

            if (System.IO.File.Exists(filePath))
            {
                DomProcessParsing parsing = new DomProcessParsing(_db);
                parsing.ParsingIntoDb(filePath);
            }

            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> PostSaxParsing([FromBody] MyFile myFile)
        {
            var filePath = Path.Combine(_hosting.WebRootPath, "Files", myFile.FileName);

            if (System.IO.File.Exists(filePath))
            {
                SaxProcessParsing parsing = new SaxProcessParsing(_db);
                parsing.ParsingIntoDb(filePath);
            }

            return Ok();
        }


        [HttpPost("[action]")]                          //List<IFormFile>
        public async Task<IActionResult> PostAddFile(IFormFileCollection files)
        {

            if (files != null && files.Count > 0)
            {
                foreach (var fl in files)
                {
                    // путь к папке Files

                    string path = "Files\\" + fl.FileName;

                    var fullPAth = Path.Combine(_hosting.WebRootPath, path);

                    if (!System.IO.File.Exists(fullPAth))
                    {
                        // сохраняем файл в папку Files в каталоге wwwroot
                        using (var fileStream = new FileStream(fullPAth, FileMode.Create))
                        {
                            await fl.CopyToAsync(fileStream);
                        }
                        FileModel file = new FileModel { Name = fl.FileName, Path = path };
                        _db.Files.Add(file);
                    }

                }
                _db.SaveChanges();

            }

            return Ok();

        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<string>> GetAbleExcelFiles()
        {
            var directoryPath = Path.Combine(_hosting.WebRootPath, "Files");

            var fl = new DirectoryInfo(directoryPath);

            return fl.GetFiles().Where(f => f.Extension == ".xlsx").Select(f => f.Name).ToList();
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
            testList = _db.TestContacts.ToList();
            if (!testList.Any())
            {
                _db.TestContacts.AddRange(testList);
                _db.SaveChanges();
            }
        }

        private void AvtoGenerateUsers()
        {
            var faker = new Faker("ru");
            testList = new List<TestContact>()
            {
                new TestContact() { FullName = faker.Name.FullName(), Gender = faker.Person.Gender.ToString() },
                new TestContact() { FullName = faker.Name.FullName(), Gender = faker.Person.Gender.ToString() },
                new TestContact() { FullName = faker.Name.FullName(), Gender = faker.Person.Gender.ToString() },
                new TestContact() { FullName = faker.Name.FullName(), Gender = faker.Person.Gender.ToString() },
                new TestContact() { FullName = faker.Name.FullName(), Gender = faker.Person.Gender.ToString() },
                new TestContact() { FullName = faker.Name.FullName(), Gender = faker.Person.Gender.ToString() },
                new TestContact() { FullName = faker.Name.FullName(), Gender = faker.Person.Gender.ToString() },
                new TestContact() { FullName = faker.Name.FullName(), Gender = faker.Person.Gender.ToString() }
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

    public class TestValue
    {
        public string Value { get; set; }
    }

    public class MyFile
    {
        public string FileName { get; set; }
    }

}