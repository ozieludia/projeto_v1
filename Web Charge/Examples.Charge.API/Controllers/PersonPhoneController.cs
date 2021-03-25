using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonPhoneController : BaseController
    {
        private readonly IPersonPhoneFacade _personPhoneFacade;
        private readonly IMapper _mapper;
        public PersonPhoneController(IPersonPhoneFacade personPhoneFacade, IMapper mapper)
        {
            _personPhoneFacade = personPhoneFacade;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PersonPhoneResponse>> Get() => Response(await _personPhoneFacade.FindAllAsync());
        [HttpGet]
        [Route("{key}")]
        public async Task<ActionResult<PersonPhoneResponse>> Get(string key) => Response(await _personPhoneFacade.FindAsync(key));
        [HttpPost]
        public async Task<ActionResult<PersonPhoneResponse>> Post(PersonPhoneRequest request) => Response(await _personPhoneFacade.AddAsync(_mapper.Map<PersonPhoneDto>(request)));
        [HttpPut]
        [Route("{previosKeys}")]
        public async Task<ActionResult<PersonPhoneResponse>> Put(string previosKeys, [FromBody] PersonPhoneRequest request) => 
            Response(await _personPhoneFacade.PutAsync(previosKeys, _mapper.Map<PersonPhoneDto>(request)));
        [HttpDelete]
        [Route("{key}")]
        public async Task<ActionResult<PersonPhoneResponse>> Delete(string key) => Response(await _personPhoneFacade.DeleteAsync(key));
    }
}
