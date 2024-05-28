using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IDatabaseService
    {
        IEnumerable<ActorFilmDetail> GetActorFilmDetails();
        void DeleteActor(int actorId);
    }
}