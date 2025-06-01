using CQRSPattern.DTO;
using CQRSPattern.Model;

namespace CQRSPattern.Interface
{
    public interface IUserService
    {

        Task<string> AddNewUser(UserDto user);
        Task<IEnumerable<UserModel>> FilerUserByName(string name);
        Task<IEnumerable<UserModel>> GetAllUser();
        Task<UserModel> GetSingleUser(int id);

    }
}
