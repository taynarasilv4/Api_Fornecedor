using System.ComponentModel.DataAnnotations;

namespace Api_Fornecedor.Models
{
    public class Fornecedor
    {
        [Required]
        public string NomeFantasia { get; set; }

        [Required]
        public string RazãoSocial { get; set; }

        [Required]
        public string CNPJ { get; set; }

        [Required]
        public string Endereço { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Estado { get; set; }

        [Required]
        public string Telefone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Responsável { get; set; }


    }
}
