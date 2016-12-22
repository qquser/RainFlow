using System;
using RF.BL.Commands;
using RF.ConsoleApp.AppController;


namespace RF.ConsoleApp
{
    public static class Program
    {
        static void Main()
        {
            var controller = new ApplicationController(new SimpleInjectorAdapter()).InitializeDi();
            var commandService = (ICommandService) controller.GetInstance<ICommandService>();
            while (true)
            {
                try
                {
                    ShowInfo("Enter command ('help' to display help): ");
                    var command = commandService.Execute(Console.ReadLine());
                    ShowResult(command.Response);
                }
                catch (Exception ex)
                {
                    ShowError(ex.Message);
                }
            }
       }

        public static void ShowError(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error!\t" + text);
            Console.ResetColor();
        }
        public static void ShowInfo(string text)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static void ShowResult(string text)
        {
            Console.WriteLine(text);
        }
    }
}
