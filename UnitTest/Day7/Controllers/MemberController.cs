using Microsoft.AspNetCore.Mvc;
using Day7.Services;
using Day7.Models;
using System.Linq;
namespace Day7.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;
        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        public ActionResult Index()
        {
            var item = _memberService.GetAllPeople().ToList();
            return View(item);
        }

        [HttpGet]
        public IActionResult CreatePeople()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePeople(MembeModel member)
        {
            _memberService.CreateMember(member);
            return RedirectToAction("Index");
        }

        public IActionResult UpdatePeople(int? id)
        {
            var item = _memberService.GetAllPeople().Where(m => m.id == id).FirstOrDefault();
            return View(item);
        }

        [HttpPost]
        public IActionResult UpdatePeople(MembeModel member)
        {

            _memberService.EditMember(member);
            return RedirectToAction("Index");

        }

        public IActionResult DeletePeople(MembeModel member)
        {
            HttpContext.Session.SetString("name", member.FirstName);
            return View(member);

        }

        [HttpPost]
        public IActionResult DeletePeople(int id)
        {
            var item = _memberService.GetAllPeople().Where(m => m.id == id).FirstOrDefault();
            _memberService.DeleteMember(item);
            return RedirectToAction("DeletePeople", item);
        }
        [HttpPost]
        public MembeModel GetMemberById(int id)
        {
            return _memberService.GetMemberById(id);

        }
    }
}