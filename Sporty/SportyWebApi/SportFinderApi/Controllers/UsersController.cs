using Model.DomainModels;
using SportFinderApi.DTO;
using SportFinderApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SportFinderApi.Controllers
{
    public class UsersController : ApiController
    {
        private IUserRepository _userRepo;

        public UsersController(IUserRepository repository)
        {
            _userRepo = repository;
        }

        [HttpGet]
        //GET api/users/getbyid
        public IHttpActionResult GetById(int? id)
        {
            if (id == null) return BadRequest();
            User user;
            user = _userRepo.GetById((int)id);
            if (user == null) return NotFound();
            return Ok(UsersMapper.MapUserToUserDto(user));
        }

        [HttpPost]
        //POST api/users/login
        public IHttpActionResult Login(UserDto input)
        {
            if (input.UserName == null || input.Password == null) return BadRequest();
            User user;
            user = _userRepo.Single(x => (x.UserName.Equals(input.UserName)) && (x.Password.Equals(input.Password)));
            if (user == null) return Unauthorized();
            return Ok(UsersMapper.MapUserToUserDto(user));
        }

        [HttpPost]
        //POST api/users/register
        public IHttpActionResult Register(UserDto input)
        {
            if (!input.Validate()) return BadRequest("Popunite sve podatke");
            //provjeri jel ima vec neki email ili username
            if (_userRepo.Single(x => x.Email.Equals(input.Email) || x.UserName.Equals(input.UserName)) != null) return BadRequest("Postoji vec user s podatcima email/username");
            User user = UsersMapper.MapUserDtoToUser(input);
            City city = _userRepo.FindCity(input.CityName);
            if (city == null) return BadRequest("Grad ne postoji");
            user.City = city;
            _userRepo.Add(user);
            return Ok();

            ////init all ratings
            //List<Sport> sports = _userRepo.GetAllSports().ToList();
            //user.Ratings = new List<Rating>();
            //foreach(Sport s in sports)
            //{
            //    user.Ratings.Add(new Rating() { Sport = s, Value = 0 });
            //}
            //_userRepo.Add(user);
            //return Ok();
        }
    }
}
