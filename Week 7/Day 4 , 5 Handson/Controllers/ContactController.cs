using Contact_Management_System.DataAccessLayer.DbContextfolder;
using Contact_Management_System.DataAccessLayer.Modals;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Contact_Management_System.Controllers
{
    [Route("Contact")]
    public class ContactController : Controller
    {
        private readonly IContactRepository repo;
        private readonly AppDbContext db = new AppDbContext();

        public ContactController(IContactRepository repo)
        {
            this.repo = repo;
        }

        [Route("ShowContacts")]
        public IActionResult ShowContacts()
        {
            return View(repo.GetAllContacts());
        }

        [Route("AddContact")]
        public IActionResult AddContact()
        {
            ViewBag.Companies = db.Companies.ToList();
            ViewBag.Departments = db.Departments.ToList();
            return View();
        }

        [HttpPost]
        [Route("AddContact")]
        public IActionResult AddContact(ContactInfo contact)
        {
            repo.AddContact(contact);
            return RedirectToAction("ShowContacts");
        }

        [Route("EditContact/{id}")]
        public IActionResult EditContact(int id)
        {
            ViewBag.Companies = db.Companies.ToList();
            ViewBag.Departments = db.Departments.ToList();
            return View(repo.GetContactById(id));
        }

        [HttpPost]
        [Route("EditContact")]
        public IActionResult EditContact(ContactInfo contact)
        {
            repo.UpdateContact(contact);
            return RedirectToAction("ShowContacts");
        }

        [Route("DeleteContact/{id}")]
        public IActionResult DeleteContact(int id)
        {
            repo.DeleteContact(id);
            return RedirectToAction("ShowContacts");
        }
    }
}