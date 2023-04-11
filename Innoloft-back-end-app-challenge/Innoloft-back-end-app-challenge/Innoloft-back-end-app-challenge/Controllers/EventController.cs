using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Innoloft_back_end_app_challenge.Controllers
{
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private IMapper _mapper;
        public EventController(IMapper mapper) 
        { 
            _mapper = mapper;
        }


    }
}
