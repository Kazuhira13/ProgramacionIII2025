using Clase11.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Clase11.Data;

namespace Clase11.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfesoresController: ControllerBase
    {
        private readonly ClaseDbContext _context;

        public ProfesoresController(ClaseDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profesor>>> GetAll()
        {
            return await _context.Profesores.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Profesor>> Get(int id)
        {
            var profesor = await _context.Profesores.FindAsync(id);
            return profesor == null ? NotFound() : Ok(profesor);
        }

        [HttpPost]
        public async Task<ActionResult<Profesor>> Post(Profesor profesor)
        {
            _context.Profesores.Add(profesor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = profesor.Id }, profesor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Profesor profesor)
        {
            if (id != profesor.Id) return BadRequest();
            _context.Entry(profesor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var profesor = await _context.Profesores.FindAsync(id);
            if (profesor == null) return NotFound();
            _context.Profesores.Remove(profesor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
