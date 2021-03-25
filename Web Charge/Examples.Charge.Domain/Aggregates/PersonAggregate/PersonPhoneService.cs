using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonPhoneService : IPersonPhoneService
    {
        private readonly IPersonPhoneRepository _personPhoneRepository;
        public PersonPhoneService(IPersonPhoneRepository personPhoneRepository)
        {
            _personPhoneRepository = personPhoneRepository;
        }

        public async Task<PersonPhone> AddAsync(PersonPhone personPhone) => (await _personPhoneRepository.AddAsync(personPhone));

        public async Task DeleteAsync(PersonPhone personPhone) => await _personPhoneRepository.DeleteAsync(personPhone);

        public async Task<List<PersonPhone>> FindAllAsync() => (await _personPhoneRepository.FindAllAsync()).ToList();

        public async Task<PersonPhone> FindAsync(string key) => (await _personPhoneRepository.FindAsync(key));

        public async Task<PersonPhone> PutAsync(string previosKeys, PersonPhone personPhone) => (await _personPhoneRepository.PutAsync(previosKeys, personPhone));
    }
}
