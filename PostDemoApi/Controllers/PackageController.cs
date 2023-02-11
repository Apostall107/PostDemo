using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostDemoApi.DAL;
using PostDemoApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PostDemoApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase {

        private readonly DatabaseContext _dbContext;

        public PackageController(DatabaseContext context) {
            _dbContext = context;
        }



        // GET: api/<PackageController>
        [HttpGet]
        public async Task<IActionResult> Get() {
            return Ok( await _dbContext.Packages.ToListAsync());
        }

        // GET api/<PackageController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) {
            var pack = await _dbContext.Packages.FirstOrDefaultAsync(x => x.Id == id);

            if (pack == null) {
                return NotFound();
            }

            return Ok(pack);
        }

        // POST api/<PackageController>
        [HttpPost]
        [Route("AddPackage")]
        public async Task<IActionResult> Post(Package package) {

            _dbContext.Packages.Add(package);

            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        // PUT api/<PackageController>/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Package package) {

            var existPackage = await _dbContext.Packages.FirstOrDefaultAsync(x => x.Id == package.Id);
            if (existPackage == null) {
                return NotFound();
            }
            existPackage.Title = package.Title;
            existPackage.Kilos = package.Kilos;
            existPackage.Description = package.Description;
            existPackage.sendDate = package.sendDate;
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/<PackageController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            var package = await _dbContext.Packages.FirstOrDefaultAsync(x => x.Id == id);
            if (package == null) {
                return NotFound();
            }
            _dbContext.Packages.Remove(package);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
