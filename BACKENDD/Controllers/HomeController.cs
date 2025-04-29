using BACKENDD.Models;
using Microsoft.AspNetCore.Mvc;

namespace BACKENDD.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContactService _contactService;

        public HomeController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult NewTABBB()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Check(Contact contact)
        {
            if (ModelState.IsValid)
            {
                bool success = await _contactService.SaveContactAsync(contact);

                if (success)
                {
                    return RedirectToAction("ShowContacts");  
                }
                else
                {
                    ModelState.AddModelError("", "Ошибка при сохранении данных.");
                }
            }

            return View("Index");
        }

        public IActionResult ShowContacts()
        {
            var contacts = _contactService.GetAllContacts();  
            return View(contacts);  
        }
    }
}
