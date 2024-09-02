using Api_Fornecedor.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace APIFornecedor.Controllers
{
    [Route("fornecedor")]
    [ApiController]

    public class FornecedorController : ControllerBase
    {
        List<Fornecedor> listaFornecedor = new List<Fornecedor>();

        public FornecedorController()
        {
            var fornecedor1 = new Fornecedor()
            {
                NomeFantasia = "Tecno Solutions",
                RazãoSocial = "Tecno Solutions Ltda",
                CNPJ = "05.914.254/0001-39",
                Endereço = "Rua das Flores, 123",
                Cidade = "São Paulo",
                Estado = "São Paulo",
                Telefone = "(69) 98765 - 4321",
                Email = "contato @tecnosolutions.com.br",
                Responsável = "João da Silva"

            };

            var fornecedor2 = new Fornecedor()
            {
                NomeFantasia = "Padaria Pão Quente",
                RazãoSocial = "Padaria Pão Quente Eireli",
                CNPJ = "04.082.624/0001-56",
                Endereço = "Avenida Brasil, 456",
                Cidade = "Rio de Janeiro",
                Estado = "Rio de Janeiro",
                Telefone = "(69) 91234-5678",
                Email = "atendimento@paoquente.com.br",
                Responsável = "Maria Oliveira"
            };

            var fornecedor3 = new Fornecedor()
            {
                NomeFantasia = "Clínica Médica Vida",
                RazãoSocial = "Clínica Vida Saúde Ltda",
                CNPJ = "75.315.333/0001-09",
                Endereço = "Rua da Saúde, 789",
                Cidade = "Belo Horizonte",
                Estado = "Minas Gerais",
                Telefone = "(69) 99876-5432",
                Email = "contato@clinicavida.com.br",
                Responsável = "Dr. Carlos Mendes"
            };

            bool isCNPJValid = ValidarCnpj.ValidaCnpj(fornecedor1.CNPJ);
            isCNPJValid = ValidarCnpj.ValidaCnpj(fornecedor2.CNPJ);
            isCNPJValid = ValidarCnpj.ValidaCnpj(fornecedor3.CNPJ);

            if (isCNPJValid)
            {
                Console.WriteLine("CNPJ válido.");
            }
            else
            {
                Console.WriteLine("CNPJ inválido.");
            }

            listaFornecedor.Add(fornecedor1);
            listaFornecedor.Add(fornecedor2);
            listaFornecedor.Add(fornecedor3);

        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(listaFornecedor);
        }


        [HttpGet("{CNPJ}")]
        public IActionResult GetByCnpj(string CNPJ)
        {
            var fornecedor = listaFornecedor.Where(item => item.CNPJ == CNPJ).FirstOrDefault();
            if (fornecedor == null)
            {
                return NotFound();
            }
            return Ok(fornecedor);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Fornecedor item)
        {
            var contador = listaFornecedor.Count();
            var fornecedor = new Fornecedor();

            fornecedor.NomeFantasia = item.NomeFantasia;
            fornecedor.RazãoSocial = item.RazãoSocial;
            fornecedor.CNPJ = item.CNPJ;
            fornecedor.Endereço = item.Endereço;
            fornecedor.Cidade = item.Cidade;
            fornecedor.Estado = item.Estado;
            fornecedor.Telefone = item.Telefone;
            fornecedor.Email = item.Email;
            fornecedor.Responsável = item.Responsável;

            listaFornecedor.Add(fornecedor);
            return StatusCode(StatusCodes.Status201Created, fornecedor);

        }

        [HttpPut]
        public IActionResult Put(string cnpj, [FromBody] Fornecedor item)
        {
            var fornecedor = listaFornecedor.Where(item => item.CNPJ == cnpj).FirstOrDefault();

            if (fornecedor == null)
            {
                return NotFound();
            }

            fornecedor.NomeFantasia = item.NomeFantasia;
            fornecedor.RazãoSocial = item.RazãoSocial;
            fornecedor.CNPJ = item.CNPJ;
            fornecedor.Endereço = item.Endereço;
            fornecedor.Cidade = item.Cidade;
            fornecedor.Estado = item.Estado;
            fornecedor.Telefone = item.Telefone;
            fornecedor.Email = item.Email;
            fornecedor.Responsável = item.Responsável;

            return Ok(fornecedor);
        }
        [HttpDelete("{CNPJ}")]
        public IActionResult Delete(string cnpj, [FromBody] Fornecedor item)
        {
            var fornecedor = listaFornecedor.Where(item => item.CNPJ == cnpj).FirstOrDefault();

            if (fornecedor == null)
            {
                return NotFound();
            }

            listaFornecedor.Remove(fornecedor);
            return Ok(fornecedor);
        }

    }
}
