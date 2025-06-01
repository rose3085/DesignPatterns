
using CQRSPattern.DTO;
using CQRSPattern.Features.User.Commands;
using CQRSPattern.Interface;
using CQRSPattern.Model;
using MediatR;

namespace CQRSPattern.Features.User.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly IUnitOfWork _uow;

        public CreateUserCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userDetails = new UserModel()
            {

                Name = request.request.Name,
                Age = request.request.Age,
                Email = request.request.Email,
                Phone = request.request.Phone,
            };
            var user = await _uow.AsyncRepositories<UserModel>().GetByName(a => a.Name == userDetails.Name);
            if (user != null)
            {
                return "User already exist";

            }
            else
            {
                await _uow.AsyncRepositories<UserModel>().AddUser(userDetails);
                 _uow.save();
                return ("User Added Successfully.");
            }

        }

    }
}
