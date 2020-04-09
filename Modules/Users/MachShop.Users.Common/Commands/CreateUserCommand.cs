using MachShop.Shared.Commands;

namespace MachShop.Users.Common.Commands
{
    public class CreateUserCommand : ICommand
    {
        public int Id { get; }
        public CreateUserCommand(int id)
        {
            Id = id;
        }

    }
}
