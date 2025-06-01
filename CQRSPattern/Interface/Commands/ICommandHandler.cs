//using CQRSPattern.Interface.Commands;
//using MediatR;

//namespace CQRSPattern.Interface.Commands
//{
//    public interface ICommandHandler<TCommand> where TCommand : IRequest
//    {
//        Task Handle(TCommand command, CancellationToken cancellationToken);
//    }
//    public interface ICommandHandler<TCommand, TResponse> where TCommand : IRequest<TResponse>
//    {
//        Task Handle(TCommand command, CancellationToken cancellationToken);
//    }
//}
