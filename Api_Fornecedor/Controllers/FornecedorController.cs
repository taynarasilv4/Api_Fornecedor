using Api_Fornecedor.DTO;
using Api_Fornecedor.Models;
using Api_Fornecedor.Validations; 
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Api_Fornecedor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        List<Fornecedor> listaFornecedores = new List<Fornecedor>();

        public FornecedorController()
        {
           
        }

        [HttpGet]
        public IActionResult Get()
        {
            var fornecedores = Txt.FornecedorTXT.ListaTXT();

            if (fornecedores == null)
            {
                return NotFound();
            }

            return Ok(fornecedores);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var fornecedor = Txt.FornecedorTXT.GetById(id);

            if (fornecedor == null)
            {
                return NotFound("Fornecedor não encontrado.");
            }

            return Ok(fornecedor);
        }

        [HttpPost]
        public IActionResult Post([FromBody] FornecedorDTO item)
        {
            if (!Cnpj.Validar(item.CNPJ)) 
            {
                return BadRequest("CNPJ inválido.");
            }

            var contador = listaFornecedores.Count;

            var fornecedor = new Fornecedor
            {
                Id = contador + 1,
                NomeFantasia = item.NomeFantasia,
                RazaoSocial = item.RazaoSocial,
                CNPJ = item.CNPJ,
                Endereco = item.Endereco,
                Cidade = item.Cidade,
                Estado = item.Estado,
                Telefone = item.Telefone,
                Email = item.Email,
                Responsavel = item.Responsavel
            };

            listaFornecedores.Add(fornecedor);
            Txt.FornecedorTXT.CriaTXT(item); 

            return StatusCode(StatusCodes.Status201Created, fornecedor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] FornecedorDTO item)
        {
            var fornecedor = Txt.FornecedorTXT.GetById(id);

            if (fornecedor == null)
            {
                return NotFound("Fornecedor não encontrado.");
            }

            if (!Cnpj.Validar(item.CNPJ))
            {
                return BadRequest("CNPJ inválido.");
            }

            fornecedor.NomeFantasia = item.NomeFantasia;
            fornecedor.RazaoSocial = item.RazaoSocial;
            fornecedor.CNPJ = item.CNPJ;
            fornecedor.Endereco = item.Endereco;
            fornecedor.Cidade = item.Cidade;
            fornecedor.Estado = item.Estado;
            fornecedor.Telefone = item.Telefone;
            fornecedor.Email = item.Email;
            fornecedor.Responsavel = item.Responsavel;

            Txt.FornecedorTXT.AtualizaTXT(id, item); 

            return Ok(fornecedor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!Txt.FornecedorTXT.DeletaTXT(id))
            {
                return NotFound("Fornecedor não encontrado.");
            }

            return NoContent(); 
        }
    }
}