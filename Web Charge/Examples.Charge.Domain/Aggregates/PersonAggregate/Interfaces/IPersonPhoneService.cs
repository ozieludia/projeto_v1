using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneService
    {
        Task<List<PersonAggregate.PersonPhone>> FindAllAsync();
        Task<PersonAggregate.PersonPhone> FindAsync(string key);
        Task<PersonAggregate.PersonPhone> AddAsync(PersonPhone personPhone);
        Task<PersonAggregate.PersonPhone> PutAsync(string previosKeys, PersonPhone personPhone);
        Task DeleteAsync(PersonPhone personPhone);
    }
}
