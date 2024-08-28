using MediatR;
using VideoGamesCQRS.Events;

namespace VideoGamesCQRS.Features.Players.CreatePlayer
{
    // 4:EVENT_HANDLING
    public class CreatePlayerCompletedEventHandler : INotificationHandler<CreatePlayerCompletedEvent>
    {
        private readonly ILogger<CreatePlayerCompletedEventHandler> _logger;

        public CreatePlayerCompletedEventHandler(ILogger<CreatePlayerCompletedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(CreatePlayerCompletedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreatePlayer:Success:{notification?.Item.Name}");
            return Task.CompletedTask;
        }
    }
}
