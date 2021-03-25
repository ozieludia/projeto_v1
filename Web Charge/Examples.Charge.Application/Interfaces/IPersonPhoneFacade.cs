using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonPhoneFacade
    {
        Task<PersonPhoneResponse> FindAllAsync();
        Task<PersonPhoneResponse> FindAsync(string key);
        Task<PersonPhoneResponse> AddAsync(PersonPhoneDto personPhoneDto);
        Task<PersonPhoneResponse> PutAsync(string previosKeys, PersonPhoneDto personPhoneDto);
        Task<PersonPhoneResponse> DeleteAsync(string personPhoneId);
        
    }
}