using FluentAssertions;
using HeroisDoCancer.Models;
using HeroisDoCancer.Services;
using HeroisDoCancer.Services.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;

namespace HeroisDoCancer.Tests.Services
{
    [TestClass]
    public class VoluntarioServiceTest
    {
        [TestMethod]
        public void ComVoluntarioNoContextoDeveResgatarPeloNomeFabio()
        {
            var contextoMock = new Mock<IContextoDados>();
            contextoMock.SetupGet(c => c.Voluntarios)
                .Returns(new[]
                {
                    new Voluntario { Nome = "Fabio" }
                });

            var servico = new VoluntarioService(contextoMock.Object);
            var voluntario = new Voluntario { Nome = "Fabio" };

            servico.ExistePeloNome(voluntario)
                .Should()
                    .BeTrue();

            voluntario.Nome = "fabiO";
            servico.ExistePeloNome(voluntario)
                .Should()
                    .BeTrue();
        }

        [TestMethod]
        public void NaoDevePermitirVoluntarioNulo()
        {
            var contextoMock = new Mock<IContextoDados>();
            var servico = new VoluntarioService(contextoMock.Object);

            Action method = () => servico.Cadastra(null);

            method.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void NomeDeveSerUnico()
        {
            var contextoMock = new Mock<IContextoDados>();
            var servicoMock = new Mock<VoluntarioService>(contextoMock.Object);
            servicoMock.Setup(s => s.ExistePeloNome(It.IsAny<Voluntario>()))
                .Returns(false);
            servicoMock.Setup(s => s.ValidarCampos(It.IsAny<Voluntario>()))
                .Returns(new Dictionary<String, String[]>() { { "Nome", new String[0] } });

            var servico = servicoMock.Object;

            var voluntario = new Voluntario();
            Action method = () => servico.Cadastra(voluntario);

            method.ShouldThrow<CamposInvalidosException>();
        }

        [TestMethod]
        public void NomeDeveSerObrigatorio()
        {
            var contexto = new Mock<IContextoDados>();
            var service = new VoluntarioService(contexto.Object);

            var validados = service.ValidarCampos(new Voluntario());

            validados.Should()
                .NotBeNull().And
                .NotBeEmpty().And
                .ContainKey("Nome");
        }

        [TestMethod]
        public void SenhaDeveSerObrigatorio()
        {
            var contexto = new Mock<IContextoDados>();
            var service = new VoluntarioService(contexto.Object);

            var validados = service.ValidarCampos(new Voluntario());

            validados.Should()
                .NotBeNull().And
                .NotBeEmpty().And
                .ContainKey("Senha");
        }

        [TestMethod]
        public void EmailDeveSerObrigatorio()
        {
            var contexto = new Mock<IContextoDados>();
            var service = new VoluntarioService(contexto.Object);

            var validados = service.ValidarCampos(new Voluntario());

            validados.Should()
                .NotBeNull().And
                .NotBeEmpty().And
                .ContainKey("Email");
        }
    }
}