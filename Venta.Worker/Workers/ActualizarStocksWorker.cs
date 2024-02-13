
using Stocks.Domain.Service.Events;
using static Confluent.Kafka.ConfigPropertyNames;
using System.Threading;
using MediatR;
using VentaWorker.Application.CasosUso.AdministrarProductos.ActualizarProducto;

namespace Venta.Worker.Workers
{
    public class ActualizarStocksWorker : BackgroundService
    {
        private readonly IConsumerFactory _consumerFactory;
        private readonly IMediator _mediator;

        public ActualizarStocksWorker(IConsumerFactory consumerFactory, IMediator mediator) {
            _consumerFactory = consumerFactory;
            _mediator = mediator;
        }
        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            var consumer = _consumerFactory.GetConsumer();
            consumer.Subscribe("stocks");

            while (!cancellationToken.IsCancellationRequested)
            {
                var consumeResult = consumer.Consume(cancellationToken);
                //Llamar al handler para actualizar la información del producto
                //, la actualización deberia relizarse llamando una api del
                //microservicio de Ventas
                var request = new ActualizarProductoRequest();
                await _mediator.Send(request);
            }

            consumer.Close();

          //  return null;
        }
    }
}
