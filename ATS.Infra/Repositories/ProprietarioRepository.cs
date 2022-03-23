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

        public override void Save(Proprietario entity)
        {

            var cep = helper.ReturnGetCEPRequest(entity.CEP);

            if (cep == null)
            {
                throw new Exception("CEP não encontrado");
            }
            else
            {
                var end = cep;
                entity.Endereco = end.street + ", " + end.neighborhood +  " - " + end.state;
                _context.Set<Proprietario>().Add(entity);
                _context.SaveChanges();
            }

        }

        public override void Update(Proprietario entity)
        {
            var ent = _context.Set<Proprietario>().Where(p => p.Id == entity.Id).FirstOrDefault();

            var cep = helper.ReturnGetCEPRequest(entity.CEP);


            if (cep == null)
            {
                throw new Exception("CEP não encontrado");
            }
            else
            {
                if (entity != null)
                {
                    entity.Endereco = cep.street + ", " + cep.neighborhood + " - " + cep.state;
                    _context.Entry(ent).CurrentValues.SetValues(entity);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("Erro ao buscar proprietário");
                }
            }
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