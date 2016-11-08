using System;
using RF.BL.Commands;

namespace RF.BL.CommandHandlers
{
    public class HelpCommandHandler : ICommandHandler<HelpCommand>
    {
        public void Handle(HelpCommand command)
        {
            Console.WriteLine("runflow - command to start the rain flow with console input");
            Console.WriteLine("exit - command to close an application");
            Console.WriteLine("runflows - command to start rain flows from file");
        }
    }
}
