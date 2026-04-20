using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UnitOfWorkCrud.Data;
using UnitOfWorkCrud.DTO;
using UnitOfWorkCrud.Interface;
using UnitOfWorkCrud.Model;

namespace UnitOfWorkCrud.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context,
                            IUnitOfWork uow,
                            IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserModel>> GetAllUser()
        {
            
            var result = await _uow.AsyncRepositories<UserModel>().GetAllAsync();
            var user = _mapper.Map<IEnumerable<UserModel>>(result);
            if (user == null)
            {
                return null;

            }
            return user;

        }


        public async Task<string> AddNewUser(UserDto userDto)
        {
            if (userDto != null)
            {
                var user = _mapper.Map<UserModel>(userDto);
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
            var user = _mapper.Map<UserModel>(result);
            if (user == null)
            {
                return null;
            }
            return user;
            
        }


        public async Task<IEnumerable<UserModel>> FilerUserByName(string Name)
        {
            var result = await _uow.AsyncRepositories<UserModel>().GetGeneric<UserModel>(a => a.Name== Name);
            var user = _mapper.Map<IEnumerable<UserModel>>(result);
            if (user == null)
            {
                return null;
            }
            return user;
        }
    }
}
