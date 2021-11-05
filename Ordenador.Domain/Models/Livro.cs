using Ordenador.Domain.Enum;
using Ordenador.Domain.Exceptions;
using Ordenador.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Ordenador.Domain.Models
{

    public class Livro : IOrdenarLivro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AnoEdicao { get; set; }

        public List<Livro> ObtemLivrosParaOrdenacao()
        {
            var livros = new List<Livro>();

            livros.Add(new Livro { Id = 1, Titulo = "Java How to Program", Autor = "Deitel & Deitel", AnoEdicao = 2007 });
            livros.Add(new Livro { Id = 2, Titulo = "Patterns of Enterprise Application Architecture", Autor = "Martin Fowler", AnoEdicao = 2002 });
            livros.Add(new Livro { Id = 3, Titulo = "Head First Design Patterns", Autor = "Elisabeth Freeman", AnoEdicao = 2004 });
            livros.Add(new Livro { Id = 4, Titulo = "Internet & World Wide Web: How to Program", Autor = "Deitel & Deitel", AnoEdicao = 2007 });

            return livros;
        }

        public List<Livro> Ordenar(List<Livro> livros, TipoOrdenacaoEnum tipoOrdenacao)
        {
            switch (tipoOrdenacao)
            {
                case TipoOrdenacaoEnum.TituloAsc:
                    return livros.OrderBy(x => x.Titulo).ToList();

                case TipoOrdenacaoEnum.AutorAscTituloDesc:
                    return livros.OrderBy(x => x.Autor).ThenByDescending(x => x.Titulo).ToList();

                case TipoOrdenacaoEnum.AnoEdicaoDescAutorDescTituloAsc:
                    return livros.OrderByDescending(x => x.AnoEdicao).ThenByDescending(x => x.Autor).ThenBy(x => x.Titulo).ToList();

                case TipoOrdenacaoEnum.Nulo:
                    throw new OrdenacaoException("OrdenacaoException");

                default:
                    return new List<Livro>();
            }
        }
    }
}
