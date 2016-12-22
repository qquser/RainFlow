using System;
using RF.BL.Commands;

namespace RF.BL.CommandHandlers
{
    public class HelpCommandHandler : ICommandHandler<HelpCommand>
    {
        public void Handle(HelpCommand command)
        {
            var text = "runflow - command to start the rain flow with console input" + "\n"  +
                        "exit - command to close an application" + "\n" +
                        "runflows - command to start rain flows from file";
            command.Response = text;
        }
    }
}
