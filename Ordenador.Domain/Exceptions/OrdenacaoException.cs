using System;

namespace Ordenador.Domain.Exceptions
{
    public class OrdenacaoException : Exception
    {
        public OrdenacaoException(string message) : base(message)
        {
        }
    }
}
