using Microsoft.AspNetCore.Mvc;
using PostDemoApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PostDemoApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase {

        private static List<Package> _packages = new List<Package>() {
            new Package(){
             Id = 0,
             Title = "Test Title",
             Description = "Just some description",
             Kilos = 10,
             sendDate= DateTime.Now,
             Receiver =  new Client(),
             Sender = new Client()
            },
                        new Package(){
             Id = 1,
             Title = "Test Title 2 ",
             Description = "Just some description 2 ",
             Kilos = 20,
             sendDate= DateTime.Now,
             Receiver =  new Client(),
             Sender = new Client()
            }

        };

        // GET: api/<PackageController>
        [HttpGet]
        public IActionResult Get() {
            return Ok(_packages);
        }

        // GET api/<PackageController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            return Ok(_packages.FirstOrDefault(x => x.Id == id));
        }

        // POST api/<PackageController>
        [HttpPost]
        [Route("AddPackage")]
        public IActionResult Post(Package package) {
            _packages.Add(package);
            return Ok();
        }

        // PUT api/<PackageController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(Package package) {
            var existPackage = _packages.FirstOrDefault(x => x.Id == package.Id);
            if (existPackage == null) {
                return NotFound();
            }
            existPackage.Sender = package.Sender;
            existPackage.Receiver = package.Receiver;
            existPackage.Title = package.Title;
            existPackage.Kilos = package.Kilos;
            existPackage.Description = package.Description;
            existPackage.sendDate = package.sendDate;

            return NoContent();
        }

        // DELETE api/<PackageController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            var package = _packages.FirstOrDefault(x => x.Id == id);
            if (package == null) {
                return NotFound();
            }
            _packages.Remove(package);
            return NoContent();
        }
    }
}
