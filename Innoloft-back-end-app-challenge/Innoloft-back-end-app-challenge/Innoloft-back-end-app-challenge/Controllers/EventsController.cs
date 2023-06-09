﻿using AutoMapper;
using EventsAPI.Core.Entities;
using EventsAPI.Core.Interfaces;
using EventsAPI.Core.Utilities;
using Innoloft_back_end_app_challenge.Dtos.Events;
using Innoloft_back_end_app_challenge.ErrorMessages;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Innoloft_back_end_app_challenge.Controllers
{
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private IMapper _mapper;
        private IRepositoryEvent _eventRepository;
        private IRepositoryUser _userRepository;
        private IRepositoryEventRegistration _eventRegistration;
        private IRepositoryInvitedUsers _invitedUsers;
        public EventsController(
            IMapper mapper, 
            IRepositoryEvent eventRepository,
            IRepositoryUser userRepository, 
            IRepositoryEventRegistration eventRegistration,
            IRepositoryInvitedUsers invitedUsers)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
            _userRepository = userRepository;
            _eventRegistration = eventRegistration;
            _invitedUsers = invitedUsers;
        }

        [HttpPost]
        [Route(ApiRoutes.EventRoutes.CreateEvent)]
        public async Task<IActionResult> CreateEvent(EventPostDto eventPostDto)
        {
            var user = await _userRepository.Read(eventPostDto.CreatorId);
            if (user == null)
                return NotFound(EventErrMessages.UserNotFound);
            var ev = _mapper.Map<Event>(eventPostDto);
            _eventRepository.Create(ev);
            await _eventRepository.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        [Route(ApiRoutes.EventRoutes.GetEvents)]
        public async Task<ActionResult<Pagination<EventGetDto>>> GetEvents([FromQuery] GetUserEventDtoParams getUserEventDtoParams)
        {
            var user = await _userRepository.Read(getUserEventDtoParams.CreatorId);
            if (user == null)
                return NotFound(EventErrMessages.UserNotFound);
            var result =
                await _eventRepository.GetEventsByCreatorId(
                getUserEventDtoParams.Page,
                getUserEventDtoParams.ItemsPerPage,
                getUserEventDtoParams.CreatorId);
            var mappedResult = _mapper.Map<Pagination<EventGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpDelete]
        [Route(ApiRoutes.EventRoutes.DeleteEvent)]
        public async Task<IActionResult> DeleteEvent(int Id)
        {
            var ev = await _eventRepository.Read(Id);
            if (ev == null)
                return NotFound();
            _eventRepository.Delete(ev);
            await _eventRepository.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch]
        [Route(ApiRoutes.EventRoutes.EditEvent)]
        public async Task<IActionResult> UpdateEvent(EventUpdateDto eventUpdateDto,int Id)
        {
            Event? ev = await _eventRepository.Read(Id);
            if (ev == null)
                return NotFound();
            ev.StartDate = eventUpdateDto.StartDate;
            ev.EndDate = eventUpdateDto.EndDate;
            _eventRepository.Update(ev);
            _eventRepository.SaveChanges();
            return NoContent();
        }

        [HttpPost]
        [Route(ApiRoutes.EventRoutes.RegisterToEvent)]
        public async Task<IActionResult> RegisterToEvent(RegisterToEventDto registerToEventDto)
        {
            Event? ev = await _eventRepository.Read(registerToEventDto.EventId);
            User? user = await _userRepository.Read(registerToEventDto.ParticipatorId);
            if (ev == null)
                return NotFound();
            if (user == null)
                return NotFound();
            if (registerToEventDto.ParticipatorId == ev.CreatorId)
                return BadRequest("You can't register to your own event");
            EventRegistration registration = new()
            {
                EventId = ev.Id,
                ParticipatorId = registerToEventDto.ParticipatorId,
                IsParticipating = true
            };
            _eventRegistration.Create(registration);
            _eventRegistration.SaveChanges();
            return Ok();
        }

        [HttpPost]
        [Route(ApiRoutes.EventRoutes.InviteParticipants)]
        public async Task<IActionResult> InviteParticipants(InviteParticipantsPostDto inviteParticipantsPostDto)
        {
            Event? ev = await _eventRepository.Read(inviteParticipantsPostDto.EventId);
            if (ev == null)
                return NotFound("The event  do not exist");
            foreach(var guestId in inviteParticipantsPostDto.participantsIds)
            {
                User? user = await _userRepository.Read(guestId);
                if (user == null)
                    return NotFound("This do not exist");
                if (user.Id == inviteParticipantsPostDto.CreatorId)
                    return BadRequest("You can't invite yourself");
                _invitedUsers.Create(new InvitedUsers()
                {
                    EventId = ev.Id,
                    GuestId = guestId,
                    IsParticipating = false
                });
                _invitedUsers.SaveChanges();
            }
            return NoContent();
        }

        [HttpPatch]
        [Route(ApiRoutes.EventRoutes.AcceptInvitation)]
        public async Task<IActionResult> AcceptInvitation(AcceptInvitationDto acceptInvitationDto,int Id)
        {
            InvitedUsers? invitedUsers = await _invitedUsers.Read(Id);
            User? user = await _userRepository.Read(acceptInvitationDto.GuestId);
            if (invitedUsers == null)
                return NotFound("This invitation do not exist");
            if (user == null)
                return NotFound("This user do not exist");
            invitedUsers.IsParticipating = true;
            _invitedUsers.SaveChanges();
            return NoContent();
        }
    }
}
