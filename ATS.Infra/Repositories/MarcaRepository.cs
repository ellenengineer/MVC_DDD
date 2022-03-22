using System.Collections.Generic;
using System.Linq;
using ATS.Domain.Models;
using ATS.Infra.Context;

namespace ATS.Infra.Repositories
{
    public class MarcaRepository : Repository<Marca>
    {
        public MarcaRepository(AppDbContext context) : base(context)
        { }

        public override Marca GetById(int id)
        {
            var query = _context.Set<Marca>().Where(e => e.Id == id);

            if (query.Any())
                return query.First();

            return null;
        }

        public override IEnumerable<Marca> GetAll()
        {
            var query = _context.Set<Marca>();

            return query.Any() ? query.ToList() : new List<Marca>();
        }


        public override void Save(Marca entity)
        {

            var ent = _context.Set<Marca>().Where(p => p.Nome == entity.Nome).FirstOrDefault();

            if (ent != null)
            {
                throw new Exception("Já existe uma marca com esse nome!");
            }
            else
            {
                _context.Set<Marca>().Add(entity);
                _context.SaveChanges();
            }

        }

        public override void Delete(int id)
        {
            throw new Exception("Não é permitido excluir uma marca!");
        }

        public override void Update(Marca marca)
        {

            var ent = _context.Set<Marca>().Where(p => p.Id == marca.Id).FirstOrDefault();


            if (ent.Nome != marca.Nome)
            {
                throw new Exception("Não é permitido alterar nome da marca!");
            }

            else
            {
                if (ent != null)
                {
                    _context.Entry(ent).CurrentValues.SetValues(marca);
                    _context.SaveChanges();
                }
            }
        }

    }
}