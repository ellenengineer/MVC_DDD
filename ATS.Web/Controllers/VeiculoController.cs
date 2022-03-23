using System.Collections.Generic;
using System.Linq;
using ATS.Domain.Interfaces;
using ATS.Domain.Models;
using ATS.Web.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ATS.Web.Controllers
{
    [Route("api/veiculo")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
 
        private readonly IRepository<Veiculo> _veiculoRepository;

        public VeiculoController(IRepository<Veiculo> veicRepository)
        {
            _veiculoRepository = veicRepository;
        }

         [HttpGet]
         public IEnumerable<Veiculo> GetVeiculos()
         {
             var veic = _veiculoRepository.GetAll();
            
            return veic;
        }


        [HttpGet("{id}")]
         public  ActionResult<Veiculo> GetVeiculo(int id)
         {
             var veic = _veiculoRepository.GetById(id);
             if (veic == null)
             {
                 return NotFound(new { message = $"Veiculo de id={id} não encontrado" });
             }
             return veic;
         }

        [HttpPost]
        public IActionResult Save([FromBody]Veiculo veic)
        {
            if (veic == null)
                return NotFound();
            try
            {
                _veiculoRepository.Save(veic);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Veiculo veic)
        {
            try
            {
                if (veic == null)
                    return NotFound();

                _veiculoRepository.Update(veic);

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return BadRequest();
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return BadRequest("Não é permitido excluir um veiculo!");
           
        }
    }
}