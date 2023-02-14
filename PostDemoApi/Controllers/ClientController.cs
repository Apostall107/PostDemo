using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostDemoApi.Contracts;
using PostDemoApi.DAL;
using PostDemoApi.Models;

namespace PostDemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientController(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Client
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> Get() {
            return Ok(await _unitOfWork.Clients.GetAll());
        }

        // GET: api/Client/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> Get(int id)
        {
            var client = await _unitOfWork.Clients.GetById(id);

            if (client == null) {
                return NotFound();
            }

            return Ok(client);
        }

        // PUT: api/Client/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPatch]
        [Route("PatchClient")]
        public async Task<IActionResult> PatchClient(Client client)
        {
            var existPackage = await _unitOfWork.Clients.GetById(client.Id);
            if (existPackage == null) {
                return NotFound();
            }
            await _unitOfWork.Clients.Update(client);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }

        // POST: api/Client
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("AddClient")]
        public async Task<ActionResult<Client>> Post(Client client)
        {
            await _unitOfWork.Clients.Add(client);
            await _unitOfWork.CompleteAsync();
            return Ok();
        }

        // DELETE: api/Client/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var existPackage = await _unitOfWork.Clients.GetById(id);
            if (existPackage == null) {
                return NotFound();
            }
            await _unitOfWork.Clients.Delete(existPackage);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
