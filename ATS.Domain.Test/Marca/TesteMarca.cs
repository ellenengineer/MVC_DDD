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
    public class TesteMarca
    {
        private readonly IRepository<ATS.Domain.Models.Marca> _marcaRepository;

        [Fact]
        public void InstanciaMarca_Esperado_Sucesso()
        {
            var MarcaEsperada = new
            {
                Nome = "Marca 1",
                Status = "A"
            };

            var marca = new ATS.Domain.Models.Marca() { Nome = MarcaEsperada.Nome, Status = MarcaEsperada.Status };

            MarcaEsperada.ToExpectedObject().ShouldMatch(marca);
        }

        [Fact]
        public void InstanciaMarca_Esperado_Erro_Status()
        {
            string mensagemError = "Status Invalido!";

            var MarcaEsperada = new
            {
                Nome = "Marca ERRADA - STATUS"
                ,
                Status="F"
            };

            var marca = new ATS.Domain.Models.Marca() { Nome = MarcaEsperada.Nome, Status = MarcaEsperada.Status};

            Assert.Throws<ArgumentException>(() => new ATS.Domain.Models.Marca() { Nome = MarcaEsperada.Nome,   Status = MarcaEsperada.Status }).ValidarMensagem(mensagemError);

        }

        [Fact]
        public void InstanciaErroDuplicidade()
        {
            string mensagemError = "Já existe uma marca com esse nome";

            var MarcaEsperada = new
            {

                Nome = "Marca Duplicada",
                Status = "A"
            };

            var marca = new ATS.Domain.Models.Marca() { Nome = MarcaEsperada.Nome, Status = MarcaEsperada.Status};

            Assert.Throws<ArgumentException>(() => new ATS.Domain.Models.Marca() { Nome = MarcaEsperada.Nome, Status = MarcaEsperada.Status}).ValidarMensagem(mensagemError);

        }



        [Fact]
        public void TesteInclusao()
        {

            var marcaTeste = new Models.Marca
            {

                Nome = "Marca Teste Ellen",
                Status = "A"
            };

            try
            {
                _marcaRepository.Save(marcaTeste);
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
            var dados = _marcaRepository.GetAll();
            Assert.True(dados.Count() > 0);
        }

        [Fact]
        public void TesteGetById()
        {
            var dados = _marcaRepository.GetById(1);
            Assert.True(dados is not null);
        }


        [Fact]
        public void TesteAtualizacao()
        {

            var marcaTeste = new Models.Marca
            {

                Nome = "Marca Teste Ellen",
                Status = "I"
            };

            try
            {
                _marcaRepository.Update(marcaTeste);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);

            }

        }




        [Fact]
        public void TesteAtualizacaoERRO()
        {
            string mensagemError = "Não é permitido alterar nome da marca";

            var marcaTeste = new Models.Marca
            {

                Nome = "Marca Teste Ellen U",
                Status = "A"
            };

            try
            {
                _marcaRepository.Update(marcaTeste);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);
                Assert.Throws<ArgumentException>(() => marcaTeste).ValidarMensagem(mensagemError);
            }

        }

        [Fact]
        public void TesteExclusaoERRO()
        {
            string mensagemError = "Não é permitido excluir a marca";


            int id = 3;
            var marcaTeste = new Models.Marca
            {

                Nome = "Marca Teste Ellen",
                Status = "A"
            };

            try
            {
                _marcaRepository.Delete(id);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);
                Assert.Throws<ArgumentException>(() => marcaTeste).ValidarMensagem(mensagemError);
            }

        }

    }
}
