using System;
using RF.BL;
using RF.BL.Commands;
using RF.ConsoleApp.AppController;
using RF.BL.CommandHandlers;

namespace RF.ConsoleApp
{
    public class CommandService : ICommandService
    {
        private readonly IApplicationController _controller;
        public CommandService(IApplicationController controller)
        {
            _controller = controller;
        }

        public ICommand Execute(string input)
        {
            Type commandType = CommandKnownTypes.GetKnownTypes(input);
            Type commandHandlerType = typeof(ICommandHandler<>).MakeGenericType(commandType);

            dynamic commandHandler = _controller.GetInstance(commandHandlerType);
            dynamic command = _controller.GetInstance(commandType);
            commandHandler.Handle(command);

            return command;
        }
    }
}
