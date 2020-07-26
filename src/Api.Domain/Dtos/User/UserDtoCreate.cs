using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.User
{
    public class UserDtoCreate
    {
        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [StringLength(100, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Sobrenome é um campo obrigatório")]
        [StringLength(100, ErrorMessage = "Sobrenome deve ter no máximo {1} caracteres.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Apelido é um campo obrigatório")]
        [StringLength(100, ErrorMessage = "Apelido deve ter no máximo {1} caracteres.")]
        public string NickName { get; set; }

        [Required(ErrorMessage = "E-mail é um campo obrigatório")]
        [EmailAddress(ErrorMessage = "Email em formato inválido.")]
        [StringLength(150, ErrorMessage = "E-mail deve ter no máximo {1} caracteres.")]
        public string Email { get; set; }
    }
}