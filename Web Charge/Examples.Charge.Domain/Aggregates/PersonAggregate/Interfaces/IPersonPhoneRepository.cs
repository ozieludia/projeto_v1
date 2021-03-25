using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneRepository
    {
        Task<IEnumerable<PersonAggregate.PersonPhone>> FindAllAsync();
        Task<PersonAggregate.PersonPhone> FindAsync(string key);
        Task<PersonPhone> AddAsync(PersonPhone personPhone);
        Task DeleteAsync(PersonPhone personPhone);
        Task<PersonPhone> PutAsync(string previosKeys, PersonPhone personPhone);
    }
}
