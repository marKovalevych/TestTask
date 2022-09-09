using DA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Repositories
{
    public interface IContactRepository
    {
        public HashSet<Contact> GetAllContacts();
        public Task<Contact> GetContactAsync(string email);
        public Task<Contact> GetContactByAccountAsync(string name);
        public Task CreateContactAsync(Contact contact);
        public void UpdateContact(Contact contact);
    }
}
