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
    [Route("api/filmes")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private readonly IFilmeService _filmeService;
        public readonly FilmeValidator _validationRules = new FilmeValidator();
        public ValidationResult _result = new ValidationResult();

        public FilmesController(IFilmeService filmeService)
        {
            _filmeService = filmeService;
           
        }

        // GET: api/Filmes
        [HttpGet]
        public async Task<IEnumerable<Filme>> GetAllFilmesAsync()
        {
            //Retorno a lista de filmes através do serviço que criei especificamente para buscar filmes
            return await _filmeService.ListAsync();
               
        }

        // GET: api/Filmes/5
        //Aqui eu uso ActionResult porque caso o filme não seja encontrado preciso retornar 404 NotFound
        [HttpGet("{id}")]
        public async Task<ActionResult<Filme>> GetFilmeAsync(int id)
        {
            var filme = await _filmeService.FindByIdAsync(id);
            //checando se o filme foi encontrado, se não foi, retorna 404 not found
            if (filme == null)
            {
                return NotFound();
            }
            //se foi encontrado retorna o mesmo com sucesso
            return filme;
        }

        // POST: api/Filmes
        [HttpPost]
        public async Task<ActionResult<Filme>> PostFilme(Filme filme)
        {
            _result = _validationRules.Validate(filme);
            if (_result.IsValid)
            {
                

                if (await _filmeService.AddAsync(filme))
                {
                    return CreatedAtAction("GetFilme", new { id = filme.Id }, filme);
                }
                else
                {
                    return NotFound("O id da categoria informada não existe, o filme não pode ser salvo.");
                }
                

                
            }
            return BadRequest(_result.Errors);

            
        }

        // PUT: api/Filmes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilmeAsync(int id, Filme filme)
        {
            /*Garantindo que a requisição não veio com o id de um filme e com informações de outro, assim
            garantimos que não será feito update no filme errado, ou seja garantia de integridade */
            if (id != filme.Id)
            {
                return BadRequest();
            }
            //O método update me retorna true se conseguiu alterar e fazer o commit, se não, ele retorna false e da rollback
            if (await _filmeService.Update(filme))
            {
                //se alterou com sucesso retorno o 204 que é padrão para update
                return NoContent();
            }
            else
            {
                //se houve algum erro ou o filme não existe mais, retorno 404
                return NotFound();
            }

        }

        

        // DELETE: api/Filmes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilmeAsync(int id, Filme filme)
        {
            
            if (filme.Id != id)
            {
                return BadRequest();
            }
            if (await _filmeService.Remove(filme))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
            
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteManyAsync(IEnumerable<Filme> filmes)
        {
            if (await _filmeService.RemoveMany(filmes))
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
