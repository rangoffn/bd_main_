using BACKENDD.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BACKENDD.Models
{
    public class ContactService : IContactService
    {
        private readonly AppDbContext _context;

        public ContactService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveContactAsync(Contact contact)
        {
            try
            {
                _context.Contacts.Add(contact);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException dbEx)
            {
                // Логируем еррор и выводим в консоль!!!!
               
                Console.Error.WriteLine($"Database error: {dbEx.Message}");
                return false;
            }
        }

        public List<Contact> GetAllContacts()
        {
            return _context.Contacts.OrderBy(c => c.Id).ToList(); 
        }
    }
}
