using System.Collections.Generic;
using System.Linq;
using ATS.Domain.Models;
using ATS.Infra.Context;

namespace ATS.Infra.Repositories
{
    public class ProprietarioRepository : Repository<Proprietario>
    {
        public ProprietarioRepository(AppDbContext context) : base(context)
        { }

        public override Proprietario GetById(int id)
        {
            var query = _context.Set<Proprietario>().Where(e => e.Id == id);

            if (query.Any())
                return query.First();

            return null;
        }

        public override IEnumerable<Proprietario> GetAll()
        {
            var query = _context.Set<Proprietario>();

            return query.Any() ? query.ToList() : new List<Proprietario>();
        }


        public override void Delete(int id)
        {
            throw new Exception("Não é permitido excluir um proprietário!");
        }



    }
}