using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ExpectedObjects;
using ATS.Domain;
using ATS.Domain.Test.Util;
using ATS.Domain.Interfaces;

namespace ATS.Domain.Test
{
    public class TesteProprietario
    {
        private readonly IRepository<ATS.Domain.Models.Proprietario> proprietarioRepository;

        [Fact]
        public void InstanciaPropr_Esperado_Sucesso()
        {
            var PropEsperado = new
            {
                Nome = "Proprietario 1",
                Email = "aaa@aa.com",
                Documento= "111.111.111-11",
                Endereco="Rua ABC",
                Status = "A"
            };

            var propr = new ATS.Domain.Models.Proprietario() { Nome = PropEsperado.Nome, Email = PropEsperado.Email, Documento = PropEsperado.Documento,Endereco = PropEsperado.Endereco,  Status = PropEsperado.Status };

            PropEsperado.ToExpectedObject().ShouldMatch(propr);
        }

        [Fact]
        public void InstanciaMarca_Esperado_Erro_Status()
        {
            string mensagemError = "Status Invalido!";

            var PropEsperado = new
            {
                Nome = "Proprietario Erro Status",
                Email = "aaa@aa.com",
                Documento = "111.111.111-11",
                Endereco = "Rua ABC",
                Status = "S"
            };

            var propr = new ATS.Domain.Models.Proprietario() { Nome = PropEsperado.Nome, Email = PropEsperado.Email, Documento = PropEsperado.Documento, Endereco = PropEsperado.Endereco, Status = PropEsperado.Status };


            Assert.Throws<ArgumentException>(() => new ATS.Domain.Models.Proprietario() { Nome = PropEsperado.Nome, Email = PropEsperado.Email, Documento = PropEsperado.Documento, Endereco = PropEsperado.Endereco, Status = PropEsperado.Status }).ValidarMensagem(mensagemError);

        }



        [Fact]
        public void TesteInclusao()
        {

            var propTeste = new Models.Proprietario
            {

                Nome = "Proprietario 1",
                Email = "aaa@aa.com",
                Documento = "111.111.111-11",
                Endereco = "Rua ABC",
                Status = "A"
            };

            try
            {
                proprietarioRepository.Save(propTeste);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);
            }

        }
        [Fact]
        public void TesteListagem()
        {
            var dados = proprietarioRepository.GetAll();
            Assert.True(dados.Count() > 0);
        }

        [Fact]
        public void TesteGetById()
        {
            var dados = proprietarioRepository.GetById(1);
            Assert.True(dados is not null);
        }


        [Fact]
        public void TesteAtualizacao()
        {

            var propTeste = new Models.Proprietario
            {

                Nome = "Proprietario 1",
                Email = "aaa@aa.com",
                Documento = "111.111.111-11",
                Endereco = "Rua ABC",
                Status = "A"
            };

            try
            {
                proprietarioRepository.Update(propTeste);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);

            }

        }


        [Fact]
        public void TesteExclusaoERRO()
        {
            string mensagemError = "Não é permitido excluir o proprietario";


            int id = 3;
            var propTeste = new Models.Proprietario
            {

                Nome = "Proprietario 1",
                Email = "aaa@aa.com",
                Documento = "111.111.111-11",
                Endereco = "Rua ABC",
                Status = "A"
            };

            try
            {
                proprietarioRepository.Delete(id);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);
                Assert.Throws<ArgumentException>(() => propTeste).ValidarMensagem(mensagemError);
            }

        }

    }
}
