using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGamesCQRS.Data;
using VideoGamesCQRS.Models;

namespace VideoGamesCQRS.Features.Players.GetPlayerById
{
    public class GetPlayerByIdQueryHandler : IRequestHandler<GetPlayerByIdQuery, Player?>
    {
        private readonly VideoGameAppDbContext _context;

        public GetPlayerByIdQueryHandler(VideoGameAppDbContext context)
        {
            _context = context;
        }

        public async Task<Player?> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
        {
            var player = await _context.Players.FindAsync(request.id);
            return player;
        }
    }
}
