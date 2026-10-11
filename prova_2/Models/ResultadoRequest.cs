using System.ComponentModel.DataAnnotations;

namespace prova_2.Models
{
    public class ResultadoRequest 
    {
        public string? Cpf { get; set; }
        public bool? Aprovado { get; set; }
    }
}
