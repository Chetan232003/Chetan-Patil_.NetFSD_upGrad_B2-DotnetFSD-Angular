using Contact_Management_System.DataAccessLayer.DbContextfolder;
using Contact_Management_System.DataAccessLayer.Modals;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext db;

        public ContactRepository()
        {
            db = new AppDbContext();
        }

        public List<ContactInfo> GetAllContacts()
        {
            return db.Contacts.Include(c => c.Company)
                              .Include(c => c.Department)
                              .ToList();
        }

        public ContactInfo GetContactById(int id)
        {
            return db.Contacts.Find(id);
        }

        public void AddContact(ContactInfo contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
        }

        public void UpdateContact(ContactInfo contact)
        {
            db.Contacts.Update(contact);
            db.SaveChanges();
        }

        public void DeleteContact(int id)
        {
            var data = db.Contacts.Find(id);
            db.Contacts.Remove(data);
            db.SaveChanges();
        }
    }
}