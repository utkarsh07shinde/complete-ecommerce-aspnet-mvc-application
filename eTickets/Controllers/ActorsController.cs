using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {

        private readonly IActorService _service;

        public ActorsController(IActorService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var data = _service.GetAll();
            return View(data);
        }

        //Get:Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Actor actor)
        {
            actor.Actor_Movies = new List<Actor_Movie>();
            if (ModelState.IsValid)
            {
                _service.Add(actor);
                return RedirectToAction(nameof(Index));
            }

            // Check ModelState errors
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                Console.WriteLine($"ModelState Error: {error.ErrorMessage}");
            }

            return View(actor);
        }



        public IActionResult Details(int id)
        {
            var actorDetails = _service.GetById(id);
            if (actorDetails == null) return View("Empty");

            return View(actorDetails);
        }


        //Get:Actors/Edits
        public  IActionResult Edit(int id)
        {
            var actorDetails =  _service.GetById(id);
            if (actorDetails == null) return View("Empty");

            return View(actorDetails);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,ProfilePictureURL,FullName,Bio")] Actor actor)
        {
            
            if (ModelState.IsValid)
            {
                _service.Update(id, actor);
                return RedirectToAction(nameof(Index));
            }

            return View(actor);
        }



    }
}
