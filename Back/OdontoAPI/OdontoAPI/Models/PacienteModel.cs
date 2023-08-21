using OdontoAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace OdontoAPI.Models
{
    public class PacienteModel
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Number { get; set; }
        public string? Email { get; set; }
        public string? Description { get; set; }
        public TurnoEnum Turno { get; set; }
        public ExameTypeEnum Exame { get; set; }

    }
}
