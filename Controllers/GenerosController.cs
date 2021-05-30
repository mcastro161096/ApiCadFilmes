using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiCadFilmes.Domain.Models.Context;
using ApiCadFilmes.Domain.Models.Entities;
using ApiCadFilmes.Domain.Models.IServices;
using ApiCadFilmes.Domain.Models.Validator;
using FluentValidation.Results;

namespace ApiCadFilmes.Controllers
{
    [Route("api/generos")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private readonly IGeneroService _generoService;
        public readonly GeneroValidator _validationRules = new GeneroValidator();
        public ValidationResult _result = new ValidationResult();

        public GenerosController(IGeneroService generoService)
        {
            _generoService = generoService;
           
        }

       
        [HttpGet]
        public async Task<IEnumerable<Genero>> GetAllGenerosAsync()
        {
            
            return await _generoService.ListAsync();
               
        }

      
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Genero>> GetGeneroAsync(int id)
        {
            var genero = await _generoService.FindByIdAsync(id);
            
            if (genero == null)
            {
                return NotFound();
            }
            
            return genero;
        }

       
        [HttpPost]
        public async Task<ActionResult<Genero>> PostGenero(Genero genero)
        {
            _result = _validationRules.Validate(genero);
            if (_result.IsValid)
            {
                

                if (await _generoService.AddAsync(genero))
                {
                    return CreatedAtAction("GetGenero", new { id = genero.Id }, genero);
                }
                else
                {
                    return NotFound();
                }
                

                
            }
            return BadRequest(_result.Errors);

            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGeneroAsync(int id, Genero genero)
        {
            
            if (id != genero.Id)
            {
                return BadRequest();
            }
            if (await _generoService.Update(genero))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }

        

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGeneroAsync(int id, Genero genero)
        {
            
            if (genero.Id != id)
            {
                return BadRequest();
            }
            if (await _generoService.Remove(genero))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
            
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteManyAsync(IEnumerable<Genero> genero)
        {
            if (await _generoService.RemoveMany(genero))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }


    }
}
