using MediatR;
using Stocks.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaWorker.Application.CasosUso.AdministrarProductos.ActualizarProducto
{
    public class ActualizarProductoHandler : IRequestHandler<ActualizarProductoRequest, IResult>
    {
        public ActualizarProductoHandler()
        {

        }
        public Task<IResult> Handle(ActualizarProductoRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
