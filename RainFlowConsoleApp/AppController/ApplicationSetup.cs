using RF.Creators;
using RF.CreatorsImplementation;
using RF.DataImplementation;
using RF.Rain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using RF.BL.CommandHandlers;

namespace RF.ConsoleApp.AppController
{
    public static class ApplicationSetup
    {
        public static IApplicationController InitializeDi(this IApplicationController controller)
        {
            return controller
                .Register(typeof(ICommandService), typeof(CommandService))
                .Register(typeof(IRainCreator<>), typeof(RainCreator))
                .Register(typeof(IDataCreator<>), typeof(DataCreator))
                .Register(typeof(IRainFlow<>), typeof(RainFlow))
                .Register(typeof(ICommandHandler<>), new[] { Assembly.GetAssembly(typeof(ICommandHandler<>)) }); ;
        }
    }
}

