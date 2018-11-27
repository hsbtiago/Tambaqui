using System.Linq;
using Tambaqui.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Tambaqui.Services
{
    public class GeradorDeListas
    {
        private readonly Contexto db;

        public GeradorDeListas(Contexto db)
        {
            this.db = db;
        }

        public async Task<SelectList> Cores()
        {
            var lista = await db.Cores                
                .Select(w => new {w.Id, w.Nome})
                .AsNoTracking()
                .ToListAsync();
            
            return new SelectList(lista, "Id", "Nome");
        }        
    }
}