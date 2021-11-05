using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Ordenador.Domain.Enum;
using Ordenador.Domain.Exceptions;
using Ordenador.Domain.Models;
using System;
using System.Collections.Generic;

namespace Ordenador.Tests
{
    public class OrdenacaoTests
    {
        public IConfigurationRoot Config { get; set; }
        public List<Livro> ListaDeLivros { get; set; }
        public Livro ClasseLivro { get; set; }
        public OrdenacaoTests()
        {
            ClasseLivro = new Livro();
            ListaDeLivros = new Livro().ObtemLivrosParaOrdenacao();
            Config = new ConfigurationBuilder().AddJsonFile("jsconfig.json").Build();
        }

        [Test]
        public void TituloAsc()
        {
            var ordenacao = (TipoOrdenacaoEnum)Enum.Parse(typeof(TipoOrdenacaoEnum), Config["TituloAsc"], true);
            var listaOrdenada = ClasseLivro.Ordenar(ListaDeLivros, ordenacao);

            Assert.AreEqual(listaOrdenada[0].Titulo, ListaDeLivros[2].Titulo);
            Assert.AreEqual(listaOrdenada[1].Titulo, ListaDeLivros[3].Titulo);
            Assert.AreEqual(listaOrdenada[2].Titulo, ListaDeLivros[0].Titulo);
            Assert.AreEqual(listaOrdenada[3].Titulo, ListaDeLivros[1].Titulo);
        }

        [Test]
        public void AutorAscTituloDesc()
        {
            var ordenacao = (TipoOrdenacaoEnum)Enum.Parse(typeof(TipoOrdenacaoEnum), Config["AutorAscTituloDesc"], true);
            var listaOrdenada = ClasseLivro.Ordenar(ListaDeLivros, ordenacao);

            Assert.AreEqual(listaOrdenada[0].Titulo, ListaDeLivros[0].Titulo);
            Assert.AreEqual(listaOrdenada[1].Titulo, ListaDeLivros[3].Titulo);
            Assert.AreEqual(listaOrdenada[2].Titulo, ListaDeLivros[2].Titulo);
            Assert.AreEqual(listaOrdenada[3].Titulo, ListaDeLivros[1].Titulo);
        }

        [Test]
        public void AnoEdicaoDescAutorDescTituloAsc()
        {
            var ordenacao = (TipoOrdenacaoEnum)Enum.Parse(typeof(TipoOrdenacaoEnum), Config["AnoEdicaoDescAutorDescTituloAsc"], true);
            var listaOrdenada = ClasseLivro.Ordenar(ListaDeLivros, ordenacao);

            Assert.AreEqual(listaOrdenada[0].Titulo, ListaDeLivros[3].Titulo);
            Assert.AreEqual(listaOrdenada[1].Titulo, ListaDeLivros[0].Titulo);
            Assert.AreEqual(listaOrdenada[2].Titulo, ListaDeLivros[2].Titulo);
            Assert.AreEqual(listaOrdenada[3].Titulo, ListaDeLivros[1].Titulo);
        }

        [Test]
        public void OrdenacaoNula()
        {
            var ordenacao = (TipoOrdenacaoEnum)Enum.Parse(typeof(TipoOrdenacaoEnum), Config["OrdenacaoNula"], true);
            Assert.Throws<OrdenacaoException>(() => ClasseLivro.Ordenar(ListaDeLivros, ordenacao));
        }

    }
}