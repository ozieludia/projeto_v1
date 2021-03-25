using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonPhoneRepository : IPersonPhoneRepository
    {
        private readonly ExampleContext _context;

        public PersonPhoneRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PersonPhone> AddAsync(PersonPhone personPhone) => await Task.Run(() =>
        {
            _context.PersonPhone.Add(personPhone);
            _context.SaveChanges();
            return personPhone;
        });

        public async Task DeleteAsync(PersonPhone personPhone) => await Task.Run(() =>
        {
            var keyValues = new object[] { personPhone.BusinessEntityID, personPhone.PhoneNumber, personPhone.PhoneNumberTypeID };
            var entity = _context.PersonPhone.Find(keyValues);
            if (entity == null)
            {
                throw new Exception($"key not found: {personPhone.BusinessEntityID}-{personPhone.PhoneNumber}-{personPhone.PhoneNumberType}");
            }
            _context.PersonPhone.Remove(entity);
            _context.SaveChanges();
        });

        public async Task<IEnumerable<PersonPhone>> FindAllAsync() => await Task.Run(() => _context.PersonPhone.Include(p => p.Person).Include(p => p.PhoneNumberType));

        public async Task<PersonPhone> FindAsync(string key) => await Task.Run(() =>
        {
            PersonPhone personPhone = JsonConvert.DeserializeObject<PersonPhone>(key);
            return _context.PersonPhone.Include(p => p.Person).Include(p => p.PhoneNumberType).Where(o => o.BusinessEntityID == personPhone.BusinessEntityID
                                        && o.PhoneNumber == personPhone.PhoneNumber
                                        && o.PhoneNumberTypeID == personPhone.PhoneNumberTypeID).FirstOrDefault();

        });

        public async Task<PersonPhone> PutAsync(string previosKeys, PersonPhone personPhone) => await Task.Run(() => 
        {
            PersonPhone previos = JsonConvert.DeserializeObject<PersonPhone>(previosKeys);
            var keyValues = new object[] { previos.BusinessEntityID, previos.PhoneNumber, previos.PhoneNumberTypeID };
            var entity = _context.PersonPhone.Find(keyValues);
            _context.Entry<PersonPhone>(entity).State = EntityState.Deleted;
            _context.PersonPhone.Add(personPhone);
            _context.SaveChanges();
            return personPhone;
        });
    }
}
