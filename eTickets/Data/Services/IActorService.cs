using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IActorService
    {
        Task<IEnumerable<Actor>> GetAll();
        Actor GetById(int id);
        void Add(Actor actor);
        void Delete(int id);
        Actor Update(int id,Actor newActor);
    }
}
