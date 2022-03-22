using System.Collections.Generic;
using System.Linq;
using ATS.Domain.Models;
using ATS.Infra.Context;

namespace ATS.Infra.Repositories
{
    public class VeiculoRepository : Repository<Veiculo>
    {
        public VeiculoRepository(AppDbContext context) : base(context)
        { }

        public override Veiculo GetById(int id)
        {
            var query = _context.Set<Veiculo>().Where(e => e.Id == id && e.Marca.Status=="A" && e.Proprietarios.Status == "A");

            if (query.Any())
                return query.First();

            return null;
        }

        public override IEnumerable<Veiculo> GetAll()
        {
             var query = _context.Set<Veiculo>().Where(e =>  e.Marca.Status == "A" && e.Proprietarios.Status == "A");

            return query.Any() ? query.ToList() : new List<Veiculo>();
        }


        public override void Delete(int id)
        {
            throw new Exception("Não é permitido excluir um veículo!");
        }

        public override void Save(Veiculo entity)
        {

            var ent = _context.Set<Veiculo>().Where(p => p.RENAVAM == entity.RENAVAM).FirstOrDefault();

            if (ent != null)
            {
                throw new Exception("Já existe este RENAVAM cadastrado!");
            }
            else
            {
                _context.Set<Veiculo>().Add(entity);
                _context.SaveChanges();
            }

        }

        public override void Update(Veiculo veiculo)
        {

            var ent = _context.Set<Veiculo>().Where(p => p.Id == veiculo.Id).FirstOrDefault();


            if (ent.Status == "I" && veiculo.Status == "D")
            {
                throw new Exception("Não é permitido redisponibilizar o veiculo!");
            }

            else
            {
                if (ent != null)
                {
                    _context.Entry(ent).CurrentValues.SetValues(veiculo);
                    _context.SaveChanges();
                }
            }
        }


    }
}