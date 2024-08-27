using MediatR;
using VideoGamesCQRS.Data;
using VideoGamesCQRS.Models;

namespace VideoGamesCQRS.Features.Players.DisablePlayer
{
    public class DisablePlayerCommandHandler : IRequestHandler<DisablePlayerCommand, int>
    {
        private VideoGameAppDbContext _context;

        public DisablePlayerCommandHandler(VideoGameAppDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DisablePlayerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _context.Players
                .FindAsync(new object[] { request.id }, cancellationToken);

                if (entity != null) {
                    entity.IsEnabled = false;
                }
                return await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
