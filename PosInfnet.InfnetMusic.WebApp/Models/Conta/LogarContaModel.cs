using System.ComponentModel.DataAnnotations;

namespace PosInfnet.InfnetMusic.WebApp.Models.Conta
{
    public class LogarContaModel
    {
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Por favor, insira um endereço de e-mail válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
