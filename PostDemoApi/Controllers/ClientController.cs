using Microsoft.AspNetCore.Mvc;
using PostDemo.DAL.Models.Entities;
using PostDemo.Contracts;
using AutoMapper;
using PostDemo.DAL.Models.DTOs;

namespace PostDemo.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientController(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Client
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> Get() {
            List<Client> clients = await _unitOfWork.Clients.GetAll() as List<Client>;

            var clientsDTO = _mapper.Map<List<Client>, List<ClientDTO>>(clients);

            return Ok(clientsDTO);
        }

        // GET: api/Client/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> Get(int id) {
            var client = await _unitOfWork.Clients.GetById(id);

            if (client == null) {
                return NotFound();
            }
            var clientDTO = _mapper.Map<Client>(client);

            return Ok(clientDTO);
        }

        // PUT: api/Client/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPatch]
        [Route("PatchClient")]
        public async Task<IActionResult> PatchClient(Client client) {
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
        public async Task<ActionResult<Client>> Post(Client client) {
            await _unitOfWork.Clients.Add(client);
            await _unitOfWork.CompleteAsync();
            return Ok();
        }

        // DELETE: api/Client/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id) {
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
