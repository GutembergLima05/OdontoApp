using OdontoAPI.Data;
using OdontoAPI.Models;

namespace OdontoAPI.Service.PacienteService
{
    public class PacienteService : IPacienteInterface
    {
        private readonly ApplicationDbContext _db;
        public PacienteService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<ServiceResponse<List<PacienteModel>>> CreatePaciente(PacienteModel novoPaciente)
        {
            ServiceResponse<List<PacienteModel>> serviceResponse = new ServiceResponse<List<PacienteModel>>();

            try
            {
                if(novoPaciente == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar Dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _db.Add(novoPaciente);
                await _db.SaveChangesAsync();

                serviceResponse.Dados = _db.Pacientes.ToList();

                
            } catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<PacienteModel>>> DeletePaciente(int id)
        {
            ServiceResponse<List<PacienteModel>> serviceResponse = new ServiceResponse<List<PacienteModel>>();

            try
            {
                PacienteModel paciente = _db.Pacientes.FirstOrDefault(x => x.Id == id);

                if(paciente == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Paciente não existe!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _db.Pacientes.Remove(paciente);
                await _db.SaveChangesAsync();

                serviceResponse.Dados = _db.Pacientes.ToList();

            } catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<PacienteModel>> GetPacienteById(int id)
        {
            ServiceResponse<PacienteModel> serviceResponse = new ServiceResponse<PacienteModel>();

            try
            {
                PacienteModel paciente = _db.Pacientes.FirstOrDefault(x => x.Id == id);

                if (serviceResponse.Dados == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Nenhum paciente encontrado!";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = paciente;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<PacienteModel>>> GetPacientes()
        {
            ServiceResponse<List<PacienteModel>> serviceResponse = new ServiceResponse<List<PacienteModel>>();

            try
            {
                serviceResponse.Dados = _db.Pacientes.ToList();

                if(serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado!";
                }


            } catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
    }
}
