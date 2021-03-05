using MediatR;

namespace Xdl.Internship.Authentication.Handlers.GetUser
{
    public class GetUserRequest : IRequest<DTOs.User>
    {
        public GetUserRequest(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
