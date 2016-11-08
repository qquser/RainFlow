using System;
using RF.ConsoleApp.AppController;


namespace RF.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            var controller = new ApplicationController(new SimpleInjectorAdapter()).InitializeDi();
            while (true)
            {
                try
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter command (help to display help): ");
                    ((ICommandService)controller.GetInstance<ICommandService>()).Execute(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error!\t" + ex.Message);
                }
            }
       }
    }
}
