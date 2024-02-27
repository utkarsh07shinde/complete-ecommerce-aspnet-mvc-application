using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class ActorsService : IActorService
    {
        private readonly AppDbContext _context;

        public ActorsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Actor actor)
        {
            _context.Actors.Add(actor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(n => n.Id == id);
             _context.Actors.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            return await _context.Actors.ToListAsync();
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            return await _context.Actors.FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<Actor> UpdateAsync(int id, Actor newActor)
        {
            var existingActor = await _context.Actors.FindAsync(id);

            if (existingActor == null)
            {
                // Handle the case where the actor with the given id is not found
                return null;
            }

            existingActor.ProfilePictureURL = newActor.ProfilePictureURL;
            existingActor.FullName = newActor.FullName;
            existingActor.Bio = newActor.Bio;

            _context.Update(existingActor);
            await _context.SaveChangesAsync();

            return existingActor;
        }
    }
}
