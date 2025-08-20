using FullStackRestaurant.Data;
using FullStackRestaurant.DTOs;
using FullStackRestaurant.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullStackRestaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        private readonly FullStackRestaurantDbContext _context;

        public TablesController(FullStackRestaurantDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetTables()
        {
            var tables = _context.Tables.ToList();
            return Ok(tables);
        }

        [HttpPost]
        public IActionResult CreateTable(CreateTableDTO dto)
        {
            var table = new Table
            {
                TableNumber = dto.TableNumber,
                Capacity = dto.Capacity
            };
            _context.Tables.Add(table);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetTables), new { id = table.Id}, table);
        }
    }
}
