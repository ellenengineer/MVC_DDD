using System.Collections.Generic;
using System.Linq;
using ATS.Domain.Interfaces;
using ATS.Domain.Models;
using ATS.Web.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ATS.Web.Controllers
{
    [Route("api/marca")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
 
        private readonly IRepository<Marca> _marcaRepository;

        public MarcaController(IRepository<Marca> marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

         [HttpGet]
         public IEnumerable<Marca> GetMarcas()
         {
             var trucks = _marcaRepository.GetAll();
            
            return trucks;
        }


        [HttpGet("{id}")]
         public  ActionResult<Marca> GetMarca(int id)
         {
             var marca = _marcaRepository.GetById(id);
             if (marca == null)
             {
                 return NotFound(new { message = $"Marca de id={id} não encontrada" });
             }
             return marca;
         }

        [HttpPost]
        public IActionResult Save([FromBody]Marca marca)
        {
            if (marca == null)
                return NotFound();

            try
            {
                _marcaRepository.Save(marca);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Marca marca)
        {
            try
            {
                if (marca == null)
                    return NotFound();

                try
                {
                    _marcaRepository.Update(marca);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
                return Ok();
            }
            catch(Exception ex)
            {
                throw ex ;
            }

            return BadRequest();
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return BadRequest("Não é permitido excluir uma marca!");
           
        }
    }
}