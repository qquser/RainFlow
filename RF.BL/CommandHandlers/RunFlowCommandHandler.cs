using System;
using RF.BL.Commands;
using RF.Creators;
using RF.DataImplementation;
using RF.Rain;

namespace RF.BL.CommandHandlers
{
    public class RunFlowCommandHandler : ICommandHandler<RunFlowCommand>
    {
        private readonly IRainFlow<FlowData> _rainflow;
        public RunFlowCommandHandler(IRainFlow<FlowData> rainflow)
        {
            _rainflow = rainflow;
        }
        public void Handle(RunFlowCommand command)
        {
            Console.WriteLine("RainFlow");
            Console.WriteLine("Enter stress values. Input example:  12.1 1.55 -5 -5 7 4 -10");
            _rainflow.Input = Console.ReadLine();
            Console.WriteLine(_rainflow.ToString());
        }
    }
}
