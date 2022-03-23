using System.Collections.Generic;
using System.Linq;
using ATS.Domain.Interfaces;
using ATS.Domain.Models;
using ATS.Web.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ATS.Web.Controllers
{
    [Route("api/proprietario")]
    [ApiController]
    public class ProprietarioController : ControllerBase
    {
 
        private readonly IRepository<Proprietario> _propRepository;

        public ProprietarioController(IRepository<Proprietario> propRepository)
        {
            _propRepository = propRepository;
        }

         [HttpGet]
         public IEnumerable<Proprietario> GetProp()
         {
             var prop = _propRepository.GetAll();
            
            return prop;
        }


        [HttpGet("{id}")]
         public  ActionResult<Proprietario> GetProp(int id)
         {
             var propr = _propRepository.GetById(id);
             if (propr == null)
             {
                 return NotFound(new { message = $"Proprietario de id={id} não encontrado" });
             }
             return propr;
         }

        [HttpPost]
        public IActionResult Save([FromBody] Proprietario propr)
        {
            if (propr == null)
                return NotFound();

            try
            {
                _propRepository.Save(propr);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Proprietario propr)
        {
            try
            {
                if (propr == null)
                    return NotFound();

                _propRepository.Update(propr);

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
            return BadRequest("Não é permitido excluir um proprietario!");
        }
    }
}