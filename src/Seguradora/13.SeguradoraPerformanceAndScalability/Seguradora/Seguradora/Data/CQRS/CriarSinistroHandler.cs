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

        /// <summary>
        /// Handles the creation of a new Sinistro (claim).
        /// This method is responsible for adding a new Sinistro to the database and simulating the use of a queue for processing.
        /// It uses CQRS (Command Query Responsibility Segregation) pattern to separate the command from the query.
        /// The method is asynchronous and returns a Guid representing the ID of the newly created Sinistro
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
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
