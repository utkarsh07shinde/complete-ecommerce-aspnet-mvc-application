using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eTickets.Data.Services
{
    public class ActorsService : IActorService
    {
        private readonly AppDbContext _context;

        public ActorsService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Actor actor)
        {
            _context.Actors.Add(actor);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Actor> GetAll()
        {
            var result = _context.Actors.ToList();
            return result;
        }

        public Actor GetById(int id)
        {
            var result = _context.Actors.FirstOrDefault(n => n.Id == id);
            return result;
        }

        public Actor Update(int id, Actor newActor)
        {
            var existingActor = _context.Actors.Find(id);

            if (existingActor == null)
            {
                // Handle the case where the actor with the given id is not found
                return null;
            }

            existingActor.ProfilePictureURL = newActor.ProfilePictureURL;
            existingActor.FullName = newActor.FullName;
            existingActor.Bio = newActor.Bio;

            _context.Update(existingActor);
            _context.SaveChanges();

            return existingActor;
        }
    }
}
