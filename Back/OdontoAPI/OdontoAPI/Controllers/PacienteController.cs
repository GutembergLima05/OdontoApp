using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OdontoAPI.Models;
using OdontoAPI.Service.PacienteService;

namespace OdontoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteInterface _pacienteInterface;
        public PacienteController(IPacienteInterface pacienteInterface)
        {
            _pacienteInterface = pacienteInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<PacienteModel>>>> GetPacientes()
        {
            return Ok(await _pacienteInterface.GetPacientes());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<List<PacienteModel>>>> GetPacienteById(int id)
        {
            ServiceResponse<PacienteModel> serviceResponse = await _pacienteInterface.GetPacienteById(id);

            return Ok(serviceResponse);
        }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<PacienteModel>>>> CreatePaciente(PacienteModel novoPaciente)
        {
            return Ok(await _pacienteInterface.CreatePaciente(novoPaciente));
        }

    }
}
