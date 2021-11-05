using Ordenador.Domain.Enum;
using Ordenador.Domain.Models;
using System.Collections.Generic;

namespace Ordenador.Domain.Interfaces
{
    public interface IOrdenarLivro
    {
        List<Livro> Ordenar(List<Livro> livros, TipoOrdenacaoEnum tipoOrdenacao);
    }
}
