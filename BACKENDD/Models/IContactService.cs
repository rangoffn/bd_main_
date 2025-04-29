// Models/IContactService.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using BACKENDD.Models;

namespace BACKENDD.Models
{
    public interface IContactService
    {
        Task<bool> SaveContactAsync(Contact contact);  
        List<Contact> GetAllContacts();  
    }
}
