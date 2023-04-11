using AutoMapper;
using EventsAPI.Core.Entities;
using EventsAPI.Core.Interfaces;
using Innoloft_back_end_app_challenge.Dtos.Users;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace Innoloft_back_end_app_challenge.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IMapper _mapper;
        private HttpClient _client;
        private IConfiguration _configuration;
        private IRepositoryUser _userRepository;
        public UserController(IMapper mapper, IConfiguration configuration,IRepositoryUser repositoryUser)
        {
            _mapper = mapper;
            _client = new HttpClient();
            _configuration = configuration;
            _userRepository = repositoryUser;
        }

        [HttpPost]
        [Route(ApiRoutes.UserRoutes.CreateUser)]
        public async Task<IActionResult> CreateUser(int Id)
        {
            var response = await _client.GetAsync(_configuration["UserEndpoint"] + Id.ToString());
            if (response.StatusCode != HttpStatusCode.OK)
                return BadRequest();
            UserPostDto? userPostDto = JsonConvert.DeserializeObject<UserPostDto>(await response.Content.ReadAsStringAsync());
            userPostDto.Id = Id;
            if(await _userRepository.Read(Id) != null)
                return Conflict();
            _userRepository.Create(_mapper.Map<User>(userPostDto));
            _userRepository.SaveChanges();
            
            return Ok();
        }




    }
}
