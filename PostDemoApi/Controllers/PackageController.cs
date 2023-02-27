using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PostDemo.Contracts;
using PostDemo.DAL.Models.DTOs;
using PostDemo.DAL.Models.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PostDemo.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PackageController(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }



        // GET: api/<PackageController>
        [HttpGet]
        public async Task<IActionResult> Get() {
            List<Package> pack = await _unitOfWork.Packages.GetAll() as List<Package>;
            var packageDTO = _mapper.Map<List<Package>, List<PackageDTO>>(pack);

            return Ok(packageDTO);
        }

        // GET api/<PackageController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) {
            var pack = await _unitOfWork.Packages.GetById(id);

            if (pack == null) {
                return NotFound();
            }
            var packageDTO = _mapper.Map<PackageDTO>(pack);

            return Ok(packageDTO);
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
