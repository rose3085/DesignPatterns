using CQRSPattern.DTO;
using CQRSPattern.Model;
using MediatR;

namespace CQRSPattern.Features.User.Commands
{

    //public record CreateUserCommand : IRequest<UserModel>
    //{
    //    public string Name { get; set; }
    //    public string Email { get; set; }
    //    public long Phone { get; set; }
    //    public int Age { get; set; }
    //    public CreateUserCommand(string name, string email, long phone, int age)
    //    {
    //        Name = name;
    //        Email = email;
    //        Phone = phone;
    //        Age = age;

    //    }
    //}
    public record CreateUserCommand(UserDto request) : IRequest<string>;

}
