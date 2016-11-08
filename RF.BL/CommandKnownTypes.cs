using System;
using System.Linq;
using RF.BL.Commands;

namespace RF.BL
{
    public static class CommandKnownTypes
    {
        public static Type GetKnownTypes(string className)
        {
            var coreAssembly = typeof(ICommand).Assembly;

            var types = coreAssembly.GetExportedTypes()
                .Where(t => typeof(ICommand).IsAssignableFrom(t))
                .Where(t => !t.IsInterface)
                .Where(x => className.ToLower().Equals(x.Name.Replace("Command", "").ToLower())).ToList();
            if (!types.Any())
                throw new Exception("Command does not exist!");
            if (types.Count() > 1)
                throw new Exception("Wrong number of commands!");
            return types.First();
        }
    }
}
