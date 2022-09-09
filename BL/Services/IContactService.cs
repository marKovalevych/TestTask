using BL.ValidationModels;
using DA.Entities;

namespace BL.Services
{
    public interface IContactService
    {
        public Task<Contact> CreateContact(ContactModel model);
        public Task<Contact> UpdateContact(ContactModel model);
        public HashSet<Contact> GetContacts();
    }
}
