using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using RF.BL.Commands;
using RF.DataImplementation;
using RF.Rain;

namespace RF.BL.CommandHandlers
{
    public class RunFlowsCommandHandler : ICommandHandler<RunFlowsCommand>
    {
        private readonly IRainFlow<FlowData> _rainflow;
        public RunFlowsCommandHandler(IRainFlow<FlowData> rainflow)
        {
            _rainflow = rainflow;
        }

        public async void Handle(RunFlowsCommand command)
        {
            Console.WriteLine("Enter input file path. Input example:  E:\\input.txt");
            var inputFilePath = Console.ReadLine();
            Console.WriteLine("Enter output file path. Output example:  E:\\output.txt");
            var outputFilePath = Console.ReadLine();
            var fileNames = new string[2];
            fileNames[0] = inputFilePath; //@"E:\input.txt";//
            fileNames[1] = outputFilePath; // @"E:\output.txt"; 
            await Task.Run(() => PrintResults(fileNames));
            command.Response = "async task complited!";
        }


        private void PrintResults(string[] fileNames)
        {
            try
            {
                var inputFilePath = fileNames[0];
                var outputFilePath = fileNames[1];
                var outputFile = new StreamWriter(outputFilePath);
                const int bufferSize = 128;
                using (var fileStream = File.OpenRead(inputFilePath))
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, bufferSize))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        _rainflow.Input = line;
                        var result = _rainflow.ToString();
                        outputFile.WriteLine(result);
                    }
                }
                outputFile.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
