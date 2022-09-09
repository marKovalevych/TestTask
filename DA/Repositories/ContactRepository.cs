using DA.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Repositories
{
    public class ContactRepository:IContactRepository
    {
        private readonly DataContext _context;

        public ContactRepository(DataContext context)
        {
            _context=context;
        }

        public async Task<Contact> GetContactAsync(string email)
        {
            return await _context.Contacts.FirstOrDefaultAsync(x => x.Email == email);
        }
        public async Task<Contact> GetContactByAccountAsync(string name)
        {
            return await _context.Contacts.FirstOrDefaultAsync(x => x.AccountName == name);
        }
        public async Task CreateContactAsync(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
        }

        public  HashSet<Contact> GetAllContacts()
        {
            return _context.Contacts.ToHashSet();
        }

        public void UpdateContact(Contact contact)
        {
            _context.Contacts.Update(contact);
            
        }
    }
}
