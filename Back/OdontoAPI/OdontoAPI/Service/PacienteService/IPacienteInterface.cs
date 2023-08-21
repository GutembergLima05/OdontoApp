using OdontoAPI.Models;

namespace OdontoAPI.Service.PacienteService
{
    public interface IPacienteInterface
    {
        Task<ServiceResponse<List<PacienteModel>>> GetPacientes();
        Task<ServiceResponse<List<PacienteModel>>> CreatePaciente(PacienteModel novoPaciente);
        Task<ServiceResponse<PacienteModel>> GetPacienteById(int id);
        Task<ServiceResponse<List<PacienteModel>>> DeletePaciente(int id);
    }
}
