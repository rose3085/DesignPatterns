
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CQRSPattern.Data;
using CQRSPattern.DTO;
using CQRSPattern.Interface;
using CQRSPattern.Model;

namespace CQRSPattern.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;

        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context,
                            IUnitOfWork uow
                           )
        {
            _uow = uow;
     
        }

        public async Task<IEnumerable<UserModel>> GetAllUser()
        {
            
            var result = await _uow.AsyncRepositories<UserModel>().GetAllAsync();
            var users = new List<UserModel>();
            foreach (var results in result)
            { 
                var user = new UserModel()
                { 
                Phone = results.Phone,
                Name = results.Name,
                Email = results.Email,
                Age = results.Age,
                };
                users.Add(user);
            }
            //var user = _mapper.Map<IEnumerable<UserModel>>(result);
            if (users == null)
            {
                return null;

            }
            return users;

        }


        public async Task<string> AddNewUser(UserDto userDto)
        {
            if (userDto != null)
            {
                var user = new UserModel()
                { 
                    Name = userDto.Name,
                    Email = userDto.Email,
                    Phone = userDto.Phone,
                    Age = userDto.Age,
                };
                await _uow.AsyncRepositories<UserModel>().AddUser(user);
                _uow.save(); 

                return "User Added Successfully";
            }
            else
            {
                return "Couldn't add user"; 
            }
            
           
        }

        public async Task<UserModel> GetSingleUser(int id)
        {
            var result = await _uow.AsyncRepositories<UserModel>().GetById(id);
            var user = new UserModel()
            {
                Name = result.Name,
                Email = result.Email,
                Phone = result.Phone,
                Age = result.Age,
            };
            if (user == null)
            {
                return null;
            }
            return user;
            
        }


        public async Task<IEnumerable<UserModel>> FilerUserByName(string Name)
        {
            var result = await _uow.AsyncRepositories<UserModel>().GetGeneric<UserModel>(a => a.Name== Name);
            var users = new List<UserModel>();
            foreach (var results in result)
            {
                var user = new UserModel()
                {
                    Phone = results.Phone,
                    Name = results.Name,
                    Email = results.Email,
                    Age = results.Age,
                };
                users.Add(user);
            }
            if (users == null)
            {
                return null;
            }
            return users;
        }
    }
}
