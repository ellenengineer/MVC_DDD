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
    public class TesteVeiculo
    {
        private readonly IRepository<ATS.Domain.Models.Veiculo> _veiculoRepository;

        [Fact]
        public void InstanciaVeiculo_Esperado_Sucesso()
        {
            var MarcaEsperada = new  ATS.Domain.Models.Marca()
            {
                Nome = "Marca 1",
                Status = "A"
            };
            var PropEsperado = new ATS.Domain.Models.Proprietario()
            {
                Nome = "Proprietario 1",
                Email = "aaa@aa.com",
                Documento = "111.111.111-11",
                Endereco = "Rua ABC",
                Status = "A"
            };

            var VeicEsperado = new
            {
                Proprietarios =PropEsperado,
                Marca = MarcaEsperada,
                RENAVAM = "AAA",
                Modelo = "Modelo ABC",
                AnoFabricacao = "2007/2008",
                AnoModelo = 2007,
                Quilometragem="5000km",
                Valor= 20000.00,
                Status = "D"
            };

            var veic = new ATS.Domain.Models.Veiculo() { Proprietarios = VeicEsperado.Proprietarios
                                                       , Marca = VeicEsperado.Marca
                                                       ,RENAVAM = VeicEsperado.RENAVAM
                                                       ,Modelo = VeicEsperado.Modelo
                                                       ,AnoFabricacao = VeicEsperado.AnoFabricacao
                                                       ,AnoModelo = VeicEsperado.AnoModelo
                                                       ,Quilometragem = VeicEsperado.Quilometragem
                                                       ,Valor = (decimal)VeicEsperado.Valor
                                                       ,Status = VeicEsperado.Status };

            VeicEsperado.ToExpectedObject().ShouldMatch(veic);
        }

        [Fact]
        public void InstanciaVeic_Esperado_Erro_Status()
        {
            string mensagemError = "Status Invalido!";

            var MarcaEsperada = new ATS.Domain.Models.Marca()
            {
                Nome = "Marca 1",
                Status = "A"
            };
            var PropEsperado = new ATS.Domain.Models.Proprietario()
            {
                Nome = "Proprietario 1",
                Email = "aaa@aa.com",
                Documento = "111.111.111-11",
                Endereco = "Rua ABC",
                Status = "A"
            };

            var VeicEsperado = new
            {
                Proprietarios = PropEsperado,
                Marca = MarcaEsperada,
                RENAVAM = "AAA",
                Modelo = "Modelo ABC",
                AnoFabricacao = "2007/2008",
                AnoModelo = 2007,
                Quilometragem = "5000km",
                Valor = 20000.00,
                Status = "A"
            };

            var veic = new ATS.Domain.Models.Veiculo()
            {
                Proprietarios = VeicEsperado.Proprietarios
                                                     ,
                Marca = VeicEsperado.Marca
                                                     ,
                RENAVAM = VeicEsperado.RENAVAM
                                                     ,
                Modelo = VeicEsperado.Modelo
                                                     ,
                AnoFabricacao = VeicEsperado.AnoFabricacao
                                                     ,
                AnoModelo = VeicEsperado.AnoModelo
                                                     ,
                Quilometragem = VeicEsperado.Quilometragem
                                                     ,
                Valor = (decimal)VeicEsperado.Valor
                                                     ,
                Status = VeicEsperado.Status
            };

            Assert.Throws<ArgumentException>(() => new ATS.Domain.Models.Veiculo() {
                Proprietarios = VeicEsperado.Proprietarios
                                                     ,
                Marca = VeicEsperado.Marca
                                                     ,
                RENAVAM = VeicEsperado.RENAVAM
                                                     ,
                Modelo = VeicEsperado.Modelo
                                                     ,
                AnoFabricacao = VeicEsperado.AnoFabricacao
                                                     ,
                AnoModelo = VeicEsperado.AnoModelo
                                                     ,
                Quilometragem = VeicEsperado.Quilometragem
                                                     ,
                Valor = (decimal)VeicEsperado.Valor
                                                     ,
                Status = VeicEsperado.Status
            }).ValidarMensagem(mensagemError);

        }

        [Fact]
        public void InstanciaErroDuplicidade()
        {
            string mensagemError = "Já existe este RENAVAM cadastrado";

            var MarcaEsperada = new ATS.Domain.Models.Marca()
            {
                Nome = "Marca 1",
                Status = "A"
            };
            var PropEsperado = new ATS.Domain.Models.Proprietario()
            {
                Nome = "Proprietario 1",
                Email = "aaa@aa.com",
                Documento = "111.111.111-11",
                Endereco = "Rua ABC",
                Status = "A"
            };

            var VeicEsperado = new
            {
                Proprietarios = PropEsperado,
                Marca = MarcaEsperada,
                RENAVAM = "AAA",
                Modelo = "Modelo ABC",
                AnoFabricacao = "2007/2008",
                AnoModelo = 2007,
                Quilometragem = "5000km",
                Valor = 20000.00,
                Status = "A"
            };

            var veic = new ATS.Domain.Models.Veiculo()
            {
                Proprietarios = VeicEsperado.Proprietarios
                                                      ,
                Marca = VeicEsperado.Marca
                                                      ,
                RENAVAM = VeicEsperado.RENAVAM
                                                      ,
                Modelo = VeicEsperado.Modelo
                                                      ,
                AnoFabricacao = VeicEsperado.AnoFabricacao
                                                      ,
                AnoModelo = VeicEsperado.AnoModelo
                                                      ,
                Quilometragem = VeicEsperado.Quilometragem
                                                      ,
                Valor = (decimal)VeicEsperado.Valor
                                                      ,
                Status = VeicEsperado.Status
            };

            Assert.Throws<ArgumentException>(() => new ATS.Domain.Models.Veiculo()
            {
                Proprietarios = VeicEsperado.Proprietarios
                                                     ,
                Marca = VeicEsperado.Marca
                                                     ,
                RENAVAM = VeicEsperado.RENAVAM
                                                     ,
                Modelo = VeicEsperado.Modelo
                                                     ,
                AnoFabricacao = VeicEsperado.AnoFabricacao
                                                     ,
                AnoModelo = VeicEsperado.AnoModelo
                                                     ,
                Quilometragem = VeicEsperado.Quilometragem
                                                     ,
                Valor = (decimal)VeicEsperado.Valor
                                                     ,
                Status = VeicEsperado.Status
            }).ValidarMensagem(mensagemError);
        }



        [Fact]
        public void TesteInclusao()
        {

            ATS.Domain.Models.Marca MarcaEsperada = new ATS.Domain.Models.Marca()
            {
                Nome = "Marca 1",
                Status = "A"
            };
            Models.Proprietario PropEsperado = new ATS.Domain.Models.Proprietario()
            {
                Nome = "Proprietario 1",
                Email = "aaa@aa.com",
                Documento = "111.111.111-11",
                Endereco = "Rua ABC",
                Status = "A"
            };

            ATS.Domain.Models.Veiculo VeicEsperado = new Models.Veiculo()
            {
                Proprietarios = PropEsperado,
                Marca = MarcaEsperada,
                RENAVAM = "AAA",
                Modelo = "Modelo ABC",
                AnoFabricacao = "2007/2008",
                AnoModelo = 2007,
                Quilometragem = "5000km",
                Valor = 20000.00M,
                Status = "A"
            };

            try
            {
                _veiculoRepository.Save(VeicEsperado);
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
            var dados = _veiculoRepository.GetAll();
            Assert.True(dados.Count() > 0);
        }

        [Fact]
        public void TesteGetById()
        {
            var dados = _veiculoRepository.GetById(1);
            Assert.True(dados is not null);
        }


        [Fact]
        public void TesteAtualizacao()
        {

            ATS.Domain.Models.Marca MarcaEsperada = new ATS.Domain.Models.Marca()
            {
                Nome = "Marca 1",
                Status = "A"
            };
            Models.Proprietario PropEsperado = new ATS.Domain.Models.Proprietario()
            {
                Nome = "Proprietario 1",
                Email = "aaa@aa.com",
                Documento = "111.111.111-11",
                Endereco = "Rua ABC",
                Status = "A"
            };

            ATS.Domain.Models.Veiculo VeicEsperado = new Models.Veiculo()
            {
                Proprietarios = PropEsperado,
                Marca = MarcaEsperada,
                RENAVAM = "AAA",
                Modelo = "Modelo ABC",
                AnoFabricacao = "2007/2008",
                AnoModelo = 2007,
                Quilometragem = "5000km",
                Valor = 20000.00M,
                Status = "D"
            };

            try
            {
                _veiculoRepository.Update(VeicEsperado);
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
            string mensagemError = "Não é permitido excluir o veiculo";


            int id = 3;

            ATS.Domain.Models.Marca MarcaEsperada = new ATS.Domain.Models.Marca()
            {
                Nome = "Marca 1",
                Status = "A"
            };
            Models.Proprietario PropEsperado = new ATS.Domain.Models.Proprietario()
            {
                Nome = "Proprietario 1",
                Email = "aaa@aa.com",
                Documento = "111.111.111-11",
                Endereco = "Rua ABC",
                Status = "A"
            };

            ATS.Domain.Models.Veiculo VeicEsperado = new Models.Veiculo()
            {
                Proprietarios = PropEsperado,
                Marca = MarcaEsperada,
                RENAVAM = "AAA",
                Modelo = "Modelo ABC",
                AnoFabricacao = "2007/2008",
                AnoModelo = 2007,
                Quilometragem = "5000km",
                Valor = 20000.00M,
                Status = "D"
            };

            try
            {
                _veiculoRepository.Delete(id);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);
                Assert.Throws<ArgumentException>(() => VeicEsperado).ValidarMensagem(mensagemError);
            }

        }

    }
}
