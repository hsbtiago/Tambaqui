using System.Linq;
using Tambaqui.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Tambaqui.Controllers
{
    public class PessoasController : Controller
    {
        private readonly Contexto db;

        public PessoasController(Contexto contexto) => db = contexto;

        public async Task<IActionResult> Index()
        {                        
            var lista = await db.Pessoas                
                .AsNoTracking()
                .ToListAsync();

            return View(lista);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)            
                return BadRequest();            

            var model = await db.Pessoas.SingleOrDefaultAsync(m => m.Id == id);
            
            if (model == null)            
                return NotFound();            

            return View(model);
        }

        
        public IActionResult Criar()
        {
            return View();
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(Pessoa model)
        {
            if (ModelState.IsValid)
            {
                db.Add(model);                

                await db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }            
            
            return View(model);
        }
        
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)            
                return NotFound();
            
            var model = await db.Pessoas.SingleOrDefaultAsync(m => m.Id == id);
            
            if (model == null)            
                return NotFound();
                        
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Pessoa model)
        {   
            if (ModelState.IsValid)
            {
                db.Update(model);
                await db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            
            return View(model);
        }
        
    }
}