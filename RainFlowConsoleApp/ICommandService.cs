using RF.BL.Commands;

namespace RF.ConsoleApp
{
    public interface ICommandService
    {
        ICommand Execute(string commandName);
    }
}
