using Microsoft.AspNetCore.Mvc;
using PostDemo.DAL.Models.Entities;
using PostDemo.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PostDemo.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase {

        private readonly IUnitOfWork _unitOfWork;

        public PackageController(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }



        // GET: api/<PackageController>
        [HttpGet]
        public async Task<IActionResult> Get() {
            return Ok(await _unitOfWork.Packages.GetAll());
        }

        // GET api/<PackageController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) {
            var pack = await _unitOfWork.Packages.GetById(id);

            if (pack == null) {
                return NotFound();
            }

            return Ok(pack);
        }

        // POST api/<PackageController>
        [HttpPost]
        [Route("AddPackage")]
        public async Task<IActionResult> Post(Package package) {

            await _unitOfWork.Packages.Add(package);
            await _unitOfWork.CompleteAsync();
            return Ok();
        }

        // PUT api/<PackageController>/5
        [HttpPatch]
        [Route("PatchPackage")]
        public async Task<IActionResult> Patch(Package package) {

            var existPackage = await _unitOfWork.Packages.GetById(package.Id);
            if (existPackage == null) {
                return NotFound();
            }
            await _unitOfWork.Packages.Update(package);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }

        // DELETE api/<PackageController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            var existPackage = await _unitOfWork.Packages.GetById(id);
            if (existPackage == null) {
                return NotFound();
            }
            await _unitOfWork.Packages.Delete(existPackage);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
