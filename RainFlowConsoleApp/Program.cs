using RainFlowConsoleApp.Creators;
using RainFlowConsoleApp.Data;
using RainFlowConsoleApp.Rain;
using System;
using System.Linq;
using RainFlowConsoleApp.CreatorsImplementation;
using RainFlowConsoleApp.DataImplementation;
using RainFlowConsoleApp.LinkedList;

namespace RainFlowConsoleApp
{
    class Program
    {
        static void Main()
        {
            //https://en.wikipedia.org/wiki/Rainflow-counting_algorithm
            //http://fsapr2000.ru/topic/68929-metod-dozhdia/
            Console.WriteLine("RainFlow");
            Console.WriteLine("Enter stress values. Input example:  12.1 1.55 -5 -5 7 4 -10");
            Run();
            Console.ReadKey();
        }

        public static void Run()
        {
            try
            {
                string input = Console.ReadLine();
                IRainCreator<FlowData> rainCreator = new RainCreator();
                IDataCreator<FlowData> dataCreator = new DataCreator();
                IRainFlow<FlowData> rainflow = new RainFlow(input, rainCreator, dataCreator);
                rainflow.PrintResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!\t" + ex.Message);
                Run();
            }
        }
    }
}
