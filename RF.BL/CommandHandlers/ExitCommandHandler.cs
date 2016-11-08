using System;
using RF.BL.Commands;

namespace RF.BL.CommandHandlers
{
    public class ExitCommandHandler : ICommandHandler<ExitCommand>
    {
        public void Handle(ExitCommand command)
        {
            Environment.Exit(0);
        }
    }
}
