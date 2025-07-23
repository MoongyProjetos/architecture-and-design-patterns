using MediatR;
using Seguradora.Data.QueueService;
using Seguradora.Domain;

namespace Seguradora.Data.CQRS
{
    public class CriarSinistroHandler : IRequestHandler<CriarSinistroCommand, Guid>
    {
        private readonly SeguradoraDbContext _db;
        private readonly IQueueService _queue;

        public CriarSinistroHandler(SeguradoraDbContext db, IQueueService queue)
        {
            _db = db;
            _queue = queue;
        }

        public async Task<Guid> Handle(CriarSinistroCommand request, CancellationToken cancellationToken)
        {
            var sinistro = new Sinistro
            {
                NumeroApolice = request.NumeroApolice,
                Descricao = request.Descricao
            };

            _db.Sinistros.Add(sinistro);
            await _db.SaveChangesAsync(cancellationToken);

            // Simula uso de fila (Queue-Based Load Leveling)
            await _queue.EnqueueAsync($"Novo sinistro registrado: {sinistro.Id}");

            return sinistro.Id;
        }
    }
}
