using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class PersonPhoneFacade : IPersonPhoneFacade
    {
        private readonly IPersonPhoneService _personPhoneService;
        private readonly IMapper _mapper;

        public PersonPhoneFacade(IPersonPhoneService personPhoneService, IMapper mapper)
        {
            _personPhoneService = personPhoneService;
            _mapper = mapper;
        }

        public async Task<PersonPhoneResponse> AddAsync(PersonPhoneDto personPhoneDto)
        {
            try
            {
                var result = await _personPhoneService.AddAsync(_mapper.Map<PersonPhone>(personPhoneDto));
                var response = new PersonPhoneResponse
                {
                    PersonPhoneObjects = new List<PersonPhoneDto>()
                };
                response.PersonPhoneObjects.Add(_mapper.Map<PersonPhoneDto>(result));
                return response;
            }
            catch (System.Exception ex)
            {
                return new PersonPhoneResponse
                {
                    Success = false,
                    Errors = new List<object>
                    {
                        ex.Message
                    }
                };
            }

        }

        public async Task<PersonPhoneResponse> DeleteAsync(string personPhoneId)
        {
            //string previos = JsonConvert.SerializeObject(personPhoneId);
            try
            {
                PersonPhoneDto personPhoneDto = JsonConvert.DeserializeObject<PersonPhoneDto>(personPhoneId);
                await _personPhoneService.DeleteAsync(_mapper.Map<PersonPhone>(personPhoneDto));
                return new PersonPhoneResponse
                {
                    Success = true
                };
            }
            catch (System.Exception ex)
            {
                return new PersonPhoneResponse
                {
                    Success = false,
                    Errors = new List<object>
                    {
                        ex.Message
                    }
                };
            }
        }

        public async Task<PersonPhoneResponse> FindAsync(string key)
        {
            try
            {
                var result = await _personPhoneService.FindAsync(key);
                var response = new PersonPhoneResponse
                {
                    PersonPhoneObjects = new List<PersonPhoneDto>()
                };
                response.PersonPhoneObjects.Add(_mapper.Map<PersonPhoneDto>(result));
                return response;
            }
            catch (System.Exception ex)
            {
                return new PersonPhoneResponse
                {
                    Success = false,
                    Errors = new List<object>
                    {
                        ex.Message
                    }
                };
            }
        }

        public async Task<PersonPhoneResponse> FindAllAsync()
        {
            try
            {
                var result = await _personPhoneService.FindAllAsync();
                var response = new PersonPhoneResponse
                {
                    PersonPhoneObjects = new List<PersonPhoneDto>()
                };
                response.PersonPhoneObjects.AddRange(_mapper.Map<List<PersonPhoneDto>>(result));
                return response;
            }
            catch (System.Exception ex)
            {
                return new PersonPhoneResponse
                {
                    Success = false,
                    Errors = new List<object>
                    {
                        ex.Message
                    }
                };
            }
        }

        public async Task<PersonPhoneResponse> PutAsync(string previosKeys, PersonPhoneDto personPhoneDto)
        {
            try
            {
                var result = await _personPhoneService.PutAsync(previosKeys, _mapper.Map<PersonPhone>(personPhoneDto));
                var response = new PersonPhoneResponse
                {
                    PersonPhoneObjects = new List<PersonPhoneDto>()
                };
                response.PersonPhoneObjects.Add(_mapper.Map<PersonPhoneDto>(result));
                return response;
            }
            catch (System.Exception ex)
            {
                return new PersonPhoneResponse
                {
                    Success = false,
                    Errors = new List<object>
                    {
                        ex.Message
                    }
                };
            }
        }
    }
}
