
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CQRSPattern.DTO;
using CQRSPattern.Interface;
using CQRSPattern.Model;

namespace CQRSPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
       

        public UserController(IUserService userService
           )
        {
            _userService = userService;
           
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<ActionResult<UserModel>> AddUser([FromBody]UserDto model)
        {
            //var users = _mapper.Map<UserModel>(model);
            var result = await _userService.AddNewUser(model);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("GetAllUser")]
        public async Task<ActionResult<UserModel>> GetAllUser()
        {
            var result = await _userService.GetAllUser();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();

        }

        [HttpGet]
        [Route("GetSingleUser")]
        public async Task<ActionResult<UserModel>> GetSingleUser(int id)
        {

            var result = await _userService.GetSingleUser(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        
        }


        [HttpGet]
        [Route("GetByName")]
        public async Task<ActionResult<UserModel>> GetUserByName(string Name)
        {
            var result = await _userService.FilerUserByName(Name);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
