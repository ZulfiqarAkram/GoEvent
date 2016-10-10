using GoEvent.Core;
using GoEvent.Core.ViewModels;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace GoEvent.Controllers
{
    public class HomeController : Controller
    {

        private IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index(string search=null)
        {
            var upComingEvents = _unitOfWork.Events.GetUpcomingEvents();

            if (!string.IsNullOrWhiteSpace(search))
            {
                upComingEvents = _unitOfWork.Events.SearchEvents(upComingEvents, search);

            }
            var userId=User.Identity.GetUserId();

            var viewModel = new EventViewModel
            {
                upComingEvents=upComingEvents,
                ShowActions=User.Identity.IsAuthenticated,
                Heading = "Upcoming Events",
                SearchTerm = search,
                Attendences=_unitOfWork.Attendence.GetFutureAttendances(userId).ToLookup(g => g.EventId),
                Followings=_unitOfWork.Following.GetFolloweesOfUser(userId).ToLookup(f => f.FolloweeId)
            };
            return View("Events",viewModel);
        }
    }
}