using GoEvent.Persistence;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using GoEvent.Core;

namespace GoEvent.Controllers
{
    public class FolloweesController : Controller
    {

        private IUnitOfWork _unitOfWork;

        public FolloweesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize]
        public ActionResult Index()
        {
            var artists = _unitOfWork.Following
                .GetOnlyFolloweesOfUser(User.Identity.GetUserId());

            return View(artists);
        }
    }
}