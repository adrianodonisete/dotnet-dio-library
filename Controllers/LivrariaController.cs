using dioLivrariaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dioLivrariaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrariaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LivrariaController(AppDbContext context)
        {
            _context = context;

            _context.todoProducts.Add(new Produto
            {
                ID = "1",
                Nome = "Book1",
                Preco = 12.8,
                Quant = 1,
                Categoria = "Acao",
                Img = "img1"
            });
            _context.todoProducts.Add(new Produto
            {
                ID = "2",
                Nome = "Book2",
                Preco = 12.2,
                Quant = 3,
                Categoria = "Terror",
                Img = "img1"
            });
            _context.todoProducts.Add(new Produto
            {
                ID = "3",
                Nome = "Book3",
                Preco = 12.0,
                Quant = 1,
                Categoria = "Romance",
                Img = "img1"
            });
            _context.todoProducts.Add(new Produto
            {
                ID = "4",
                Nome = "Book4",
                Preco = 13.2,
                Quant = 1,
                Categoria = "Acao",
                Img = "img1"
            });
            _context.todoProducts.Add(new Produto
            {
                ID = "5",
                Nome = "Book5",
                Preco = 21.2,
                Quant = 1,
                Categoria = "Acao",
                Img = "img1"
            });

            _context.SaveChanges();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            return await _context.todoProducts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetOneProduto(int id)
        {
            var item = await _context.todoProducts.FindAsync(id.ToString());
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> AddProduto(Produto produto)
        {
            await _context.todoProducts.AddAsync(produto);
            _context.SaveChanges();


            var item = await _context.todoProducts.FindAsync(produto.ID);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }
    }
}
