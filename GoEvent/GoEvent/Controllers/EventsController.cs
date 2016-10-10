using GoEvent.Core;
using GoEvent.Core.Models;
using GoEvent.Core.ViewModels;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace GoEvent.Controllers
{
    public class EventsController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public EventsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new EventFormViewModel
            {
                Heading = "Add a Event",
                Genres = _unitOfWork.Genre.GetGenres()
            };

            return View("EventForm", viewModel);
        }

        //Artist Create a Event
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _unitOfWork.Genre.GetGenres();
                return View("EventForm", viewModel);
            }
            
            var evento = new Event
            {

                ArtistId = User.Identity.GetUserId(),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue,
                DateTime = viewModel.GetDateTime()
            };

            _unitOfWork.Events.Add(evento);
            _unitOfWork.Complete();

            return RedirectToAction("Mine", "Events");
        }

        //Artist Update their Event
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(EventFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _unitOfWork.Genre.GetGenres();
                return View("EventForm", viewModel);
            }
            var evento = _unitOfWork.Events.GetEventWithAttendees(viewModel.Id);

            if (evento == null)
                return HttpNotFound();

            if (evento.ArtistId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            evento.Modify(viewModel.GetDateTime(), viewModel.Venue, viewModel.Genre);

            _unitOfWork.Complete();

            return RedirectToAction("Mine", "Events");
        }

        //Artist Edit their Event
        [Authorize]
        public ActionResult Edit(int id)
        {
            var evento = _unitOfWork.Events.GetEvent(id);

            if (evento == null)
                return HttpNotFound();

            if (evento.ArtistId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            var viewModel = new EventFormViewModel
            {
                Heading = "Edit a Event",
                Id = evento.Id,
                Genres = _unitOfWork.Genre.GetGenres(),
                Date = evento.DateTime.ToString("d MMM yyyy"),
                Time = evento.DateTime.ToString("HH:mm"),
                Venue = evento.Venue,
                Genre = evento.GenreId
            };

            return View("EventForm", viewModel);
        }

        //Events I'm coming (User)
        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();

            var events = _unitOfWork.Events.GetEventsUserAttending(userId);

            if (events == null)
                return HttpNotFound();

            var viewModel = new EventViewModel
            {
                upComingEvents = events,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Events I'm coming",
                Attendences = _unitOfWork.Attendence.GetFutureAttendances(userId).ToLookup(g => g.EventId),
                Followings = _unitOfWork.Following.GetFolloweesOfUser(userId).ToLookup(f => f.FolloweeId)
            };
            return View("Events", viewModel);
        }

        //My upcoming events (As Artist)
        [Authorize]
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var events = _unitOfWork.Events.GetUpcomingEventsByArtist(userId);

            return View(events);
        }

        public ActionResult Search(EventViewModel viewModel)
        {
            return RedirectToAction("Index", "Home", new {search = viewModel.SearchTerm});
        }

        public ActionResult Details(int id)
        {
            var evento = _unitOfWork.Events.GetEvent(id);

            if (evento == null)
                return HttpNotFound();

            var viewModel = new EventDetailsViewModel {Event = evento};

            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();

                viewModel.IsFollowing = _unitOfWork.Following
                    .GetFollowing(userId, evento.ArtistId);

                viewModel.IsAttending = _unitOfWork.Attendence
                    .GetAttendance(evento.Id, userId);
            }

            return View(viewModel);
        }


    }
}