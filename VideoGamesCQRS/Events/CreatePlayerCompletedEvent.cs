using MediatR;
using VideoGamesCQRS.Models;

namespace VideoGamesCQRS.Events
{
    public class CreatePlayerCompletedEvent : INotification
    {
        public CreatePlayerCompletedEvent(Player item)
        {
            Item = item;
        }

        public Player Item { get; }
    }
}
